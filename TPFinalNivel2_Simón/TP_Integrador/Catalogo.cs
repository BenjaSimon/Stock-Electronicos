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
    public partial class frmCat : Form
    {
        private List<Articulo> listaArticulo;
        public frmCat()
        {
            InitializeComponent();
        }

        private void frmCat_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulo = negocio.listar();
            dgvListado.DataSource = listaArticulo;
            CargarImagen(listaArticulo[0].Imagen);
            dgvListado.Columns["Precio"].Visible = false;
            dgvListado.Columns["Imagen"].Visible = false;






        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            AltaArticulo AltaArt = new AltaArticulo();
            AltaArt.ShowDialog();
            
        }

        private void dgvListado_SelectionChanged(object sender, EventArgs e)
        {
           Articulo ArtSeleccionado =  (Articulo)dgvListado.CurrentRow.DataBoundItem;
          CargarImagen(ArtSeleccionado.Imagen);  
        }
        private void CargarImagen(string Imagen)
        {
            try
            {
            ptbImagenArticulo.Load(Imagen);

            }
            catch (Exception ex)
            {

                ptbImagenArticulo.Load("https://www.pngkey.com/png/detail/233-2332677_ega-png.png");
            }

        }

        
    }
}
