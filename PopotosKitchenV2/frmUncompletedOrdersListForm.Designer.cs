namespace PopotosKitchenV2
{
    partial class frmUncompletedOrdersListForm
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
            this.popotokitchenOrders = new PopotosKitchenV2.popotokitchenOrders();
            this.OrdersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrdersTableAdapter = new PopotosKitchenV2.popotokitchenOrdersTableAdapters.OrdersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.popotokitchenOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "UncompletedOrdersList";
            reportDataSource1.Value = this.OrdersBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PopotosKitchenV2.UncompletedOrderList.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(984, 561);
            this.reportViewer1.TabIndex = 0;
            // 
            // popotokitchenOrders
            // 
            this.popotokitchenOrders.DataSetName = "popotokitchenOrders";
            this.popotokitchenOrders.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // OrdersBindingSource
            // 
            this.OrdersBindingSource.DataMember = "Orders";
            this.OrdersBindingSource.DataSource = this.popotokitchenOrders;
            // 
            // OrdersTableAdapter
            // 
            this.OrdersTableAdapter.ClearBeforeFill = true;
            // 
            // frmUncompletedOrdersListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmUncompletedOrdersListForm";
            this.Text = "frmUncompletedOrdersListForm";
            this.Load += new System.EventHandler(this.frmUncompletedOrdersListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.popotokitchenOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource OrdersBindingSource;
        private popotokitchenOrders popotokitchenOrders;
        private popotokitchenOrdersTableAdapters.OrdersTableAdapter OrdersTableAdapter;
    }
}