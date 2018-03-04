<%@ Page Title="AltaAlquiler" Language="C#" MasterPageFile="~/Maestra/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="AltaAlquiler.aspx.cs" Inherits="RentadoraWeb.Paginas.AltaAlquiler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <br />
    <h1>Verificar usuario</h1>
    <br />
    <p>Verificación de usuario registrado, por favor ingrese la cédula del mismo.</p>

    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="validarVacio" ControlToValidate="txtBuscarUsuario" ErrorMessage="Debe ingresar una cédula" ValidateEmptyText="True">*</asp:CustomValidator>

    <asp:TextBox ID="txtBuscarUsuario" runat="server"></asp:TextBox>
    <asp:Button ID="btnVerificarUsuario" runat="server" Text="Verificar" OnClick="btnVerificarUsuario_Click" />

<asp:ValidationSummary ID="ValidationSummary1" runat="server" />

</asp:Content>
