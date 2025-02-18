using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();

            conexionDB conexion = new conexionDB();

            try
            {
                conexion.SetearConsulta("Select Id, Descripcion FROM MARCAS");
                conexion.EjecutarConsulta ();

                while (conexion.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)conexion.Lector["Id"];
                    aux.Descripcion = (string)conexion.Lector["Descripcion"];
                    lista.Add(aux);
                }
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
    }
}
