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
    /// Interaction logic for EditCook.xaml
    /// </summary>
    public partial class EditCook : MetroWindow
    {
        private CookManager _myCookManager = new CookManager();
        private Cook _c = new Cook();

        public EditCook(Cook c)
        {
            _c = c;

            InitializeComponent();
            txtEditCook_FirstName.Text = _c.FirstName;
            txtEditCook_LastName.Text = _c.LastName;
            txtEditCook_LocalPhone.Text = _c.LocalPhone;
            txtEditCook_EmailAddress.Text = _c.EmailAddress;
        }

        private void btnEditCook_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEditCook_Confirm_Click(object sender, RoutedEventArgs e)
        {
            string message = null;

            try
            {
                _c.FirstName = txtEditCook_FirstName.Text;
                _c.LastName = txtEditCook_LastName.Text;

                if (String.IsNullOrWhiteSpace(_c.FirstName) || String.IsNullOrWhiteSpace(_c.LastName) || (Validators.IsPhoneNumber(_c.LocalPhone) == false) || (Validators.IsValidEmail(_c.EmailAddress) == false))
                {
                    if (Validators.IsValidEmail(_c.EmailAddress) == false)
                    {
                        message = "Please fill out all fields correctly. Enter a valid e-mail address.";
                        MessageBox.Show(message);
                    }
                    else if (Validators.IsPhoneNumber(_c.LocalPhone) == false)
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
                    _c.FirstName = txtEditCook_FirstName.Text;
                    _c.LastName = txtEditCook_LastName.Text;
                    _c.LocalPhone = txtEditCook_LocalPhone.Text;
                    _c.EmailAddress = txtEditCook_EmailAddress.Text;
                    _c.UserName = _c.FirstName.ToLower() + _c.LastName.ToLower();

                    if(_myCookManager.EditCook(_c) == true)
                    {
                        MessageBox.Show("Success! " + _c.FirstName + " " + _c.LastName + " was edited successfully.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Edit could not be completed. Please try again.");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            this.Close();
        }
    }
}
