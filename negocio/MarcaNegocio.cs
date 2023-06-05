using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca marca = new Marca();
                    marca.id = (int)datos.Lector["Id"];
                    marca.descripcion = (string)datos.Lector["Descripcion"];


                    lista.Add(marca);
                }

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al capturar los datos de la tabla de MARCAS");
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //METODO EDITAR
        public int editar(Marca marca)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE MARCAS SET Descripcion=@Descripcion WHERE Id=@Id");
                datos.setearParametro("@Id", marca.id);
                datos.setearParametro("@descripcion", marca.descripcion);
                resultado = datos.ejecutarUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
                return resultado;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return resultado;
        }

        public int agregar(Marca marca)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();
            string sql = "insert into MARCAS (Descripcion)" +
                " values (@descripcion)";
            try
            {
                datos.setearConsulta(sql);
                datos.setearParametro("@descripcion", marca.descripcion);
                resultado = datos.ejecutarUpdate();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex.Message);
                return resultado;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return resultado;
        }

        //METODO ELIMINAR
        public int eliminar(int id)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from MARCAS where Id= @id");
                datos.setearParametro("@id", id);
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

    }
}
