using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using BusinessLogic;
using BusinessObjects;

namespace PopotosKitchenV2
{
    /// <summary>
    /// Interaction logic for RecipeInformation.xaml
    /// </summary>
    public partial class RecipeInformation : MetroWindow
    {
        private RecipeManager _myRecipeManager = new RecipeManager();
        private OrderLine _orderLine = new OrderLine();
        private string recipeName = null;

        public OrderLine newOrderLine
        {
            get { return _orderLine; }
            set { _orderLine = value; }
        }

        public RecipeInformation(OrderLine orderLine, AccessToken aToken)
        {
            InitializeComponent();
            _orderLine = orderLine;
            if(_orderLine.RecipeID != null)
            {
                recipeName = _orderLine.RecipeID;
            }


            txtRecipeInfo_Price.Text = _orderLine.Price.ToString();
            txtRecipeInfo_Quantity.Text = _orderLine.Quantity.ToString();
            if(_orderLine.Completed == false)
            {
                radCompleted_No.IsChecked = true;
                radCompleted_Yes.IsChecked = false;
            }
            else
            {
                radCompleted_Yes.IsChecked = true;
                radCompleted_No.IsChecked = false;
            }

            foreach(var r in aToken.Roles)
            {
                if(r.RoleID == "Chef Popoto" || r.RoleID == "Sous Popoto")
                {
                    pnlComplete.IsEnabled = true;
                }
            }
        }

        private void cmbRecipeInfo_ChooseRecipe_Loaded(object sender, RoutedEventArgs e)
        {
            var recipes = _myRecipeManager.GetRecipeNames();
            List<String> recipeNames = new List<String>();

            try
            {
                var comboBox = sender as ComboBox;
                comboBox.ItemsSource = recipes;

                if (String.IsNullOrWhiteSpace(recipeName))
                {
                    comboBox.SelectedIndex = 0;
                }
                else
                {
                    try
                    {
                        comboBox.SelectedItem = recipeName;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Could not select correct recipe. Try again.");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not populate recipe selection box.");
            }
        }

        private void btnRecipeInfo_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnRecipeInfo_Confirm_Click(object sender, RoutedEventArgs e)
        {
            int price = 0;
            int quantity = 0;

            if(Int32.TryParse(txtRecipeInfo_Price.Text, out price) && Int32.TryParse(txtRecipeInfo_Quantity.Text, out quantity))
            {
                this.DialogResult = true;
                _orderLine.RecipeID = cmbRecipeInfo_ChooseRecipe.SelectedItem.ToString();
                _orderLine.Price = price;
                _orderLine.Quantity = quantity;
                if(radCompleted_Yes.IsChecked == true)
                {
                    _orderLine.Completed = true;
                }
                else
                {
                    _orderLine.Completed = false;
                }

                
            }
            else
            {
                MessageBox.Show("Please enter numeric values.");
            }
        }

        private void cmbRecipeInfo_ChooseRecipe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRecipe = cmbRecipeInfo_ChooseRecipe.SelectedItem.ToString();
            string imageString = @"Resources/" + selectedRecipe + ".png";
            string muffinString = @"Resources/Isghardian Muffin.png";

            BitmapImage image = new BitmapImage(new Uri(imageString, UriKind.Relative));
            imgRecipes.Source = image;

            if(cmbRecipeInfo_ChooseRecipe.SelectedIndex == 14)
            {
                BitmapImage muffin = new BitmapImage(new Uri(muffinString, UriKind.Relative));
                imgRecipes.Source = image;
            }
        }
    }
}
