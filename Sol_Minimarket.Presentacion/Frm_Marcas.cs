using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sol_Minimarket.Entidades;
using Sol_Minimarket.Negocio;


namespace Sol_Minimarket.Presentacion
{
    public partial class Frm_Marcas : Form
    {
        public Frm_Marcas()
        {
            InitializeComponent();
        }

        #region "Mis Variables"
        int Codigo_ma = 0; //Codigo de la categoria
        int Estadoguarda = 0; //Sin ninguna accion

        #endregion

        #region "Mis metodos"
        private void Formato_ma()
        {
            Dgv_principal.Columns[0].Width = 100;
            Dgv_principal.Columns[0].HeaderText = "CODIGO_CA";
            Dgv_principal.Columns[1].Width = 300;
            Dgv_principal.Columns[1].HeaderText = "MARCA";
        }
        private void Listado_ma(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Marcas.Listado_ma(cTexto);
                this.Formato_ma();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Estado_Botonesprincipales(bool lestado)
        {
            this.Btn_nuevo.Enabled = lestado;
            this.Btn_actualizar.Enabled = lestado;
            this.Btn_eliminar.Enabled = lestado;
            this.Btn_reporte.Enabled = lestado;
            this.Btn_salir.Enabled = lestado;

        }

        private void Estado_Botonesprocesos(bool lestado)
        {
            this.Btn_cancelar.Visible = lestado;
            this.Btn_guardar.Visible = lestado;
            this.Btn_retornar.Visible = !lestado;
        }

        private void Seleciona_item()
        {
           
            if (String.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_ma"].Value)))
            {
                MessageBox.Show("No se tiene informacion para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_ma = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ma"].Value);
                Txt_descripcion_ma.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_ma"].Value);
            }
        }

        #endregion

        private void Frm_Marcas_Load(object sender, EventArgs e)
        {
            this.Listado_ma("%");
        }

        private void Dgv_principal_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"Error en columna {e.ColumnIndex}: {e.Exception.Message}");
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_ma.Text==string.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                E_Marcas oMa = new E_Marcas();
                string Rpta = "";
                oMa.Codigo_ma = this.Codigo_ma;
                oMa.Descripcion_ma = Txt_descripcion_ma.Text.Trim();
                Rpta = N_Marcas.Guardar_ma(Estadoguarda, oMa);
                if (Rpta=="OK")
                {
                    this.Listado_ma("%");
                    MessageBox.Show("Se guardaron los datos correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; //Sin ninguna accion
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    Txt_descripcion_ma.Text = "";
                    Tbc_principal.SelectedIndex = 0; //Pestaña de listado
                    Txt_descripcion_ma.ReadOnly = true; //Deshabilitar el textbox para ingresar datos
                    this.Codigo_ma = 0; //Limpiar el codigo de la categoria
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            Estadoguarda = 1; //Nuevo
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            Txt_descripcion_ma.Text = "";
            Txt_descripcion_ma.ReadOnly = false; //Habilitar el textbox para ingresar datos
            Tbc_principal.SelectedIndex = 1; //Pestaña de datos
            Txt_descripcion_ma.Focus();
            

        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Seleciona_item();
            Tbc_principal.SelectedIndex = 1;
            Txt_descripcion_ma.ReadOnly = false; //Habilitar el textbox para ingresar datos
            Txt_descripcion_ma.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 0; //Sin ninguna accion
            this.Codigo_ma = 0; 
            Txt_descripcion_ma.Text = "";
            Txt_descripcion_ma.ReadOnly = true; //Deshabilitar el textbox para ingresar datos
            this.Estado_Botonesprincipales(true);
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0; //Pestaña de listado
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.Seleciona_item();
            this.Estado_Botonesprocesos(false);

            Tbc_principal.SelectedIndex = 1; //Pestaña de datos

        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0; //Pestaña de listado
            this.Codigo_ma = 0; 
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["Codigo_ma"].Value)))
            {
                MessageBox.Show("No se tiene informacion para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente desea eliminar el registro?", "Aviso del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Opcion == DialogResult.Yes)
                {
                    string Rpta = "";
                    this.Codigo_ma = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["Codigo_ca"].Value);
                    Rpta = N_Marcas.Eliminar_ma(this.Codigo_ma);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_ma("%");
                        MessageBox.Show("Se elimino el registro correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Codigo_ma = 0; //Limpiar el codigo 
                    }
                    else
                    {
                        MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_ma(Txt_buscar.Text.Trim());


        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Rpt_Marcas oRpt2 = new Reportes.Frm_Rpt_Marcas();
            oRpt2.txt_p1.Text = Txt_buscar.Text.Trim();
            oRpt2.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
