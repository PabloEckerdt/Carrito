<%@ Page Title="Catalogo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarritoPablo._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./Css/default.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="NavBarPlaceHolder" runat="server">
    
    <form class="row g-3 align-items-center justify-content-left text-center">
        <div class="col-md-5">
            <asp:TextBox 
                runat="server" 
                cssClass="form-control text-left" 
                BackColor="WhiteSmoke"
                ForeColor ="Black"
                id ="txtBuscar"
                type="search" 
                placeholder="Buscar" 
                aria-label="Buscar">
            </asp:TextBox>
        </div>
        <div class="col-auto">
            <asp:button runat="server" ID="btnBuscar" CssClass="btn btn-outline-light"
                type="submit" Text="Buscar" OnClick="btnBuscar_Click" >
       
            </asp:button>
        </div>
    </form>
<%--    <ul class="navbar-nav">
        <li class="nav-item">
           <asp:LinkButton ID="btnOpenPopup" runat="server" CssClass="nav-link active">

                <img src="../icons/advance_search.png" alt="advance_search">
           </asp:LinkButton>
        </li>
     </ul>--%>
    <li class="nav-item separator"></li>
    <li class="nav-item separator"></li>

    <div class="navbar-nav ml-auto">

<%--        <div class="navbar-nav">
            <asp:dropdownlist runat="server" 
                cssclass="form-control text-left" 
                backcolor="whitesmoke"
                forecolor ="black"
                id ="ddlcampo"
                type="search" 
                aria-label="buscar"
                placeholder="buscar campo">
                    <asp:listitem text="nombre" />
                    <asp:listitem text="descripcion" />
            </asp:dropdownlist>
            <asp:textbox runat="server" 
                cssclass="form-control text-left" 
                backcolor="whitesmoke"
                forecolor ="black"
                id ="txtbuscarvalor"
                onselectedidexchanged="txtbuscarvalor_selectedindexchange"
                type="search" 
                aria-label="buscar"
                placeholder="por valor">
            </asp:textbox>
        </div>--%>

    </div>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row row-cols-1 row-cols-md-5 g-4">
        
        <% 
            
            //List<dominio.Articulo> ListaArticulos = new List<dominio.Articulo>();
            foreach (dominio.Articulo articulo in ListaFiltradaArticulos)
            {
                string img = "./Assets/NoImage.png";
                listaImg = negocioImg.listar(articulo.id);
                if (listaImg != null && listaImg.Count > 0 )
                {
                    img = listaImg[0].ImagenUrl;
                }%>
          <div class="col">
            <div class="card h-100">
                <img src="<%=img %>" class="card-img-top imagen-tarjeta" alt="Foto del producto">
                <div class="card-body d-flex flex-column justify-content-between">
                    <h5 class="card-title"><%= articulo.nombre %></h5>
                    <p class="card-text"><%= articulo.descripcion %></p>
                    <a href="./pages/detalles.aspx?id=<%=articulo.id %>" class="btn btn-info mt-auto">Ver detalle</a>
                </div>
            </div>
        </div>
        <% } %>
    </div>
</asp:Content>
