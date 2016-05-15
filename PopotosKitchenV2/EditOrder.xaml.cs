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
    /// Interaction logic for EditOrder.xaml
    /// </summary>
    public partial class EditOrder : MetroWindow
    {
        private OrderManager _myOrderManager = new OrderManager();
        private Order _order = new Order();
        private AccessToken _aToken = new AccessToken();
        
        public EditOrder(Order order, AccessToken aToken)
        {
            InitializeComponent();
            _order = order;
            _aToken = aToken;
            pnlEditOrder_Completed.IsEnabled = false;
        }

        private void btnEditOrder_CancelChanges_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(_order.OrderID.ToString()))
            {
                MessageBox.Show("Please select an order to edit.");
            }
            else
            {
                //MessageBox.Show(_order.Active.ToString());

                txtEditOrder_OrderID.Text = _order.OrderID.ToString();
                txtEditOrder_CustomerID.Text = _order.CustomerID.ToString();

                foreach(var r in _aToken.Roles)
                {
                    if (r.RoleID == "Chef Popoto")
                    {
                        pnlEditOrder_Completed.IsEnabled = true;
                    }
                }

                if (_order.Paid == true)
                    radEditOrder_PaidYes.IsChecked = true;
                else
                    radEditOrder_PaidNo.IsChecked = true;
                if (_order.Traded == true)
                    radEditOrder_TradedYes.IsChecked = true;
                else
                    radEditOrder_TradedNo.IsChecked = true;
                if (_order.Completed == true)
                    radCompleted_Yes.IsChecked = true;
                else
                    radCompleted_No.IsChecked = true;

                dateEditOrder_Date.SelectedDate = _order.OrderDate;
            }

        }

        private void btnEditOrder_ConfirmChanges_Click(object sender, RoutedEventArgs e)
        {
            int customerID = 0;
            Order newOrder = new Order();

            if ((Int32.TryParse(txtEditOrder_CustomerID.Text, out customerID)) && (dateEditOrder_Date != null))
            {
                newOrder.OrderID = _order.OrderID;
                newOrder.CustomerID = customerID;
                newOrder.CookID = _order.CookID;
                newOrder.OrderDate = (DateTime)dateEditOrder_Date.SelectedDate;
                newOrder.Active = _order.Active;

                if(radEditOrder_PaidYes.IsChecked == true && radEditOrder_PaidNo.IsChecked == false)
                {
                    newOrder.Paid = true;
                }
                else if(radEditOrder_PaidNo.IsChecked == true && radEditOrder_PaidYes.IsChecked == false)
                {
                    newOrder.Paid = false;
                }

                if (radEditOrder_TradedYes.IsChecked == true && radEditOrder_TradedNo.IsChecked == false)
                {
                    newOrder.Traded = true;
                }
                else if (radEditOrder_TradedNo.IsChecked == true && radEditOrder_TradedYes.IsChecked == false)
                {
                    newOrder.Traded = false;
                }
                if(radCompleted_No.IsChecked == true && radCompleted_Yes.IsChecked == false)
                {
                    newOrder.Completed = false;
                }
                else if (radCompleted_Yes.IsChecked == true && radCompleted_No.IsChecked == false)
                {
                    newOrder.Completed = true;
                    newOrder.DateCompleted = DateTime.Now;
                }

                try
                {
                    if (_myOrderManager.EditOrder(newOrder) == true)
                        MessageBox.Show("Successfully updated order.");

                    //MessageBox.Show(newOrder.OrderID.ToString() + newOrder.CustomerID.ToString() + newOrder.CookID.ToString() + newOrder.OrderDate.ToString() +
                                    //newOrder.Completed.ToString() + newOrder.Paid.ToString() + newOrder.Traded.ToString() + newOrder.Active.ToString());
                    this.Close();
                }
                catch (Exception)
                {
                    //MessageBox.Show("Could not edit order. Please try again.");
                    throw;
                }
            }
            else
                MessageBox.Show("Please enter numeric values.");


            
        }
    }
}
