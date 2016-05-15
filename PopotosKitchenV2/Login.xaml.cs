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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        static AccessToken _accessToken;

        public Login()
        {
            InitializeComponent();
            lblLoginConfirmPassword.Visibility = Visibility.Hidden;
            txtLoginConfirmPassword.Visibility = Visibility.Hidden;
        }

        private void btnLoginCancel_Click(object sender, RoutedEventArgs e)
        {
            _accessToken = null;
            Close();
        }

        private void chkNewUser_Checked(object sender, RoutedEventArgs e)
        {
            lblLoginConfirmPassword.Visibility = Visibility.Visible;
            txtLoginConfirmPassword.Visibility = Visibility.Visible;
            lblLoginPassword.Content = "Choose password:";
        }

        private void chkNewUser_Unchecked(object sender, RoutedEventArgs e)
        {
            lblLoginConfirmPassword.Visibility = Visibility.Hidden;
            txtLoginConfirmPassword.Visibility = Visibility.Hidden;
            lblLoginPassword.Content = "Password:";
        }

        private void btnLoginYes_Click(object sender, RoutedEventArgs e)
        {
            string username = this.txtLoginUsername.Text;
            string password = this.txtLoginPassword.Password;
            string passConfirm = this.txtLoginConfirmPassword.Password;

            try
            {               
                if (this.chkNewUser.IsChecked == true)
                {
                    if (password != passConfirm)
                    {
                        throw new ApplicationException("Passwords must match!");
                    }
                    _accessToken = SecurityManager.ValidateNewUser(username, password);
                    this.DialogResult = true;
                }
                else
                {
                    _accessToken = SecurityManager.ValidateExistingUser(username, password);
                    this.DialogResult = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public delegate void AccessTokenCreatedEventHandler(object sender, AccessToken a);

        public event AccessTokenCreatedEventHandler AccessTokenCreatedEvent;
        protected virtual void RaiseAccessTokenCreatedEvent()  // we need a method to raise the event
        {
            // Raise the event
            if (AccessTokenCreatedEvent != null)  // if there are subscribers/listeners/handlers
                AccessTokenCreatedEvent(this, _accessToken); // go ahead and raise the event
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_accessToken != null)  // don't raise the event if no one logged in
            {
                RaiseAccessTokenCreatedEvent();
            }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.txtLoginUsername.Focus();
        }
    }
}
