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
    public partial class Frm_Almacenes : Form
    {
        public Frm_Almacenes()
        {
            InitializeComponent();
        }

        #region "Mis Variables"
        int Codigo_al = 0; //Codigo de la categoria
        int Estadoguarda = 0; //Sin ninguna accion

        #endregion

        #region "Mis metodos"
        private void Formato_al()
        {
            Dgv_principal.Columns[0].Width = 100;
            Dgv_principal.Columns[0].HeaderText = "CÓDIGO_AL";
            Dgv_principal.Columns[1].Width = 300;
            Dgv_principal.Columns[1].HeaderText = "ALMACÉN";
        }
        private void Listado_al(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Almacenes.Listado_al(cTexto);
                this.Formato_al();
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
           
            if (String.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_al"].Value)))
            {
                MessageBox.Show("No se tiene informacion para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_al = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_al"].Value);
                Txt_descripcion_al.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_al"].Value);
            }
        }

        #endregion

        private void Frm_Almacenes_Load(object sender, EventArgs e)
        {
            this.Listado_al("%");
        }

        private void Dgv_principal_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"Error en columna {e.ColumnIndex}: {e.Exception.Message}");
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_al.Text==string.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                E_Almacenes oAl = new E_Almacenes();
                string Rpta = "";
                oAl.Codigo_al = this.Codigo_al;
                oAl.Descripcion_al = Txt_descripcion_al.Text.Trim();
                Rpta = N_Almacenes.Guardar_al(Estadoguarda, oAl);
                if (Rpta=="OK")
                {
                    this.Listado_al("%");
                    MessageBox.Show("Se guardaron los datos correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; //Sin ninguna accion
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    Txt_descripcion_al.Text = "";
                    Tbc_principal.SelectedIndex = 0; //Pestaña de listado
                    Txt_descripcion_al.ReadOnly = true; //Deshabilitar el textbox para ingresar datos
                    this.Codigo_al = 0; //Limpiar el codigo de la categoria
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
            Txt_descripcion_al.Text = "";
            Txt_descripcion_al.ReadOnly = false; //Habilitar el textbox para ingresar datos
            Tbc_principal.SelectedIndex = 1; //Pestaña de datos
            Txt_descripcion_al.Focus();
            

        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Seleciona_item();
            Tbc_principal.SelectedIndex = 1;
            Txt_descripcion_al.ReadOnly = false; //Habilitar el textbox para ingresar datos
            Txt_descripcion_al.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 0; //Sin ninguna accion
            this.Codigo_al = 0; 
            Txt_descripcion_al.Text = "";
            Txt_descripcion_al.ReadOnly = true; //Deshabilitar el textbox para ingresar datos
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
            this.Codigo_al = 0; 
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["Codigo_al"].Value)))
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
                    this.Codigo_al = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["Codigo_al"].Value);
                    Rpta = N_Almacenes.Eliminar_al(this.Codigo_al);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_al("%");
                        MessageBox.Show("Se elimino el registro correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Codigo_al = 0; //Limpiar el codigo 
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
            this.Listado_al(Txt_buscar.Text.Trim());


        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Rpt_Almacenes oRpt3 = new Reportes.Frm_Rpt_Almacenes();
            oRpt3.txt_p1.Text = Txt_buscar.Text.Trim();
            oRpt3.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
