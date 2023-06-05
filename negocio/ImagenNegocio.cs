using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace negocio
{
    public class ImagenNegocio
    {
        public List<ImagenProductos> listar(int idProducto)
        {
            List<ImagenProductos> lista = new List<ImagenProductos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    if ((int)datos.Lector["IdArticulo"] == idProducto)
                    {
                        ImagenProductos imagen = new ImagenProductos();
                        imagen.Id = (int)datos.Lector["Id"];
                        imagen.IdArticulo = (int)datos.Lector["IdArticulo"];
                        imagen.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                        lista.Add(imagen);
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al capturar los datos de la tabla de IMAGEN");
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        
        }

        public int eliminar(string url)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from IMAGENES where ImagenUrl= @Url");
                datos.setearParametro("@Url", url);
                resultado = datos.ejecutarUpdate();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return resultado;
        }

        public int agregar(ImagenProductos imagen)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();
            string sql = "insert into IMAGENES (IdArticulo, ImagenUrl)" +
                " values (@Producto, @Url)";
            try
            {
                datos.setearConsulta(sql);
                datos.setearParametro("@Producto", imagen.IdArticulo);
                datos.setearParametro("@Url", imagen.ImagenUrl);
                resultado = datos.ejecutarUpdate();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
                return resultado;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return resultado;
        }
    }
}
