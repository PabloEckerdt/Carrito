using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar(string busqueda = "")
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            string consulta = "SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Id IdMarca, M.Descripcion Marca, C.Id IdCategoria, C.Descripcion Categoria, Precio" +
                " FROM ARTICULOS AS A INNER JOIN MARCAS AS M ON M.id = IdMarca INNER JOIN CATEGORIAS AS C ON C.Id = IdCategoria" + busqueda;

            try
            {
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.precio = (decimal)datos.Lector["Precio"];
                    
                    aux.marca = new Marca();
                    aux.marca.id = (int)datos.Lector["IdMarca"];
                    aux.marca.descripcion = (string)datos.Lector["Marca"];
                    
                    aux.categoria = new Categoria();
                    aux.categoria.id = (int)datos.Lector["IdCategoria"];
                    aux.categoria.descripcion = (string)datos.Lector["Categoria"];
                    
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al capturar los datos de la tabla de ARTICULOS");
                MessageBox.Show(ex.Message);
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //METODO EDITAR
        public int editar(Articulo articulo)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo=@Codigo, Nombre=@Nombre, Descripcion=@Descripcion, IdMarca=@IdMarca, IdCategoria=@IdCategoria, Precio=@Precio WHERE Id=@Id");
                datos.setearParametro("@Codigo", articulo.codigo);
                datos.setearParametro("@Nombre", articulo.nombre);
                datos.setearParametro("@Descripcion", articulo.descripcion);
                datos.setearParametro("@Precio", articulo.precio);
                datos.setearParametro("@IdMarca", articulo.marca.id);
                datos.setearParametro("@IdCategoria", articulo.categoria.id);
                datos.setearParametro("@Id", articulo.id);
                resultado = datos.ejecutarUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error "+ ex.Message);
                return resultado;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return resultado;
        }

        public int agregar(Articulo articulo)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();
            string sql = "insert into ARTICULOS (codigo, nombre, descripcion, IdMarca, IdCategoria, precio)" +
                " values (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @precio)";
            try
            {
                datos.setearConsulta(sql);
                datos.setearParametro("@codigo", articulo.codigo);
                datos.setearParametro("@nombre", articulo.nombre);
                datos.setearParametro("@descripcion", articulo.descripcion);
                datos.setearParametro("@precio", articulo.precio);
                datos.setearParametro("@idMarca", articulo.marca.id);
                datos.setearParametro("@idCategoria", articulo.categoria.id);
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
                datos.setearConsulta("delete from ARTICULOS where Id= @id");
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
