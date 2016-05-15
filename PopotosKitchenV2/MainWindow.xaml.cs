using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Windows.Threading;
using BusinessObjects;
using BusinessLogic;
using System.Globalization;

namespace PopotosKitchenV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private CustomerManager myCustomerManager = new CustomerManager();
        private OrderManager myOrderManager = new OrderManager();
        private RecipeManager myRecipeManager = new RecipeManager();
        private CookManager myCookManager = new CookManager();
        AccessToken _accessToken = new AccessToken();
        Login _login;

        private List<Customer> customerList = new List<Customer>();
        private List<Customer> customerArchiveList = new List<Customer>();
        private List<Order> orderList = new List<Order>();
        private List<OrderLine> orderLineList = new List<OrderLine>();
        private List<Order> orderArchiveList = new List<Order>();
        private List<RecipeIngredient> recipeIngredientList = new List<RecipeIngredient>();
        private List<RecipeCatalyst> recipeCatalystList = new List<RecipeCatalyst>();
        private List<Cook> cookList = new List<Cook>();
        private List<Cook> cookArchiveList = new List<Cook>();
        private List<Message> messageList = new List<Message>();
        private List<Order> cookOrderList = new List<Order>();

        private Recipe r = new Recipe();

        private int userMind = 0;
        private int userAcc = 0;
        private int userCrit = 0;
        private int userDet = 0;
        private int userSpell = 0;
        private int userVit = 0;
        private int userPie = 0;
        private int userDex = 0;
        private int userStr = 0;
        private int userInt = 0;
        private int userPar = 0;
        private int userSkill = 0;
        private const int MAXSTAT = 1000;

        public MainWindow()
        {

            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.lblStatusDate.Content = DateTime.Now.ToString();
            }, this.Dispatcher);

            btnCustomer_EditCustomer.IsEnabled = false;
            btnCustomer_DeleteCustomer.IsEnabled = false;
            btnCustomerArchive_DeleteCustomer.IsEnabled = false;
            btnCustomerArchive_EditCustomer.IsEnabled = false;
            btnCustomerArchive_ReactivateCustomer.IsEnabled = false;
            dateOrderSearchStart.IsEnabled = false;
            dateOrderSearchEnd.IsEnabled = false;
            cmbNewOrder_SearchRecipe.IsEnabled = false;
            txtNewOrder_RecipeQuantity.IsEnabled = false;
            btnNewOrder_CreateOrder.IsEnabled = false;
            txtNewOrder_Price.IsEnabled = false;
            btnEditOrder.IsEnabled = false;
            btnDeleteOrder.IsEnabled = false;
            btnEditItems.IsEnabled = false;
            gridStatCalculator.Visibility = Visibility.Collapsed;
            btnStats_ResetStats.IsEnabled = false;
            btnStats_ClearStats.IsEnabled = false;
            btnViewIngredientDetails.IsEnabled = false;
            btnCook_EditCook.IsEnabled = false;
            btnCook_DeleteCook.IsEnabled = false;
            btnCook_SendMessage.IsEnabled = false;
            btnMessage_Delete.IsEnabled = false;
            btnMessage_Read.IsEnabled = false;
            btnAssignOrders.IsEnabled = false;
            btnKitchenOrder_CookItems.IsEnabled = false;
            btnKitchenOrder_MarkCompleted.IsEnabled = false;
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            closeDialog();
        }

        private void closeDialog()
        {
            string yesNoMessageText = "Do you really want to exit?";
            string caption = "POPOTO'S KITCHEN";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult rsltMessageBox = MessageBox.Show(yesNoMessageText, caption, btnMessageBox, icnMessageBox);

            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
                case MessageBoxResult.No:

                    break;

            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (_accessToken == null)
            {
                _login = new Login();
                _login.AccessTokenCreatedEvent += setAccessToken;  // subscribe a listener to the login event

                if (_login.ShowDialog() == true && _accessToken != null && myCookManager.LogCookLogin(_accessToken.CookID) == true)  // login succeeded
                {
                    // initialize the form
                    // MessageBox.Show(_accessToken.FirstName + " has logged in.");
                    this.lblStatusMessage.Content = _accessToken.FirstName + " " + _accessToken.LastName + " is logged in.";
                    foreach (var r in _accessToken.Roles)
                    {
                        if (r.RoleID == "Chef Popoto")
                        {
                            this.tabCooks.Visibility = Visibility.Visible;
                            this.tabCustomers.Visibility = Visibility.Visible;
                            this.tabMyInfo.Visibility = Visibility.Visible;
                            this.tabOrders.Visibility = Visibility.Visible;
                            this.tabRecipes.Visibility = Visibility.Visible;
                            this.tabOrderArchive.Visibility = Visibility.Visible;
                            this.tabCustomerArchive.Visibility = Visibility.Visible;
                            this.tabHome.Focus();
                        }
                        else if (r.RoleID == "Sous Popoto")
                        {
                            this.tabCustomers.Visibility = Visibility.Visible;
                            this.tabMyInfo.Visibility = Visibility.Visible;
                            this.tabOrders.Visibility = Visibility.Visible;
                            this.tabRecipes.Visibility = Visibility.Visible;
                            this.tabHome.Focus();
                        }
                        else if(r.RoleID == "Popoto")
                        {
                            this.tabMyInfo.Visibility = Visibility.Visible;
                            this.tabRecipes.Visibility = Visibility.Visible;
                            this.tabHome.Focus();
                        }

                        txtHomeMessage.Text = "Welcome, " + _accessToken.FirstName + "!";
                        txtHomeDetails.Text = "Please navigate using the above tabs to complete your daily tasks. Check My Kitchen to complete orders or view messages from the Chef and please contact your administrator if you have any questions. Thank you for using Popoto's Kitchen!";
                    }
                    this.btnLogin.Content = "Log Out";

                    loadMessages(_accessToken.CookID);
                    loadOrders(_accessToken.CookID);
                }
                else
                {
                    // clear the access token reference to null and updata status bar
                    _accessToken = null;
                    MessageBox.Show("Login failed.");
                }
            }
            else // someone is already logged in
            {
                _accessToken = null;
                this.tabCooks.Visibility = Visibility.Collapsed;
                this.tabCustomers.Visibility = Visibility.Collapsed;
                this.tabMyInfo.Visibility = Visibility.Collapsed;
                this.tabOrders.Visibility = Visibility.Collapsed;
                this.tabRecipes.Visibility = Visibility.Collapsed;
                this.tabOrderArchive.Visibility = Visibility.Collapsed;
                this.tabCustomerArchive.Visibility = Visibility.Collapsed;
                this.lblStatusMessage.Content = "You are not logged in.";
                this.btnLogin.Content = "Log In";
                this.tabHome.Focus();

                txtHomeMessage.Text = "Welcome to Popoto's Kitchen! Please log in to continue.";
                txtHomeDetails.Text = " ";

                gridMessageGrid.ItemsSource = null;
                gridKitchenOrders.ItemsSource = null;
            }

        }

        private void setAccessToken(object sender, AccessToken at)  // this is a listener for a login event
        {
            if (sender == _login)
            {
                this._accessToken = at;
            }
        }

        private void btnEditOrder_Click(object sender, RoutedEventArgs e)
        {
            var order = (Order)gridOrderSearchResults.SelectedItem;
            
            if(order != null)
            {
                var editOrder = new EditOrder(order,_accessToken);
                editOrder.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an order.");
            }
        }

        private void btnNewCustomer_Clear_Click(object sender, RoutedEventArgs e)
        {
            txtNewCustomer_FirstName.Clear();
            txtNewCustomer_LastName.Clear();
            txtNewCustomer_LocalPhone.Clear();
            txtNewCustomer_EmailAddress.Clear();
            txtNewCustomer_FreeCompany.Clear();
        }

        private void btnNewCustomer_Create_Click(object sender, RoutedEventArgs e)
        {
            string message = null;

            var customer = new Customer();
            customer.FirstName = txtNewCustomer_FirstName.Text;
            customer.LastName = txtNewCustomer_LastName.Text;
            customer.LocalPhone = txtNewCustomer_LocalPhone.Text;
            customer.EmailAddress = txtNewCustomer_EmailAddress.Text;
            customer.FreeCompany = txtNewCustomer_FreeCompany.Text;

            try
            {
                if (String.IsNullOrWhiteSpace(customer.FirstName) || String.IsNullOrWhiteSpace(customer.LastName) || (Validators.IsPhoneNumber(customer.LocalPhone) == false) || (Validators.IsValidEmail(customer.EmailAddress) == false) || String.IsNullOrWhiteSpace(customer.FreeCompany))
                {
                    if (Validators.IsValidEmail(customer.EmailAddress) == false)
                    {
                        message = "Please fill out all fields correctly. Enter a valid e-mail address.";
                        MessageBox.Show(message);
                    }
                    else if (Validators.IsPhoneNumber(customer.LocalPhone) == false)
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
                    if (myCustomerManager.AddNewCustomer(customer))
                    {
                        message = "Success! " + customer.FirstName + " " + customer.LastName + " has been added to the database.";
                        MessageBox.Show(message);
                        refreshCustomerGrid();
                    }
                    else
                    {
                        message = "Could not add customer. Please try again.";
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

        private void btnCustomer_SearchCustomers_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = txtCustomer_SearchCriteria.Text;
            int active = 1;

            if (cmbxitmCustomer_All.IsSelected)
            {
                try
                {
                    customerList = myCustomerManager.GetCustomerList_SearchAll(searchTerm, active);
                    refreshCustomerGrid();
                }
                catch (Exception)
                {
                    MessageBox.Show("No records have been found.");
                }
            }
            else if (cmbxitmCustomer_CustomerID.IsSelected)
            {
                int testSearchTerm = 0;
                if (Int32.TryParse(searchTerm, out testSearchTerm))
                {

                    try
                    {
                        customerList = myCustomerManager.GetCustomerList_SearchCustomerID(searchTerm, active);
                        refreshCustomerGrid();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No records have been found.");
                    }
                }
                else
                    MessageBox.Show("Please enter only numeric values.");


            }
            else if (cmbxitmCustomer_Name.IsSelected)
            {
                try
                {
                    customerList = myCustomerManager.GetCustomerList_SearchName(searchTerm, active);
                    refreshCustomerGrid();
                }
                catch (Exception)
                {
                    MessageBox.Show("No records have been found.");
                }
            }
            else if (cmbxitmCustomer_FreeCompany.IsSelected)
            {
                try
                {
                    customerList = myCustomerManager.GetCustomerList_SearchFreeCompany(searchTerm, active);
                    refreshCustomerGrid();
                }
                catch (Exception)
                {
                    MessageBox.Show("No records have been found.");
                }
            }

        }

        private void btnCustomer_ViewAllCustomers_Click(object sender, RoutedEventArgs e)
        {
            int active = 1;
            txtCustomer_SearchCriteria.Clear();

            try
            {
                customerList = myCustomerManager.GetCustomerList(active);
                refreshCustomerGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("No records have been found.");
            }
        }

        private void btnCustomer_EditCustomer_Click(object sender, RoutedEventArgs e)
        {
            var selectedCustomer = (Customer)gridCustomer_CustomerSearchResults.SelectedItem;

            if(selectedCustomer != null)
            {
                var customerWindow = new EditCustomer(myCustomerManager, selectedCustomer);
                customerWindow.ShowDialog();

                refreshCustomerGrid();
            }
            else
            {
                MessageBox.Show("Please select a customer.");
            }
        }

        private void gridCustomer_CustomerSearchResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnCustomer_EditCustomer.IsEnabled = true;
            btnCustomer_DeleteCustomer.IsEnabled = true;
        }

        private void btnCustomer_DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            var selectedCustomer = (Customer)gridCustomer_CustomerSearchResults.SelectedItem;

            if(selectedCustomer != null)
            {
                if (String.IsNullOrWhiteSpace(selectedCustomer.FirstName.ToString()))
                {
                    MessageBox.Show("Could not delete. Please try again.");
                }
                else
                {
                    string yesNoMessageText = "Do you really want to delete " + selectedCustomer.FirstName + " " + selectedCustomer.LastName + "?";
                    string caption = "Selected customer will be disabled. Only an admin may permanently delete records from the database.";

                    MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
                    MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                    MessageBoxResult rsltMessageBox = MessageBox.Show(yesNoMessageText, caption, btnMessageBox, icnMessageBox);

                    switch (rsltMessageBox)
                    {
                        case MessageBoxResult.Yes:
                            if (myCustomerManager.DeleteCustomer(selectedCustomer))
                            {
                                MessageBox.Show("Success!");
                                refreshCustomerGrid();
                            }
                            break;
                        case MessageBoxResult.No:
                            this.Close();
                            break;

                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer.");
            }


        }

        private void btnCustomerArchive_ViewAllCustomers_Click(object sender, RoutedEventArgs e)
        {
            int active = 0;
            txtCustomerArchive_SearchCriteria.Clear();

            try
            {
                customerArchiveList = myCustomerManager.GetCustomerList(active);
                refreshCustomerArchiveGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("No records have been found.");
            }
        }

        private void btnCustomerArchive_SearchCustomers_Click(object sender, RoutedEventArgs e)
        {
            int active = 0;
            string searchTerm = txtCustomerArchive_SearchCriteria.Text;
            try
            {
                customerArchiveList = myCustomerManager.GetCustomerList_SearchAll(searchTerm, active);
                refreshCustomerArchiveGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("No records have been found.");
            }
        }

        private void gridCustomerArchive_CustomerSearchResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnCustomerArchive_DeleteCustomer.IsEnabled = true;
            btnCustomerArchive_EditCustomer.IsEnabled = true;
            btnCustomerArchive_ReactivateCustomer.IsEnabled = true;
        }

        private void btnCustomerArchive_EditCustomer_Click(object sender, RoutedEventArgs e)
        {
            var selectedCustomer = (Customer)gridCustomerArchive_CustomerSearchResults.SelectedItem;

            if(selectedCustomer != null)
            {
                var customerWindow = new EditCustomer(myCustomerManager, selectedCustomer);
                customerWindow.ShowDialog();

                DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                {
                    refreshCustomerArchiveGrid();
                }, this.Dispatcher);
            }
            else
            {
                MessageBox.Show("Please select a customer.");
            }

        }

        private void btnCustomerArchive_DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            int customerID = 0;

            var selectedCustomer = (Customer)gridCustomerArchive_CustomerSearchResults.SelectedItem;

            if(selectedCustomer != null)
            {

                customerID = selectedCustomer.CustomerID;

                string yesNoMessageText = "Do you really want to permanently delete " + selectedCustomer.FirstName + " " + selectedCustomer.LastName + "?";
                string caption = "Selected customer will be deleted from the database and a record will be kept of the deletion.";

                MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
                MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                MessageBoxResult rsltMessageBox = MessageBox.Show(yesNoMessageText, caption, btnMessageBox, icnMessageBox);

                switch (rsltMessageBox)
                {
                    case MessageBoxResult.Yes:
                        if (myCustomerManager.AdminSaveDeletedCustomer(selectedCustomer))
                        {
                            if (myCustomerManager.AdminDeleteCustomer(customerID))
                            {
                                MessageBox.Show("Success!");
                                refreshCustomerArchiveGrid();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong. Please try again.");
                        }

                        break;
                    case MessageBoxResult.No:
                        this.Close();
                        break;

                }
            }
            else
            {
                MessageBox.Show("Please select a customer.");
            }

        }

        private void btnCustomerArchive_ReactivateCustomer_Click(object sender, RoutedEventArgs e)
        {
            int customerID = 0;

            var selectedCustomer = (Customer)gridCustomerArchive_CustomerSearchResults.SelectedItem;

            if(selectedCustomer != null)
            {
                customerID = selectedCustomer.CustomerID;

                string yesNoMessageText = "Reactivate " + selectedCustomer.FirstName + " " + selectedCustomer.LastName + "?";
                string caption = "Selected customer will reactivated and will appear in searches and the customer list.";

                MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
                MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                MessageBoxResult rsltMessageBox = MessageBox.Show(yesNoMessageText, caption, btnMessageBox, icnMessageBox);

                switch (rsltMessageBox)
                {
                    case MessageBoxResult.Yes:
                        if (myCustomerManager.ReactivateCustomer(customerID))
                        {

                            MessageBox.Show("Success!");
                            refreshCustomerArchiveGrid();

                        }
                        else
                        {
                            MessageBox.Show("Something went wrong. Please try again.");
                        }

                        break;
                    case MessageBoxResult.No:
                        break;

                }
            }
            else
            {
                MessageBox.Show("Please select a customer.");
            }

        }

        private void btnSearchOrders_ViewAllOrders_Click(object sender, RoutedEventArgs e)
        {
            bool active = true;
            txtSearchCriteria.Clear();
            chkSearchCompleted.IsChecked = false;
            chkSearchPaid.IsChecked = false;
            chkSearchTraded.IsChecked = false;
            cmbxSearchBy.SelectedIndex = 0;

            try
            {
                orderList = myOrderManager.GetOrderList(active);
                refreshOrderGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("No records found.");
            }
        }

        private void btnNewOrder_NewCustomer_Click(object sender, RoutedEventArgs e)
        {
            var cust = new Customer();
            var customerWindow = new CustomerSearchMini();
            if(customerWindow.ShowDialog()== true)
            {
                cust.CustomerID = customerWindow.customerID;
                txtNewOrder_CustomerID.Text = cust.CustomerID.ToString();
            }
        }

        private void btnNewOrder_BeginOrder_Click(object sender, RoutedEventArgs e)
        {
            var order = new Order();

            try
            {
                string customerID = txtNewOrder_CustomerID.Text;
                int custID = 0;
                string cookID = txtNewOrder_CookID.Text;
                int cook = 0;

                if ((Int32.TryParse(customerID, out custID) == true) && (Int32.TryParse(cookID, out cook) == true) && (custID.ToString().Length < 5) && (cook.ToString().Length < 4) && (datepckNewOrder_Date != null))
                {

                    DateTime orderDate = (DateTime)datepckNewOrder_Date.SelectedDate;
                    order.CustomerID = custID;
                    order.CookID = cook;
                    order.OrderDate = orderDate;

                    if (myOrderManager.AddOrder(order))
                    {
                        MessageBox.Show("Success! Order created. Please add recipes.");

                        if (myOrderManager.SelectLastOrder(order) != 0)
                        {
                            int orderID = myOrderManager.SelectLastOrder(order);
                            txtblkNewOrder_OrderID.Text = orderID.ToString();
                            cmbNewOrder_SearchRecipe.IsEnabled = true;
                            txtNewOrder_RecipeQuantity.IsEnabled = true;
                            btnNewOrder_CreateOrder.IsEnabled = true;
                            txtNewOrder_Price.IsEnabled = true;
                            gridNewOrder_ViewOrder.ItemsSource = null;

                        }
                        else
                        {
                            MessageBox.Show("Could not retrieve order ID. Please try again.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Order failed. Please try again.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter valid numerical values for identification numbers.");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Operation failed. Please try again.");
            }
            
        }

        private void cmbNewOrder_SearchRecipe_Loaded(object sender, RoutedEventArgs e)
        {
            var recipes = myRecipeManager.GetRecipeNames();
            List<String> recipeNames = new List<String>();
            
            try
            {
                var comboBox = sender as ComboBox;
                comboBox.ItemsSource = recipes;
                comboBox.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Could not populate recipe selection box.");
            }
        }

        private void btnNewOrder_CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            int orderID;
            string orderIDString = txtblkNewOrder_OrderID.Text;
            int price;
            string priceString = txtNewOrder_Price.Text;
            int quantity;
            string quantityString = txtNewOrder_RecipeQuantity.Text;
            OrderLine orderLine = new OrderLine();

            orderID = Int32.Parse(orderIDString);

            if ((Int32.TryParse(priceString, out price)) && (Int32.TryParse(quantityString, out quantity)))
            {
                orderLine.OrderID = orderID;
                int orderIDParsed = orderID;
                orderLine.RecipeID = cmbNewOrder_SearchRecipe.SelectedItem.ToString();
                orderLine.Price = price;
                orderLine.Quantity = quantity;

                if(String.IsNullOrWhiteSpace(orderIDString) && String.IsNullOrWhiteSpace(priceString) && String.IsNullOrWhiteSpace(quantityString))
                {
                    MessageBox.Show("Please fill out the form completely.");
                }
                else
                {
                    try
                    {
                        if (myOrderManager.AddOrderLine(orderLine) == true)
                        {
                            MessageBox.Show("Success! The following was added: (" + orderLine.Quantity.ToString() + ") " + orderLine.RecipeID + " for a total of " + (orderLine.Price * orderLine.Quantity) + " gil.");
                            txtNewOrder_Price.Clear();
                            txtNewOrder_RecipeQuantity.Clear();

                            try
                            {
                                orderLineList = myOrderManager.SelectOrderLines_CurrentOrderByID(orderIDParsed);
                                refreshOrderLineGrid();
                            }
                            catch(Exception)
                            {
                                MessageBox.Show("Could not display order lines. Please try again later.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("The recipe could not be added. Please try again.");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("The operation could not be completed. Please try again.");
                       
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter numerical values.");
            }

        }

        private void btnNewOrder_ClearForm_Click(object sender, RoutedEventArgs e)
        {
            txtNewOrder_Price.Clear();
            txtNewOrder_RecipeQuantity.Clear();
            gridNewOrder_ViewOrder.ItemsSource = null;
        }

        private void btnSearchOrders_Click(object sender, RoutedEventArgs e)
        {

            string searchTerm = txtSearchCriteria.Text;
            bool active = true;

            if (cmbxitmAll.IsSelected)
            {
                try
                {
                    orderList = myOrderManager.GetOrderList_SearchAll(searchTerm, active);

                    if ((chkSearchCompleted.IsChecked == true) && (chkSearchTraded.IsChecked == true) && (chkSearchPaid.IsChecked == true))
                    {
                        var filtered = from Order o in orderList
                                       where o.Paid == true && o.Traded == true && o.Completed == true 
                                       select o;
                        gridOrderSearchResults.ItemsSource = filtered;
                    }
                    else if ((chkSearchPaid.IsChecked == true) && (chkSearchTraded.IsChecked == true))
                    {
                        //list filtering with linq... two ways? pick one!!
                        var filtered = from Order o in orderList
                                       where o.Paid == true && o.Traded == true
                                       select o;
                        gridOrderSearchResults.ItemsSource = filtered;
                    }
                    else if ((chkSearchPaid.IsChecked == true) && (chkSearchCompleted.IsChecked == true))
                    {
                        //list filtering with linq... two ways? pick one!!
                        var filtered = from Order o in orderList
                                       where o.Paid == true && o.Completed == true
                                       select o;
                        gridOrderSearchResults.ItemsSource = filtered;
                    }
                    else if ((chkSearchTraded.IsChecked == true) && (chkSearchCompleted.IsChecked == true))
                    {
                        //list filtering with linq... two ways? pick one!!
                        var filtered = from Order o in orderList
                                       where o.Traded == true && o.Completed == true
                                       select o;
                        gridOrderSearchResults.ItemsSource = filtered;
                    }
                    else if (chkSearchPaid.IsChecked == true)
                    {
                        orderList = orderList.FindAll(x => x.Paid == true);
                        refreshOrderGrid();
                    }
                    else if (chkSearchTraded.IsChecked == true)
                    {
                        orderList = orderList.FindAll(x => x.Traded == true);
                        refreshOrderGrid();
                    }
                    else if (chkSearchCompleted.IsChecked == true)
                    {
                        orderList = orderList.FindAll(x => x.Completed == true);
                        refreshOrderGrid();
                    }
                    else
                    {
                        refreshOrderGrid();
                    }
                }
                catch (Exception)
                {
                    gridOrderSearchResults.ItemsSource = null;
                    MessageBox.Show("No records found.");
                }                
            }
            else if (cmbxitmOrderNumber.IsSelected)
            {
                int testSearchTerm = 0;
                if (Int32.TryParse(searchTerm, out testSearchTerm))
                {

                    try
                    {
                        var orderList = myOrderManager.GetOrderListByID(testSearchTerm);
                        if ((chkSearchPaid.IsChecked == true) && (chkSearchTraded.IsChecked == true))
                        {
                            //list filtering with linq... two ways? pick one!!
                            var filtered = from Order o in orderList
                                           where o.Paid == true && o.Traded == true
                                           select o;
                            gridOrderSearchResults.ItemsSource = filtered;
                        }
                        else if (chkSearchPaid.IsChecked == true)
                        {
                            orderList = orderList.FindAll(x => x.Paid == true);
                            refreshOrderGrid();
                        }
                        else if (chkSearchTraded.IsChecked == true)
                        {
                            orderList = orderList.FindAll(x => x.Traded == true);
                            refreshOrderGrid();
                        }
                        else
                        {
                            refreshOrderGrid();
                        }
                    }
                    catch (Exception)
                    {
                        gridOrderSearchResults.ItemsSource = null;
                        MessageBox.Show("No records have been found.");
                    }
                }
                else
                    MessageBox.Show("Please enter only numeric values to search by Order ID.");


            }
            else if (cmbxitmCook.IsSelected)
            {
                int testSearchTerm = 0;
                if (Int32.TryParse(searchTerm, out testSearchTerm))
                {
                    try
                    {
                        var orderList = myOrderManager.GetOrderListByCookID(testSearchTerm);
                        if ((chkSearchPaid.IsChecked == true) && (chkSearchTraded.IsChecked == true))
                        {
                            //list filtering with linq... two ways? pick one!!
                            var filtered = from Order o in orderList
                                           where o.Paid == true && o.Traded == true
                                           select o;
                            gridOrderSearchResults.ItemsSource = filtered;
                        }
                        else if (chkSearchPaid.IsChecked == true)
                        {
                            orderList = orderList.FindAll(x => x.Paid == true);
                            refreshOrderGrid();
                        }
                        else if (chkSearchTraded.IsChecked == true)
                        {
                            orderList = orderList.FindAll(x => x.Traded == true);
                            refreshOrderGrid();
                        }
                        else
                        {
                            refreshOrderGrid();
                        }
                    }
                    catch (Exception)
                    {
                        gridOrderSearchResults.ItemsSource = null;
                        MessageBox.Show("No records have been found.");
                    }
                }
                else
                    MessageBox.Show("Please enter only numeric values to search by Cook ID.");
            }
            else if (cmbxitmDateRange.IsSelected)
            {
                if ((dateOrderSearchStart != null) && (dateOrderSearchEnd != null))
                {
                    try
                    {
                        DateTime beginDate = (DateTime)dateOrderSearchStart.SelectedDate;
                        DateTime endDate = (DateTime)dateOrderSearchEnd.SelectedDate;

                        var orderList = myOrderManager.GetOrderListByDateRange(beginDate, endDate);
                        if ((chkSearchPaid.IsChecked == true) && (chkSearchTraded.IsChecked == true))
                        {
                            //list filtering with linq... two ways? pick one!!
                            var filtered = from Order o in orderList
                                           where o.Paid == true && o.Traded == true
                                           select o;
                            gridOrderSearchResults.ItemsSource = filtered;
                        }
                        else if (chkSearchPaid.IsChecked == true)
                        {
                            orderList = orderList.FindAll(x => x.Paid == true);
                            refreshOrderGrid();
                        }
                        else if (chkSearchTraded.IsChecked == true)
                        {
                            orderList = orderList.FindAll(x => x.Traded == true);
                            refreshOrderGrid();
                        }
                        else
                        {
                            refreshOrderGrid();
                        }
                    }
                    catch (Exception)
                    {
                        gridOrderSearchResults.ItemsSource = null;
                        MessageBox.Show("No records have been found.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select two dates before searching.");
                }
            }
        }

        private void cmbxitmDateRange_Selected(object sender, RoutedEventArgs e)
        {
            dateOrderSearchEnd.IsEnabled = true;
            dateOrderSearchStart.IsEnabled = true;
        }

        private void cmbxitmDateRange_Unselected(object sender, RoutedEventArgs e)
        {
            dateOrderSearchStart.IsEnabled = false;
            dateOrderSearchEnd.IsEnabled = false;
        }

        private void gridOrderSearchResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEditOrder.IsEnabled = true;
            btnDeleteOrder.IsEnabled = true;
            btnEditItems.IsEnabled = true;
            
            foreach(var r in _accessToken.Roles)
            {
                if(r.RoleID == "Chef Popoto" || r.RoleID == "Sous Popoto")
                {
                    btnAssignOrders.IsEnabled = true;
                }
            }
        }

        private void btnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            var order = (Order)gridOrderSearchResults.SelectedItem;

            if(order != null)
            {
                order.Active = false;

                try
                {
                    if (myOrderManager.DeleteOrder(order))
                    {
                        MessageBox.Show("Success! Order disactivated.");
                        refreshOrderGrid();
                    }
                    else
                    {
                        MessageBox.Show("Could not disactivate the order. Please try again.");
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Could not delete order. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Please select an order.");
            }

        }

        private void btnEditItems_Click(object sender, RoutedEventArgs e)
        {
            var order = (Order)gridOrderSearchResults.SelectedItem;

            if(order != null)
            {
                var editOrderLines = new EditOrderLines(order, _accessToken);
                editOrderLines.ShowDialog();
            }

        }

        private void btnOrderArchive_SearchOrders_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = txtOrderArchive_SearchCriteria.Text;
            bool active = false;
            gridOrderArchive_SearchResults.ItemsSource = null;

            try
            {
                orderArchiveList = myOrderManager.GetOrderList_SearchAll(searchTerm, active);

                if ((chkSearchCompleted_Archive.IsChecked == true) && (chkSearchTraded_Archive.IsChecked == true) && (chkSearchPaid_Archive.IsChecked == true))
                {
                    var filtered = from Order o in orderArchiveList
                                   where o.Paid == true && o.Traded == true && o.Completed == true
                                   select o;
                    gridOrderArchive_SearchResults.ItemsSource = filtered;
                }
                else if ((chkSearchPaid_Archive.IsChecked == true) && (chkSearchTraded_Archive.IsChecked == true))
                {
                    //list filtering with linq... two ways? pick one!!
                    var filtered = from Order o in orderArchiveList
                                   where o.Paid == true && o.Traded == true
                                   select o;
                    gridOrderArchive_SearchResults.ItemsSource = filtered;
                }
                else if ((chkSearchPaid_Archive.IsChecked == true) && (chkSearchCompleted_Archive.IsChecked == true))
                {
                    //list filtering with linq... two ways? pick one!!
                    var filtered = from Order o in orderArchiveList
                                   where o.Paid == true && o.Completed == true
                                   select o;
                    gridOrderArchive_SearchResults.ItemsSource = filtered;
                }
                else if ((chkSearchTraded_Archive.IsChecked == true) && (chkSearchCompleted_Archive.IsChecked == true))
                {
                    //list filtering with linq... two ways? pick one!!
                    var filtered = from Order o in orderArchiveList
                                   where o.Traded == true && o.Completed == true
                                   select o;
                    gridOrderArchive_SearchResults.ItemsSource = filtered;
                }
                else if (chkSearchPaid_Archive.IsChecked == true)
                {
                    orderArchiveList = orderArchiveList.FindAll(x => x.Paid == true);
                    refreshOrderArchiveGrid();
                }
                else if (chkSearchTraded_Archive.IsChecked == true)
                {
                    orderArchiveList = orderArchiveList.FindAll(x => x.Traded == true);
                    refreshOrderArchiveGrid();
                }
                else if (chkSearchCompleted_Archive.IsChecked == true)
                {
                    orderArchiveList = orderArchiveList.FindAll(x => x.Completed == true);
                    refreshOrderArchiveGrid();
                }
                else
                {
                    refreshOrderArchiveGrid();
                }
            }
            catch (Exception)
            {
                gridOrderArchive_SearchResults.ItemsSource = null;
                MessageBox.Show("No records found.");
            }
        }

        private void btnOrderArchive_ViewAllOrders_Click(object sender, RoutedEventArgs e)
        {
            txtOrderArchive_SearchCriteria.Clear();
            chkSearchCompleted_Archive.IsChecked = false;
            chkSearchPaid_Archive.IsChecked = false;
            chkSearchTraded_Archive.IsChecked = false;

            bool active = false;
            gridOrderArchive_SearchResults.ItemsSource = null;

            try
            {
                orderArchiveList = myOrderManager.GetOrderList(active);
                refreshOrderArchiveGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("No records found.");
            }
        }

        private void btnOrderArchive_EditOrder_Click(object sender, RoutedEventArgs e)
        {
            var order = (Order)gridOrderArchive_SearchResults.SelectedItem;

            if(order != null)
            {
                var editOrder = new EditOrder(order,_accessToken);
                editOrder.ShowDialog();
            }

        }

        private void btnOrderArchive_DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            var order = (Order)gridOrderArchive_SearchResults.SelectedItem;

            if(order != null)
            {
                string yesNoMessageText = "Do you really want to permanently delete order with ID " + order.OrderID.ToString() + "?";
                string caption = "Selected order will be deleted from the database and a record will be kept of the deletion.";

                MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
                MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                MessageBoxResult rsltMessageBox = MessageBox.Show(yesNoMessageText, caption, btnMessageBox, icnMessageBox);

                switch (rsltMessageBox)
                {
                    case MessageBoxResult.Yes:
                        if (myOrderManager.AdminSaveDeletedOrder(order))
                        {
                            if (myOrderManager.AdminDeleteOrder(order))
                            {
                                MessageBox.Show("Success!");
                                refreshOrderArchiveGrid();
                            }
                            else
                            {
                                MessageBox.Show("Order was saved but could not be deleted. Please try again.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong. Please try again.");
                        }

                        break;
                    case MessageBoxResult.No:
                        break;

                }
            }
            else
            {
                MessageBox.Show("Please select an order.");
            }

        }

        private void btnNewOrder_ClearOrder_Click(object sender, RoutedEventArgs e)
        {
            txtNewOrder_CustomerID.Clear();
            txtNewOrder_CookID.Clear();
            datepckNewOrder_Date.SelectedDate = null;
            txtblkNewOrder_OrderID.Text = null;

        }

        private void btnOrderArchive_ReactivateOrder_Click(object sender, RoutedEventArgs e)
        {
            Order newOrder = new Order();

            var order = (Order)gridOrderArchive_SearchResults.SelectedItem;

            if(order != null)
            {
                string yesNoMessageText = "Reactivate order with ID " + order.OrderID.ToString() + "?";
                string caption = "Selected order will be reactivated and will appear in searches and the order list.";

                MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
                MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                MessageBoxResult rsltMessageBox = MessageBox.Show(yesNoMessageText, caption, btnMessageBox, icnMessageBox);

                newOrder.OrderID = order.OrderID;
                newOrder.CustomerID = order.CustomerID;
                newOrder.CookID = order.CookID;
                newOrder.OrderDate = order.OrderDate;
                newOrder.Completed = order.Completed;
                newOrder.Paid = order.Paid;
                newOrder.Traded = order.Traded;
                newOrder.Active = true;

                switch (rsltMessageBox)
                {
                    case MessageBoxResult.Yes:
                        if (myOrderManager.EditOrder(newOrder))
                        {

                            MessageBox.Show("Success!");
                            refreshOrderArchiveGrid();

                        }
                        else
                        {
                            MessageBox.Show("Something went wrong. Please try again.");
                        }

                        break;
                    case MessageBoxResult.No:
                        break;

                }
            }
            else
            {
                MessageBox.Show("Please select an order.");
            }

        }

        private void cmbRecipeList_Loaded(object sender, RoutedEventArgs e)
        {
            var recipes = myRecipeManager.GetRecipeNamesAndILVL();

            try
            {
                var comboBox = sender as ComboBox;
                comboBox.ItemsSource = recipes;
                comboBox.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Could not populate recipe selection box.");
            }
        }

        private void cmbRecipeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string recipeName = cmbRecipeList.SelectedItem.ToString();
            string pattern = " - ";
            //List<string> names = recipeName.Split('-').ToList<string>();
            string[] listString = Regex.Split(recipeName, pattern);
            //char mychar = ' ';
            //recipeName = names[0].TrimEnd(mychar);
            recipeName = listString[0];

            

            string imageString = @"Resources/" + recipeName + ".png";

            BitmapImage image = new BitmapImage(new Uri(imageString, UriKind.Relative));

            imgRecipes.Source = image;

            string muffinString = @"Resources/Isghardian Muffin.png";

            if (cmbRecipeList.SelectedIndex == 14)
            {
                BitmapImage muffin = new BitmapImage(new Uri(muffinString, UriKind.Relative));
                imgRecipes.Source = image;
            }

            try
            {
                recipeIngredientList = myRecipeManager.GetRecipeIngredientListByID(recipeName);
                refreshRecipeIngredientGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not populate ingredient grid.");
            }

            try
            {
                recipeCatalystList = myRecipeManager.GetRecipeCatalystListByID(recipeName);
                refreshRecipeCatalystGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not populate catalyst grid");
            }

            try
            {
                r = myRecipeManager.GetRecipeStats(recipeName);
                
                txtStatMindPerc.Text = r.Mind.ToString();
                txtStatMindStack.Text = r.MindStack.ToString();
                txtStatAccPerc.Text = r.Acc.ToString();
                txtStatAccStack.Text = r.AccStack.ToString();
                txtStatCritPerc.Text = r.Crit.ToString();
                txtStatCritStack.Text = r.CritStack.ToString();
                txtStatDetPerc.Text = r.Det.ToString();
                txtStatDetStack.Text = r.DetStack.ToString();
                txtStatSpellPerc.Text = r.Spell.ToString();
                txtStatSpellStack.Text = r.SpellStack.ToString();
                txtStatVitPerc.Text = r.Vit.ToString();
                txtStatVitStack.Text = r.VitStack.ToString();
                txtStatPiePerc.Text = r.Piety.ToString();
                txtStatPieStack.Text = r.PietyStack.ToString();
                txtStatDexPerc.Text = r.Dex.ToString();
                txtStatDexStack.Text = r.DexStack.ToString();
                txtStatStrPerc.Text = r.Strength.ToString();
                txtStatStrStack.Text = r.StrengthStack.ToString();
                txtStatIntPerc.Text = r.Intel.ToString();
                txtStatIntStack.Text = r.IntelStack.ToString();
                txtStatParryPerc.Text = r.Parry.ToString();
                txtStatParryStack.Text = r.ParryStack.ToString();
                txtStatSkillPerc.Text = r.Skill.ToString();
                txtStatSkillStack.Text = r.SkillStack.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not populate stats.");
            }
        }

        private void refreshCustomerGrid()
        {
            try
            {
                gridCustomer_CustomerSearchResults.ItemsSource = null;
                gridCustomer_CustomerSearchResults.ItemsSource = customerList;
            }
            catch (Exception)
            {
                gridCustomer_CustomerSearchResults.ItemsSource = null;
            }

        }

        private void refreshCustomerArchiveGrid()
        {
            try
            {
                gridCustomerArchive_CustomerSearchResults.ItemsSource = null;
                gridCustomerArchive_CustomerSearchResults.ItemsSource = customerArchiveList;
            }
            catch (Exception)
            {
                gridCustomerArchive_CustomerSearchResults.ItemsSource = null;
            }
        }

        private void refreshOrderGrid()
        {
            try
            {
                gridOrderSearchResults.ItemsSource = null;
                gridOrderSearchResults.ItemsSource = orderList;
                gridOrderSearchResults.Columns[8].Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {
                gridOrderSearchResults.ItemsSource = null;
            }
        }

        private void refreshOrderLineGrid()
        {
            try
            {
                gridNewOrder_ViewOrder.ItemsSource = null;
                gridNewOrder_ViewOrder.ItemsSource = orderLineList;
            }
            catch (Exception)
            {
                gridNewOrder_ViewOrder.ItemsSource = null;
            }
        }

        private void refreshOrderArchiveGrid()
        {
            try
            {
                gridOrderArchive_SearchResults.ItemsSource = null;
                gridOrderArchive_SearchResults.ItemsSource = orderArchiveList;
            }
            catch (Exception)
            {
                gridOrderArchive_SearchResults.ItemsSource = null;
            }
        }

        private void refreshCookGrid()
        {
            try
            {
                gridCook_SearchResults.ItemsSource = null;
                gridCook_SearchResults.ItemsSource = cookList;
            }
            catch (Exception)
            {
                gridCook_SearchResults.ItemsSource = null;
            }
        }

        private void refreshCookArchiveGrid()
        {
            try
            {
                gridCookArchive_SearchResults.ItemsSource = null;
                gridCookArchive_SearchResults.ItemsSource = cookList;
            }
            catch (Exception)
            {
                gridCookArchive_SearchResults.ItemsSource = null;
            }
        }

        private void refreshRecipeIngredientGrid()
        {
            try
            {
                gridRecipeIngredients.ItemsSource = null;
                gridRecipeIngredients.ItemsSource = recipeIngredientList;
            }
            catch (Exception)
            {
                gridRecipeIngredients.ItemsSource = null;
            }
        }

        private void refreshRecipeCatalystGrid()
        {
            try
            {
                gridRecipeCatalysts.ItemsSource = null;
                gridRecipeCatalysts.ItemsSource = recipeCatalystList;
            }
            catch (Exception)
            {
                gridRecipeCatalysts.ItemsSource = null;
            }
        }

        private void refreshMessagesGrid()
        {
            try
            {
                gridMessageGrid.ItemsSource = null;
                gridMessageGrid.ItemsSource = messageList;
            }
            catch (Exception)
            {
                gridMessageGrid.ItemsSource = null;
            }
        }

        private void btnStats_EditMyStats_Click(object sender, RoutedEventArgs e)
        {
            if (gridStatCalculator.IsVisible)
            {
                gridStatCalculator.Visibility = Visibility.Collapsed;
                btnStats_ClearStats.IsEnabled = false;
                btnStats_ResetStats.IsEnabled = false;
            }
            else
            {
                gridStatCalculator.Visibility = Visibility.Visible;
                btnStats_ClearStats.IsEnabled = true;
                btnStats_ResetStats.IsEnabled = true;
            }
        }

        private void btnStats_ResetStats_Click(object sender, RoutedEventArgs e)
        {
            resetStats();
        }

        private void btnStats_ClearStats_Click(object sender, RoutedEventArgs e)
        {
            txtUserAccStack.Clear();
            txtUserCritStack.Clear();
            txtUserDetStack.Clear();
            txtUserDexStack.Clear();
            txtUserIntStack.Clear();
            txtUserMindStack.Clear();
            txtUserParryStack.Clear();
            txtUserPieStack.Clear();
            txtUserSkillStack.Clear();
            txtUserSpellStack.Clear();
            txtUserStrStack.Clear();
            txtUserVitStack.Clear();
        }

        private void btnStats_CalcStats_Click(object sender, RoutedEventArgs e)
        {
            int mind, acc, crit, det, spell, vit, pie, dex, str, intel, par, skill = 0;

            resetStats();

            if ((Int32.TryParse(txtUserMindStack.Text, out mind)) &&
                (Int32.TryParse(txtUserAccStack.Text, out acc)) &&
                (Int32.TryParse(txtUserCritStack.Text, out crit)) &&
                (Int32.TryParse(txtUserDetStack.Text, out det)) &&
                (Int32.TryParse(txtUserSpellStack.Text, out spell)) &&
                (Int32.TryParse(txtUserVitStack.Text, out vit)) &&
                (Int32.TryParse(txtUserPieStack.Text, out pie)) &&
                (Int32.TryParse(txtUserDexStack.Text, out dex)) &&
                (Int32.TryParse(txtUserStrStack.Text, out str)) &&
                (Int32.TryParse(txtUserIntStack.Text, out intel)) &&
                (Int32.TryParse(txtUserParryStack.Text, out par)) &&
                (Int32.TryParse(txtUserSkillStack.Text, out skill)))
            {
                if (((mind < MAXSTAT) && (mind > 0)) &&
                    ((acc < MAXSTAT) && (acc > 0)) &&
                    ((crit < MAXSTAT) && (crit > 0)) &&
                    ((det < MAXSTAT) && (det > 0)) &&
                    ((spell < MAXSTAT) && (spell > 0)) &&
                    ((vit < MAXSTAT) && (vit > 0)) &&
                    ((pie < MAXSTAT) && (pie > 0)) &&
                    ((dex < MAXSTAT) && (dex > 0)) &&
                    ((str < MAXSTAT) && (str > 0)) &&
                    ((intel < MAXSTAT) && (intel > 0)) &&
                    ((par < MAXSTAT) && (par > 0)) &&
                    ((skill < MAXSTAT) && (skill > 0)))
                {
                    userMind = mind;
                    userAcc = acc;
                    userCrit = crit;
                    userDet = det;
                    userSpell = spell;
                    userVit = vit;
                    userPie = pie;
                    userDex = dex;
                    userStr = str;
                    userInt = intel;
                    userPar = par;
                    userSkill = skill;

                    if (userAcc != 0 && userCrit != 0 && userDet != 0 && userDex != 0 && userInt != 0 && userMind != 0 && userPar != 0 && userPie != 0 && userSkill != 0 && userSpell != 0 && userStr != 0 && userVit != 0)
                    {
                        txtUserMindStack.Text = StatCalculator.CalcMyStat(r.MindStack, r.Mind, userMind);
                        txtUserAccStack.Text = StatCalculator.CalcMyStat(r.AccStack, r.Acc, userAcc);
                        txtUserCritStack.Text = StatCalculator.CalcMyStat(r.CritStack, r.Crit, userCrit);
                        txtUserDetStack.Text = StatCalculator.CalcMyStat(r.DetStack, r.Det, userDet);
                        txtUserSpellStack.Text = StatCalculator.CalcMyStat(r.SpellStack, r.Spell, userSpell);
                        txtUserVitStack.Text = StatCalculator.CalcMyStat(r.VitStack, r.Vit, userVit);
                        txtUserPieStack.Text = StatCalculator.CalcMyStat(r.PietyStack, r.Piety, userPie);
                        txtUserDexStack.Text = StatCalculator.CalcMyStat(r.DexStack, r.Dex, userDex);
                        txtUserStrStack.Text = StatCalculator.CalcMyStat(r.StrengthStack, r.Strength, userStr);
                        txtUserIntStack.Text = StatCalculator.CalcMyStat(r.IntelStack, r.Intel, userInt);
                        txtUserParryStack.Text = StatCalculator.CalcMyStat(r.ParryStack, r.Parry, userPar);
                        txtUserSkillStack.Text = StatCalculator.CalcMyStat(r.SkillStack, r.Skill, userSkill);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a number below " + MAXSTAT);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number between 0 and " + MAXSTAT);
            }

        }

        private void resetStats()
        {
            if (userAcc > 0 && userCrit > 0 && userDet > 0 && userDex > 0 && userInt > 0 && userMind > 0 && userPar > 0 && userPie > 0 && userSkill > 0 && userSpell > 0 && userStr > 0 && userVit > 0)
            {
                txtUserAccStack.Text = userAcc.ToString();
                txtUserCritStack.Text = userCrit.ToString();
                txtUserDetStack.Text = userDet.ToString();
                txtUserDexStack.Text = userDex.ToString();
                txtUserIntStack.Text = userInt.ToString();
                txtUserMindStack.Text = userMind.ToString();
                txtUserParryStack.Text = userPar.ToString();
                txtUserPieStack.Text = userPie.ToString();
                txtUserSkillStack.Text = userSkill.ToString();
                txtUserSpellStack.Text = userSpell.ToString();
                txtUserStrStack.Text = userStr.ToString();
                txtUserVitStack.Text = userVit.ToString();
            }
        }

        private void mnuCustomerReport_Click(object sender, RoutedEventArgs e)
        {
            var rptForm = new frmCustomerListReport();
            rptForm.ShowDialog();
        }

        private void mnuUncompleteOrdersReport_Click(object sender, RoutedEventArgs e)
        {
            var rptForm = new frmUncompletedOrdersListForm();
            rptForm.ShowDialog();
        }

        private void gridRecipeIngredients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnViewIngredientDetails.IsEnabled = true;
        }

        private void btnViewIngredientDetails_Click(object sender, RoutedEventArgs e)
        {
            var ingredient = (RecipeIngredient)gridRecipeIngredients.SelectedItem;

            if(ingredient != null)
            {
                var ingredientInfo = new IngredientInformation(ingredient.IngredientID);
                ingredientInfo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an ingredient.");
            }

        }

        private void btnCook_ViewAll_Click(object sender, RoutedEventArgs e)
        {
            bool active = true;
            txtCook_SearchCriteria.Clear();

            try
            {
                cookList = myCookManager.GetCookList(active);
                refreshCookGrid();
                gridCook_SearchResults.Columns[6].Visibility = Visibility.Collapsed;
            }
            catch (Exception)
            {
                MessageBox.Show("No records have been found.");
            }
        }

        private void btnCook_SearchCooks_Click(object sender, RoutedEventArgs e)
        {
            bool active = true;
            string searchTerm = txtCook_SearchCriteria.Text;

            try
            {
                cookList = myCookManager.GetCookListByTerm(searchTerm, active);
                refreshCookGrid();
                gridCook_SearchResults.Columns[6].Visibility = Visibility.Collapsed;
            }
            catch (Exception)
            {
                MessageBox.Show("No records have been found.");
            }
        }

        private void btnCookArchive_ViewAll_Click(object sender, RoutedEventArgs e)
        {
            bool active = false;
            txtCookArchive_SearchCriteria.Clear();

            try
            {
                cookList = myCookManager.GetCookList(active);
                refreshCookArchiveGrid();
                gridCookArchive_SearchResults.Columns[6].Visibility = Visibility.Collapsed;
            }
            catch (Exception)
            {
                MessageBox.Show("No records have been found.");
            }
        }

        private void btnCookArchive_SearchCooks_Click(object sender, RoutedEventArgs e)
        {
            bool active = false;
            string searchTerm = txtCookArchive_SearchCriteria.Text;

            try
            {
                cookArchiveList = myCookManager.GetCookListByTerm(searchTerm, active);
                refreshCookGrid();
                gridCookArchive_SearchResults.Columns[6].Visibility = Visibility.Collapsed;
            }
            catch (Exception)
            {
                MessageBox.Show("No records have been found.");
            }
        }

        private void btnCookArchive_DeleteCook_Click(object sender, RoutedEventArgs e)
        {
            var c = (Cook)gridCookArchive_SearchResults.SelectedItem;

            if(c != null)
            {
                string yesNoMessageText = "Do you really want to permanently delete Cook " + c.FirstName + " " + c.LastName + " ?";
                string caption = "Selected cook will be deleted from the database and a record will be kept of the deletion.";

                MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
                MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                MessageBoxResult rsltMessageBox = MessageBox.Show(yesNoMessageText, caption, btnMessageBox, icnMessageBox);

                switch (rsltMessageBox)
                {
                    case MessageBoxResult.Yes:
                        if (myCookManager.SaveDeletedCook(c))
                        {
                            if (myCookManager.AdminDeleteCook(c))
                            {
                                MessageBox.Show("Success!");
                                refreshOrderArchiveGrid();
                            }
                            else
                            {
                                MessageBox.Show("Cook was saved but could not be permanently deleted. Please try again.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong. Please try again.");
                        }

                        break;
                    case MessageBoxResult.No:
                        this.Close();
                        break;

                }
            }
            else
            {
                MessageBox.Show("Please select a cook.");
            }

        }

        private void btnCook_EditCook_Click(object sender, RoutedEventArgs e)
        {
            var c = (Cook)gridCook_SearchResults.SelectedItem;

            if(c != null)
            {
                var editCook = new EditCook(c);
                editCook.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a cook.");
            }

        }

        private void btnCook_DeleteCook_Click(object sender, RoutedEventArgs e)
        {
            var c = (Cook)gridCook_SearchResults.SelectedItem;

            if(c != null)
            {
                try
                {
                    c.Active = false;
                    if (myCookManager.DeleteCook(c) == true)
                    {
                        MessageBox.Show("Successfully inactivated.");
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong. Please try again.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Could not be inactivated. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Please select a cook.");
            }

        }

        private void btnCookArchive_EditCook_Click(object sender, RoutedEventArgs e)
        {
            var c = (Cook)gridCookArchive_SearchResults.SelectedItem;

            if(c != null)
            {
                var editCook = new EditCook(c);
                editCook.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a cook.");
            }
        }

        private void btnCookArchive_ReactivateCook_Click(object sender, RoutedEventArgs e)
        {
            var c = (Cook)gridCookArchive_SearchResults.SelectedItem;

            if(c != null)
            {
                try
                {
                    c.Active = true;
                    if (myCookManager.EditCook(c) == true)
                    {
                        MessageBox.Show("Successfully reactivated.");
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong. Please try again.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Could not be reactivated. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Please select a cook.");
            }

        }

        private void btnNewCook_Clear_Click(object sender, RoutedEventArgs e)
        {
            txtNewCook_EmailAddress.Clear();
            txtNewCook_FirstName.Clear();
            txtNewCook_LastName.Clear();
            txtNewCook_LocalPhone.Clear();
        }

        private void btnNewCook_AddCook_Click(object sender, RoutedEventArgs e)
        {
            string message = null;
            var c = new Cook();
            int cookID = 0;

            try
            {
                c.FirstName = txtNewCook_FirstName.Text;
                c.LastName = txtNewCook_LastName.Text;
                c.LocalPhone = txtNewCook_LocalPhone.Text;
                c.EmailAddress = txtNewCook_EmailAddress.Text;

                if (String.IsNullOrWhiteSpace(c.FirstName) || String.IsNullOrWhiteSpace(c.LastName) || (Validators.IsPhoneNumber(c.LocalPhone) == false) || (Validators.IsValidEmail(c.EmailAddress) == false))
                {
                    if (Validators.IsValidEmail(c.EmailAddress) == false)
                    {
                        message = "Please fill out all fields correctly. Enter a valid e-mail address.";
                        MessageBox.Show(message);
                    }
                    else if (Validators.IsPhoneNumber(c.LocalPhone) == false)
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
                    c.UserName = c.FirstName.ToLower() + c.LastName.ToLower();
                    c.CookID = 0;

                    if (myCookManager.AddCook(c) == true)
                    {
                        txtNewCook_EmailAddress.Clear();
                        txtNewCook_FirstName.Clear();
                        txtNewCook_LastName.Clear();
                        txtNewCook_LocalPhone.Clear();

                        MessageBox.Show("Success! " + c.FirstName + " " + c.LastName + " was added successfully.");

                        try
                        {
                            cookID = myCookManager.LastAddedCook(c);
                            if (cookID != 0)
                            {
                                c.CookID = cookID;
                                var editPermissions = new EditPermissions(c);
                                editPermissions.ShowDialog();
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Could not select the most recently added cook.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Could not be added. Please try again.");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Could not add cook. Please try again.");
            }
        }

        private void btnCook_SendMessage_Click(object sender, RoutedEventArgs e)
        {
            var c = (Cook)gridCook_SearchResults.SelectedItem;
            var m = new Message();
            bool send = true;
            
            if(c != null)
            {
                var sendMessage = new SendMessage(c,send,m);
                sendMessage.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a cook.");
            }
        }

        private void gridCook_SearchResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnCook_SendMessage.IsEnabled = true;
            btnCook_EditCook.IsEnabled = true;
            btnCook_DeleteCook.IsEnabled = true;
        }

        private void loadMessages(int cookID)
        {

            try
            {
                messageList = myCookManager.GetCookMessages(_accessToken.CookID);

                var messageListFiltered = from Message m in messageList
                                            where m.HasRead == false
                                            select m;

                var messageListOrdered = from Message m in messageList
                                         where m.Active == true
                                         orderby m.HasRead, m.MessageDate
                                         //select new { ID = m.MessageID, Date = m.MessageDate, Subject = m.MessageSubject, Read = m.HasRead };
                                         select m;

                gridMessageGrid.ItemsSource = messageListOrdered;

                string messageChar = "message";
                if (messageListFiltered.Count() > 1 || messageListFiltered.Count() == 0)
                {
                    messageChar = "messages";
                }

                lblMessageCount.Content = "Hello! You have " + messageListFiltered.Count() + " new " + messageChar + ".";
                
            }
            catch (Exception)
            {
                lblStatusMessage.Content = "You have no messages.";
            }
        }

        private void loadOrders(int cookID)
        {
            try
            {
                cookOrderList = myOrderManager.GetOrderListByCookID(_accessToken.CookID);

                var uncompletedOrders = from Order o in cookOrderList
                                         where o.Completed == false
                                         orderby o.OrderDate
                                         select o;

                if(uncompletedOrders.Count() > 0)
                {
                    gridKitchenOrders.ItemsSource = uncompletedOrders;
                }
                else
                {
                    gridKitchenOrders.ItemsSource = null;
                }

                var completedOrders = from Order o in cookOrderList
                                      where o.Completed == true
                                      orderby o.OrderDate
                                      select o;
            }
            catch (Exception)
            {
                lblStatusMessage.Content = "You have no orders to complete.";
            }
        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            bool send = false;
            var c = new Cook();
            var m = (Message)gridMessageGrid.SelectedItem;

            if(m != null)
            {
                m.CookID = _accessToken.CookID;
                var readMessage = new SendMessage(c, send, m);
                readMessage.ShowDialog();
                if (this.DialogResult == true)
                {
                    loadMessages(_accessToken.CookID);
                }
            }
            else
            {
                MessageBox.Show("Please select a message.");
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var m = (Message)gridMessageGrid.SelectedItem;

            if(m != null)
            {
                m.CookID = _accessToken.CookID;
                m.Active = false;

                if (myCookManager.EditMessage(m) == true)
                {
                    MessageBox.Show("Message deleted.");
                    loadMessages(_accessToken.CookID);
                }
                else
                {
                    MessageBox.Show("Could not delete message.");
                }
            }
            else
            {
                MessageBox.Show("Please select a message.");
            }

        }

        private void gridMessageGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnMessage_Read.IsEnabled = true;
            btnMessage_Delete.IsEnabled = true;
        }

        private void btnMessage_Refresh_Click(object sender, RoutedEventArgs e)
        {
            loadMessages(_accessToken.CookID);
        }

        private void gridKitchenOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnKitchenOrder_CookItems.IsEnabled = true;
            
            foreach(var r in _accessToken.Roles)
            {
                if(r.RoleID == "Chef Popoto" || r.RoleID == "Sous Popoto")
                {
                    btnAssignOrders.IsEnabled = true;
                    btnKitchenOrder_MarkCompleted.IsEnabled = true;
                }
            }
        }

        private void btnKitchenOrder_CookItems_Click(object sender, RoutedEventArgs e)
        {
            var o = (Order)gridKitchenOrders.SelectedItem;

            if(o != null)
            {
                var cookFood = new CookOrderLines(o);
                cookFood.ShowDialog();

                if(DialogResult == true)
                {
                    loadOrders(_accessToken.CookID);
                }
            }
            else
            {
                MessageBox.Show("Please select an order.");
            }
        }

        private void btnKitchenOrder_MarkCompleted_Click(object sender, RoutedEventArgs e)
        {
            var o = (Order)gridKitchenOrders.SelectedItem;

            if(o != null)
            {
                try
                {
                    var orderLines = myOrderManager.SelectOrderLines_CurrentOrderByID(o.OrderID);
                    var orderLinesFiltered = from OrderLine oL in orderLines
                                             where oL.Completed == true
                                             select oL;

                    if(orderLines.Count() == orderLinesFiltered.Count())
                    {
                        o.Completed = true;
                        o.DateCompleted = DateTime.Now;

                        try
                        {
                            if(myOrderManager.EditOrder(o) == true)
                            {
                                MessageBox.Show("Success! Order marked as completed.");
                                loadOrders(_accessToken.CookID);
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                                                  
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                MessageBox.Show("Please select an order.");
            }
        }

        private void btnKitchenOrder_AssignOrders_Click(object sender, RoutedEventArgs e)
        {
            var o = (Order)gridOrderSearchResults.SelectedItem;

            if(o != null)
            {
                var assign = new AssignOrder(o);
                assign.ShowDialog();
            }
            else
            {
                MessageBox.Show("Could not display assignment window. Please contact your administrator.");
            }

            refreshOrderGrid();
        }

        private void btnKitchenOrder_Refresh_Click(object sender, RoutedEventArgs e)
        {
            loadOrders(_accessToken.CookID);
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
