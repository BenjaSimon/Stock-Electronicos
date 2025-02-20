using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using Negocio;

namespace TP_Integrador
{
    public partial class AltaArticulo : Form
    {
        public AltaArticulo()
        {
            InitializeComponent();
            
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            Articulo art = new Articulo();
            ArticuloNegocio Negocio = new ArticuloNegocio();
            conexionDB conexion = new conexionDB();

            try
            {
                conexion.SetearConsulta("insert into ARTICULO");
                art.Codigo = txtCodigoA.Text;
                art.Nombre = txtNombreA.Text;
                art.Descripcion = txtDescripcionA.Text;

                Negocio.Agregar(art);
                MessageBox.Show("Agregado correctamente");
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
