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
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : MetroWindow
    {
        private CustomerManager _myCustomerManager;
        private Customer _customer;

        public EditCustomer(CustomerManager customerManager, Customer cust)
        {
            InitializeComponent();
            _myCustomerManager = customerManager;
            _customer = cust;


        }

        private void btnEditCustomer_CancelChanges_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            lblEditCustomer_CustomerIDField.Content = _customer.CustomerID;
            txtEditCustomer_FirstName.Text = _customer.FirstName;
            txtEditCustomer_LastName.Text = _customer.LastName;
            txtEditCustomer_EmailAddress.Text = _customer.EmailAddress;
            txtEditCustomer_LocalPhone.Text = _customer.LocalPhone;
            txtEditCustomer_FreeCompany.Text = _customer.FreeCompany;
        }

        private void btnEditCustomer_ConfirmChanges_Click(object sender, RoutedEventArgs e)
        {
            string message = null;

            try
            {
                _customer.FirstName = txtEditCustomer_FirstName.Text;
                _customer.LastName = txtEditCustomer_LastName.Text;
                _customer.EmailAddress = txtEditCustomer_EmailAddress.Text;
                _customer.LocalPhone = txtEditCustomer_LocalPhone.Text;
                _customer.FreeCompany = txtEditCustomer_FreeCompany.Text;

                if (String.IsNullOrWhiteSpace(_customer.FirstName) || String.IsNullOrWhiteSpace(_customer.LastName) || (Validators.IsPhoneNumber(_customer.LocalPhone) == false) || (Validators.IsValidEmail(_customer.EmailAddress) == false) || String.IsNullOrWhiteSpace(_customer.FreeCompany))
                {
                    if (Validators.IsValidEmail(_customer.EmailAddress) == false)
                    {
                        message = "Please fill out all fields correctly. Enter a valid e-mail address.";
                        MessageBox.Show(message);
                    }
                    else if (Validators.IsPhoneNumber(_customer.LocalPhone) == false)
                    {
                        message = "Please fill out all fields correctly. Enter a valid phone number.";
                        MessageBox.Show(message);
                    }
                    else
                    {
                        message = "Please fill out all fields.";
                        MessageBox.Show(message);
                    }
                }
                else
                {
                    if (_myCustomerManager.EditCustomer(_customer) == true)
                    {
                        message = "Success! " + _customer.FirstName + " " + _customer.LastName + " has been edited successfully.";
                        MessageBox.Show(message);
                        this.Close();
                    }
                    else
                    {
                        message = "Could not edit customer. Please try again.";
                        MessageBox.Show(message);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
