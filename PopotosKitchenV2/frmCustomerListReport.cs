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
    public partial class frmCustomerListReport : Form
    {
        CustomerManager custMgr = new CustomerManager();
        List<Customer> custList;

        public frmCustomerListReport()
        {
            InitializeComponent();
        }

        private void frmCustomerListReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'popotokitchenDataSet.Customers' table. You can move, or remove it, as needed.
            //this.CustomersTableAdapter.Fill(this.popotokitchenDataSet.Customers);

            custList = custMgr.GetCustomerList(1);

            ReportDataSource rds = new ReportDataSource("CustomerListReport", custList);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();

            this.reportViewer1.RefreshReport();
        }
    }
}
