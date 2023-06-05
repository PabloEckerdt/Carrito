<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="carritoCompras.Pages.carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./../fontawesome/css/all.min.css" rel="stylesheet" />
    <link href="./../Css/carrito.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="contenedor-carrito">
        <h1 style="text-align:center" class="my-4">MI CARRITO</h1>
        <%
            if (this.listCarrito == null || this.listCarrito.Count < 1)
            {%>
        <h3 style="text-align:center" class="mt-5">Carrito vacio</h3>
                <%}
                    else
                    {
                        decimal total = 0;%>
        <div class="contenedor-carrito">
            <%string urlImg = "./../Assets/NoImage.png";
                foreach(var lista in this.listCarrito)
            {if (lista.imagenArt != null)
                    {
                        urlImg = lista.imagenArt;
                    }%>
            
            <ul class="contenedor-art">
                <li>
                    <div class="foto">
                    <img src="<%=urlImg %>" alt="foto pequeña" />
                    </div>
                </li>
                <li>
                    <span class="cab">Titulo</span><br />
                    <span><%=lista.articulo.nombre %></span>
                </li>
                <li><span class="cab">Cantidad</span><br />
                    <span><%=lista.cantidad %></span>
                </li>
                <li><span class="cab">Precio unit</span><br />
                    <span><%=lista.articulo.precio.ToString("0.00") %></span>
                </li>
                <li><span class="cab">Subtotal</span><br />
                    <span><%=(lista.articulo.precio * lista.cantidad).ToString("0.00") %></span>
                </li>
                <li class="trash">
                    <a href="./carrito.aspx?id_art=<%=lista.articulo.id %>">
                        <img src="../icons/trash-solid.png" alt="Eliminar" class="trash" /></a>
                    
                </li>
            </ul>   
             <%
                     total = total + (lista.articulo.precio * lista.cantidad);
                 }%>
            <div class="footer-carrito">
                <asp:Button Text="Vaciar carrito" OnClick="vaciar_Click" CssClass="btn btn-danger" runat="server" />
                <div>    
                    <span class="total mx-2">TOTAL: $<%=total.ToString("0.00")%></span>
                    <asp:Button Text="COMPRAR" OnClick="comprar_Click" CssClass="btn btn-success mx-2" runat="server" />
                </div>
            </div>
        </div>
                <%}%>
    </main>
</asp:Content>
