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
    /// Interaction logic for EditOrderLines.xaml
    /// </summary>
    public partial class EditOrderLines : MetroWindow
    {
        private OrderManager _myOrderManager = new OrderManager();
        private AccessToken _aToken = new AccessToken();

        private Order _order = new Order();
        private OrderLine _orderLine = new OrderLine();
        private List<OrderLine> _orderLines = new List<OrderLine>();
        private List<OrderLine> _deletedLines = new List<OrderLine>();
        private int _orderID = 0;

        public EditOrderLines(Order order, AccessToken aToken)
        {
            InitializeComponent();
            _order = order;
            _orderLine.OrderID = _order.OrderID;
            _orderID = _order.OrderID;

            _aToken = aToken;

            try
            {
                refreshOrderGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not populate grid.");
            }
            try
            {
                refreshDeleteGrid();
            }
            catch (Exception)
            {
                
            }

        }

        private void btnEditOrderLines_EditLine_Click(object sender, RoutedEventArgs e)
        {
            int index = gridEditOrderLines_OrderLineList.SelectedIndex;
            var orderLine = (OrderLine)gridEditOrderLines_OrderLineList.SelectedItem;

            if(orderLine != null)
            {
                var editRecipe = new RecipeInformation(orderLine, _aToken);
                editRecipe.cmbRecipeInfo_ChooseRecipe.IsEnabled = false;
                if (editRecipe.ShowDialog() == true)
                {
                    orderLine.Price = editRecipe.newOrderLine.Price;
                    orderLine.Quantity = editRecipe.newOrderLine.Quantity;
                    orderLine.Active = true;

                    try
                    {
                        _myOrderManager.EditOrderLine(orderLine);
                        MessageBox.Show("Success! Line edited.");
                        refreshOrderGrid();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Please try again.");
                    }
                }

                editRecipe.cmbRecipeInfo_ChooseRecipe.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Please select a line.");
            }
            
        }

        private void btnEditOrderLines_CancelChanges_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEditOrderLines_DeleteLine_Click(object sender, RoutedEventArgs e)
        {
            var orderLine = (OrderLine)gridEditOrderLines_OrderLineList.SelectedItem;

            if(orderLine != null)
            {
                orderLine.Active = false;

                try
                {
                    if (_myOrderManager.DeleteOrderLine(orderLine))
                    {
                        MessageBox.Show("Success! Line deleted.");
                        refreshDeleteGrid();
                        refreshOrderGrid();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Could not delete order. Try again.");
                }

                refreshOrderGrid();
                refreshDeleteGrid();
            }
            else
            {
                MessageBox.Show("Please select a line.");
            }

        }

        private void refreshOrderGrid()
        {
            try
            {
                _orderLines = _myOrderManager.SelectOrderLines_CurrentOrderByID(_orderID);
                gridEditOrderLines_OrderLineList.ItemsSource = null;
                gridEditOrderLines_OrderLineList.ItemsSource = _orderLines;
            }
            catch (Exception)
            {

                gridEditOrderLines_OrderLineList.ItemsSource = null;
            }
        }

        private void refreshDeleteGrid()
        {
            try
            {
                _deletedLines = _myOrderManager.SelectOrderLines_CurrentOrder(_orderLine, false);
                gridEditOrderLines_DeletedLines.ItemsSource = null;
                gridEditOrderLines_DeletedLines.ItemsSource = _deletedLines;
            }
            catch (Exception)
            {
                gridEditOrderLines_DeletedLines.ItemsSource = null;
            } 
        }

        private void btnEditOrderLines_UndeleteLine_Click(object sender, RoutedEventArgs e)
        {
            var orderLine = (OrderLine)gridEditOrderLines_DeletedLines.SelectedItem;

            if(orderLine != null)
            {
                orderLine.Active = true;
                try
                {
                    if (_myOrderManager.EditOrderLine(orderLine))
                    {
                        MessageBox.Show("Success! Line re-added.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Line could not be re-added. Please try again.");
                }

                refreshOrderGrid();
                refreshDeleteGrid();
            }
            else
            {
                MessageBox.Show("Please select a line.");
            }
            
        }

        private void btnEditOrderLines_ConfirmChanges_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEditOrderLines_AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            var orderLine = new OrderLine();
            var addRecipe = new RecipeInformation(orderLine, _aToken);
            if(addRecipe.ShowDialog() == true)
            {
                orderLine.OrderID = _orderID;
                orderLine.RecipeID = addRecipe.newOrderLine.RecipeID;
                orderLine.Price = addRecipe.newOrderLine.Price;
                orderLine.Quantity = addRecipe.newOrderLine.Quantity;

                try
                {
                    if (_myOrderManager.AddOrderLine(orderLine))
                    {
                        MessageBox.Show("Success! Line added.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Could not add recipe. Please try again.");
                }

                refreshDeleteGrid();
                refreshOrderGrid();
            }
        }
    }
}
