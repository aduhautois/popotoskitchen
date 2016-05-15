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
    /// Interaction logic for CookOrderLines.xaml
    /// </summary>
    public partial class CookOrderLines : MetroWindow
    {
        private OrderManager _myOrderManager = new OrderManager();
        private Order _o = new Order();

        public CookOrderLines(Order o)
        {
            InitializeComponent();
            _o = o;
            OrderLine oL = new OrderLine();
            oL.OrderID = _o.OrderID;
            btnCompleteRecipe.IsEnabled = false;

            try
            {
                var recipeList = _myOrderManager.SelectOrderLines_CurrentOrder(oL, true);

                var recipeListFiltered = from OrderLine oh in recipeList
                                         where oh.Completed == false
                                         select oh;

                gridRecipes.ItemsSource = recipeListFiltered;
            }
            catch (Exception)
            {

                throw;
            }

            
        }

        private void gridRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnCompleteRecipe.IsEnabled = true;

            var o = (OrderLine)gridRecipes.SelectedItem;

            string imageString = @"Resources/" + o.RecipeID.ToString() + ".png";
            string muffinString = @"Resources/Isghardian Muffin.png";

            BitmapImage image = new BitmapImage(new Uri(imageString, UriKind.Relative));
            imgRecipes.Source = image;

            if (o.RecipeID == "Ishgardian Muffin")
            {
                BitmapImage muffin = new BitmapImage(new Uri(muffinString, UriKind.Relative));
                imgRecipes.Source = image;
            }
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCompleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            var o = (OrderLine)gridRecipes.SelectedItem;
            o.Completed = true;
            o.DateCompleted = DateTime.Now;

            if(o != null)
            {
                try
                {
                    if(_myOrderManager.EditOrderLine(o))
                    {
                        MessageBox.Show("Success! Recipe completed.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Recipe could not be completed. Please try again.");
                }
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
