<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="RentadoraWeb.Paginas.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="inicio" ContentPlaceHolderID="Body" runat="server">
    <div>
        <h1>RentadoraWeb</h1>
        <br />
        <h2 id="txtBienvenida" runat="server"></h2>
        <br />
        <p>En el panel de navegación podrá encontrar las opciones disponibles. </p>  
    </div>
</asp:Content>
