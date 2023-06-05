using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace negocio
{
    public class CategoriasNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.id = (int)datos.Lector["Id"];
                    categoria.descripcion = (string)datos.Lector["Descripcion"];


                    lista.Add(categoria);
                }

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al capturar los datos de la tabla de CATEGORIA");
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //METODO EDITAR
        public int editar(Categoria categoria)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE CATEGORIAS SET Descripcion=@Descripcion WHERE Id=@Id");
                datos.setearParametro("@Id", categoria.id);
                datos.setearParametro("@descripcion", categoria.descripcion);
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

        public int agregar(Categoria categoria)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();
            string sql = "insert into CATEGORIAS (Descripcion)" +
                " values (@descripcion)";
            try
            {
                datos.setearConsulta(sql);
                datos.setearParametro("@descripcion", categoria.descripcion);
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
                datos.setearConsulta("delete from CATEGORIAS where Id= @id");
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
