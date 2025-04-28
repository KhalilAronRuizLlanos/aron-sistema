using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sol_Minimarket.Presentacion.Reportes
{
    public partial class Frm_Rpt_Categorias : Form
    {
        public Frm_Rpt_Categorias()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Categorias_Load(object sender, EventArgs e)
        {
            this.uSP_Listado_caTableAdapter.Fill(this.dataSet_MiniMarket.USP_Listado_ca, cTexto: txt_p1.Text);
            this.reportViewer1.RefreshReport();
        }

        private void txt_p1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
