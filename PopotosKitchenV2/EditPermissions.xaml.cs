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
    /// Interaction logic for EditPermissions.xaml
    /// </summary>
    public partial class EditPermissions : MetroWindow
    {
        private Cook _c = new Cook();
        private CookManager _myCookManager = new CookManager();

        public EditPermissions(Cook c)
        {
            InitializeComponent();
            _c = c;
        }

        private void btnPermission_confirm_Click(object sender, RoutedEventArgs e)
        {
            Assignment a = new Assignment();
            a.Active = true;
            
            if(radPermission_Chef.IsChecked == true)
            {
                a.RoleID = "Chef Popoto";
            }
            else if(radPermission_Sous.IsChecked == true)
            {
                a.RoleID = "Sous Popoto";
            }
            else
            {
                a.RoleID = "Popoto";
            }

            try
            {
                if (_myCookManager.AddCookPermission(_c, a))
                {
                    MessageBox.Show("Success! Permission changed.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Permission could not be added. Please contact your administrator.");
                    
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
