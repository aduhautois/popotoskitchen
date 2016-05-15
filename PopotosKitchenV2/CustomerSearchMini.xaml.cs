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
    /// Interaction logic for CustomerSearchMini.xaml
    /// </summary>
    public partial class CustomerSearchMini : MetroWindow
    {
        CustomerManager myCustomerManager = new CustomerManager();
        private int _customerID = 0;

        public int customerID
        {
            get { return _customerID; }
            set { _customerID = customerID; }
        }

        public CustomerSearchMini()
        {
            InitializeComponent();
            btnCustomerSearchWindow_SelectCustomer.IsEnabled = false;
        }

        private void btnCustomerSearchWindow_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnCustomerSearchWindow_ViewAllCustomers_Click(object sender, RoutedEventArgs e)
        {
            int active = 1;
            try
            {
                var customers = myCustomerManager.GetCustomerList(active);
                gridCustomerSearchWindow_CustomerSearchResults.ItemsSource = customers;
            }
            catch (Exception)
            {
                gridCustomerSearchWindow_CustomerSearchResults.ItemsSource = null;
                MessageBox.Show("No records have been found.");
            }
        }

        private void btnCustmerSearchWindow_SearchCustomers_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = txtCustomerSearchWindow_SearchCriteria.Text;
            int active = 1;

            if (cmbxitmCustomerSearchWindow_All.IsSelected)
            {
                try
                {
                    var customers = myCustomerManager.GetCustomerList_SearchAll(searchTerm, active);
                    gridCustomerSearchWindow_CustomerSearchResults.ItemsSource = customers;
                }
                catch (Exception)
                {
                    gridCustomerSearchWindow_CustomerSearchResults.ItemsSource = null;
                    MessageBox.Show("No records have been found.");
                }
            }
            else if (cmbxitmCustomerSearchWindow_CustomerID.IsSelected)
            {
                int testSearchTerm = 0;
                if (Int32.TryParse(searchTerm, out testSearchTerm))
                {

                    try
                    {
                        var customers = myCustomerManager.GetCustomerList_SearchCustomerID(searchTerm, active);
                        gridCustomerSearchWindow_CustomerSearchResults.ItemsSource = customers;
                    }
                    catch (Exception)
                    {
                        gridCustomerSearchWindow_CustomerSearchResults.ItemsSource = null;
                        MessageBox.Show("No records have been found.");
                    }
                }
                else
                    MessageBox.Show("Please enter only numeric values.");


            }
            
            else if (cmbxitmCustomerSearchWindow_Name.IsSelected)
            {
                try
                {
                    var customers = myCustomerManager.GetCustomerList_SearchName(searchTerm, active);
                    gridCustomerSearchWindow_CustomerSearchResults.ItemsSource = customers;
                }
                catch (Exception)
                {
                    gridCustomerSearchWindow_CustomerSearchResults.ItemsSource = null;
                    MessageBox.Show("No records have been found.");
                }
            }
            else if (cmbxitmCustomerSearchWindow_FreeCompany.IsSelected)
            {
                try
                {
                    var customers = myCustomerManager.GetCustomerList_SearchFreeCompany(searchTerm, active);
                    gridCustomerSearchWindow_CustomerSearchResults.ItemsSource = customers;
                }
                catch (Exception)
                {
                    gridCustomerSearchWindow_CustomerSearchResults.ItemsSource = null;
                    MessageBox.Show("No records have been found.");
                }
            }
        }

        private void btnCustomerSearchWindow_SelectCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = (Customer)gridCustomerSearchWindow_CustomerSearchResults.SelectedItem;
            
            if(customer != null)
            {
                _customerID = customer.CustomerID;
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a customer.");
            }
        }

        private void gridCustomerSearchWindow_CustomerSearchResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnCustomerSearchWindow_SelectCustomer.IsEnabled = true;
        }
    }
}
