using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Windows.Forms;

namespace carritoCompras
{
    public partial class detalles : System.Web.UI.Page
    {
        public Articulo articulo { get; set; }
        public List<ImagenProductos> listaImg { get; set; }
        public List<Carrito> listaProductos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Response.Redirect("./../default.aspx");
            }

            string id = Request.QueryString["id"];
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> listaArticulos = negocio.listar($" where a.id={id}");
            this.articulo = listaArticulos[0];
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            listaImg = imagenNegocio.listar(int.Parse(id));
        }

        protected void agregarCarrito_Click(object sender, EventArgs e)
        {

            string urlIm = "https://www.bicifan.uy/wp-content/uploads/2016/09/producto-sin-imagen.png";
            if (listaImg.Count > 0 && listaImg[0] != null)
            {
                urlIm = listaImg[0].ImagenUrl;
            }
            Carrito productoEnCarrito = new Carrito(this.articulo, urlIm);
            List<Carrito> listaProductosEnCarrito = (List<Carrito>)Session["carrito"];
            if(listaProductosEnCarrito == null)
            {
                listaProductosEnCarrito = new List<Carrito>();
                listaProductosEnCarrito.Add(productoEnCarrito);
            }
            else
            {
                int estaEnCarrito = this.productoEnCarrito(productoEnCarrito, listaProductosEnCarrito);
                if (estaEnCarrito > -1)
                    listaProductosEnCarrito[estaEnCarrito].cantidad += productoEnCarrito.cantidad;
                else listaProductosEnCarrito.Add(productoEnCarrito);
            }
            Session.Add("carrito", listaProductosEnCarrito);
        }

        protected int productoEnCarrito(Carrito productoEnCarrito, List<Carrito> listaProductosEnCarrito) 
        {
            int index = 0;
            foreach (var item in listaProductosEnCarrito)
            {
                if(item.articulo.id == productoEnCarrito.articulo.id)
                {
                    return index;
                } 
                index++;
            }
            return -1;
        }
    }
}