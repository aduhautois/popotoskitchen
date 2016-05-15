using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using BusinessObjects;
using Microsoft.Reporting.WinForms;

namespace PopotosKitchenV2
{
    public partial class frmUncompletedOrdersListForm : Form
    {
        OrderManager orderMgr = new OrderManager();
        List<Order> orderList = new List<Order>();

        public frmUncompletedOrdersListForm()
        {
            InitializeComponent();
        }

        private void frmUncompletedOrdersListForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'popotokitchenOrders.Orders' table. You can move, or remove it, as needed.
            //this.OrdersTableAdapter.Fill(this.popotokitchenOrders.Orders);

            orderList = orderMgr.GetOrderList(true);
            var filteredList = from Order o in orderList
                           where o.Completed == false
                           select o;

            ReportDataSource rds = new ReportDataSource("UncompletedOrdersList", filteredList);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();

            this.reportViewer1.RefreshReport();

            this.reportViewer1.RefreshReport();
        }
    }
}
