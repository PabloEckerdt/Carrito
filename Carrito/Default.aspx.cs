using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace CarritoPablo
{
    public partial class _Default : Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        public List<Articulo> ListaFiltradaArticulos { get; set; }
        public ImagenNegocio negocioImg { get; set; }
        public List<ImagenProductos> listaImg { get; set; }
        public bool FiltroAvanzado { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Session.Add("ListaArticulos", negocio.listar());
            ListaArticulos = (List<Articulo>)Session["listaArticulos"];
            ListaFiltradaArticulos = ListaArticulos;
            negocioImg = new ImagenNegocio();

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Articulo> listaArticulos = (List<Articulo>)Session["listaArticulos"];
            ListaFiltradaArticulos = listaArticulos.FindAll(x => x.nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));
            
        }

        //protected void ddlCampo_SelectedIndexChange(object sender, EventArgs e)
        //{
        //    ListaFiltradaArticulos = listaArticulos.FindAll(x => x.nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));
        //}
    }
}