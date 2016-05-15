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
    /// Interaction logic for AssignOrder.xaml
    /// </summary>
    public partial class AssignOrder : MetroWindow
    {
        private CookManager _myCookManager = new CookManager();
        private OrderManager _myOrderManager = new OrderManager();
        private Order _o = new Order();
        private List<Cook> cooks = new List<Cook>();

        public AssignOrder(Order o)
        {
            InitializeComponent();

            _o = o;
        }

        private void cmbCooks_Loaded(object sender, RoutedEventArgs e)
        {
            cooks = _myCookManager.GetCookList(true);
            var cookNames = from Cook c in cooks
                            select c.FirstName + " " + c.LastName;

            List < String > recipeNames = new List<String>();

            try
            {
                var comboBox = sender as ComboBox;
                comboBox.ItemsSource = cookNames;

                var index = cooks.FindIndex(a => a.CookID == _o.CookID);
                comboBox.SelectedIndex = index;
            }
            catch (Exception)
            {
                MessageBox.Show("Could not populate recipe selection box.");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAssign_Click(object sender, RoutedEventArgs e)
        {

            var index = cmbCooks.SelectedIndex;
            var cook = cooks[index];

            _o.CookID = cook.CookID;

            if(_myOrderManager.EditOrder(_o) == true)
            {
                MessageBox.Show("Order assigned!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Could not assign. Try again.");
            }
        }
    }
}
