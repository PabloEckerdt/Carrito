<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="detalles.aspx.cs" Inherits="carritoCompras.detalles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./../Css/detalles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor-detalle my-4" style="display: flex; height: 528px">
        <div class="carrusel">
            <div id="carouselProduct" class="carousel slide">

                <div class="carousel-inner">
                    <%int con = 0;
                        if(!listaImg.Any())
                        {%>
                    <div class="carousel-item active">
                        <img src="./../Assets/NoImage.png" class="d-block w-100" alt="foto articulo">
                    </div>  
                       <%}
                        foreach (var imagen in listaImg)
                        {
                            if (con == 0)
                            {%>
                    <div class="carousel-item active">
                        <img src="<%=imagen.ImagenUrl %>" class="d-block w-100" alt="foto articulo">
                    </div>
                            <%}
                            else
                            {%>
                    <div class="carousel-item">
                        <img src="<%=imagen.ImagenUrl %>" class="d-block w-100" alt="foto articulo">
                    </div>
                            <%}
                            con++;
                        } %>
                </div>
                <button class="carousel-control-prev" type="button" data-bs-target="#carouselProduct" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carouselProduct" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>
            </div>
        </div>

        <div class="ficha ms-2">
            <h3><%=articulo.nombre %></h3>
            <ul>
                <li>Codigo: <%= articulo.codigo%> </li>
                <li>Marca: <%= articulo.marca%></li>
                <li>Categoria: <%= articulo.categoria%></li>
                <li>Descripcion: <%= articulo.descripcion%></li>
                <li>Precio: <%= articulo.precio%></li>
            </ul>
            <asp:Button Text="Agregar" runat="server" CssClass="btn btn-primary" OnClick="agregarCarrito_Click" />
            <a href="../Default.aspx" class="btn btn btn-link">Volver</a>
        </div>
    </div>
</asp:Content>
