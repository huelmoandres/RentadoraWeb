<%@ Page Title="AltaAlquiler" Language="C#" MasterPageFile="~/Maestra/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="AltaAlquiler.aspx.cs" Inherits="RentadoraWeb.Paginas.AltaAlquiler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <h3>Verificar usuario</h3>
    <br />
    <p>Verificación de usuario registrado, por favor ingrese la cédula del mismo.</p>

    <asp:TextBox ID="txtBuscarUsuario" runat="server"></asp:TextBox>
    <asp:Button ID="btnVerificarUsuario" runat="server" Text="Verificar" OnClick="btnVerificarUsuario_Click" />

</asp:Content>
