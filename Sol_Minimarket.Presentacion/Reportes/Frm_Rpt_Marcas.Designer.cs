namespace Sol_Minimarket.Presentacion.Reportes
{
    partial class Frm_Rpt_Marcas
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
            this.uSPListadomaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_MiniMarket = new Sol_Minimarket.Presentacion.Reportes.DataSet_MiniMarket();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.uSP_Listado_maTableAdapter = new Sol_Minimarket.Presentacion.Reportes.DataSet_MiniMarketTableAdapters.USP_Listado_maTableAdapter();
            this.txt_p1 = new System.Windows.Forms.TextBox();
            this.USP_Listado_caBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.USP_Listado_maBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSPListadomaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadomaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_MiniMarket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_Listado_caBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_Listado_maBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadomaBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // uSPListadomaBindingSource
            // 
            this.uSPListadomaBindingSource.DataMember = "USP_Listado_ma";
            this.uSPListadomaBindingSource.DataSource = this.dataSet_MiniMarket;
            // 
            // dataSet_MiniMarket
            // 
            this.dataSet_MiniMarket.DataSetName = "DataSet_MiniMarket";
            this.dataSet_MiniMarket.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.uSPListadomaBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sol_Minimarket.Presentacion.Reportes.Rpt_Marcas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // uSP_Listado_maTableAdapter
            // 
            this.uSP_Listado_maTableAdapter.ClearBeforeFill = true;
            // 
            // txt_p1
            // 
            this.txt_p1.Location = new System.Drawing.Point(29, 38);
            this.txt_p1.Name = "txt_p1";
            this.txt_p1.Size = new System.Drawing.Size(100, 20);
            this.txt_p1.TabIndex = 2;
            this.txt_p1.Visible = false;
            this.txt_p1.TextChanged += new System.EventHandler(this.txt_p1_TextChanged);
            // 
            // USP_Listado_caBindingSource
            // 
            this.USP_Listado_caBindingSource.DataMember = "USP_Listado_ca";
            this.USP_Listado_caBindingSource.DataSource = this.dataSet_MiniMarket;
            // 
            // USP_Listado_maBindingSource
            // 
            this.USP_Listado_maBindingSource.DataMember = "USP_Listado_ma";
            this.USP_Listado_maBindingSource.DataSource = this.dataSet_MiniMarket;
            // 
            // uSPListadomaBindingSource1
            // 
            this.uSPListadomaBindingSource1.DataMember = "USP_Listado_ma";
            this.uSPListadomaBindingSource1.DataSource = this.dataSet_MiniMarket;
            // 
            // Frm_Rpt_Marcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_p1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Rpt_Marcas";
            this.Text = "Frm_Rpt_Marcas";
            this.Load += new System.EventHandler(this.Frm_Rpt_Marcas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadomaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_MiniMarket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_Listado_caBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_Listado_maBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadomaBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uSPListadomaBindingSource;
        private DataSet_MiniMarket dataSet_MiniMarket;
        private DataSet_MiniMarketTableAdapters.USP_Listado_maTableAdapter uSP_Listado_maTableAdapter;
        public System.Windows.Forms.TextBox txt_p1;
        private System.Windows.Forms.BindingSource USP_Listado_maBindingSource;
        private System.Windows.Forms.BindingSource USP_Listado_caBindingSource;
        private System.Windows.Forms.BindingSource uSPListadomaBindingSource1;
    }
}