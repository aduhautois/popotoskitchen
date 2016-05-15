namespace PopotosKitchenV2
{
    partial class frmCustomerListReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.popotokitchenDataSet = new PopotosKitchenV2.popotokitchenDataSet();
            this.CustomersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CustomersTableAdapter = new PopotosKitchenV2.popotokitchenDataSetTableAdapters.CustomersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.popotokitchenDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "CustomerListReport";
            reportDataSource1.Value = this.CustomersBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PopotosKitchenV2.CustomerListReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(984, 561);
            this.reportViewer1.TabIndex = 0;
            // 
            // popotokitchenDataSet
            // 
            this.popotokitchenDataSet.DataSetName = "popotokitchenDataSet";
            this.popotokitchenDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CustomersBindingSource
            // 
            this.CustomersBindingSource.DataMember = "Customers";
            this.CustomersBindingSource.DataSource = this.popotokitchenDataSet;
            // 
            // CustomersTableAdapter
            // 
            this.CustomersTableAdapter.ClearBeforeFill = true;
            // 
            // frmCustomerListReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmCustomerListReport";
            this.Text = "frmCustomerListReport";
            this.Load += new System.EventHandler(this.frmCustomerListReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.popotokitchenDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CustomersBindingSource;
        private popotokitchenDataSet popotokitchenDataSet;
        private popotokitchenDataSetTableAdapters.CustomersTableAdapter CustomersTableAdapter;
    }
}