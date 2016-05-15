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
    /// Interaction logic for IngredientInformation.xaml
    /// </summary>
    public partial class IngredientInformation : MetroWindow
    {
        private RecipeManager _myRecipeManager = new RecipeManager();
        private string _ingredientID = null;
         
        public IngredientInformation(string ingredientID)
        {
            InitializeComponent();
            _ingredientID = ingredientID;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            try
            {
                var i = _myRecipeManager.GetIngredientInfoByID(_ingredientID);

                lblTitle.Content = i.IngredientID;
                txtIngredient_Location.Text = i.LocationName;
                txtIngredient_LVL.Text = i.LocationLevel.ToString();
                txtIngredient_Node.Text = i.LocationLocale;
                txtIngredient_iLVL.Text = i.ItemLevel.ToString();
                txtIngredient_Coordinates.Text = i.Coordinates;

                if (i.Cooking == true)
                {
                    chkIngredients_Cooking.IsChecked = true;
                }
                if (i.Fishing == true)
                {
                    chkIngredients_Fishing.IsChecked = true;
                }
                if (i.MobDrop == true)
                {
                    chkIngredients_Mob.IsChecked = true;
                }
                if (i.Vendor == true)
                {
                    chkIngredients_Vendor.IsChecked = true;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Could not load recipe information.");
            }


            
        }

        private void btnIngredients_OK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
