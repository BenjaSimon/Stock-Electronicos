using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try

            {
                conexionDB data = new conexionDB(); 
                conexion.ConnectionString = ("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true;");
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = ("Select A.Id, Codigo, A.Descripcion, Nombre, M.Descripcion as Marca, ImagenUrl from ARTICULOS A, MARCAS M where M.Id = A.IdMarca");
                comando.Connection = conexion;


                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)lector["Id"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Imagen = (string)lector["ImagenUrl"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)lector["Marca"];

                    lista.Add(aux);
                }

                data.CerrarConexion();
                return lista;
            }
           catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Agregar(Articulo nuevo)
        {
            conexionDB conexion = new conexionDB();

            try
            {
                conexion.SetearConsulta("insert into Articulo");


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
