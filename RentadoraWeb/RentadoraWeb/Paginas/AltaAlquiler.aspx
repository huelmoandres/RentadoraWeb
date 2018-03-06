<%@ Page Title="AltaAlquiler" Language="C#" MasterPageFile="~/Maestra/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="AltaAlquiler.aspx.cs" Inherits="RentadoraWeb.Paginas.AltaAlquiler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <br />
    <h1>Verificar usuario</h1>
    <br />
    <p>Verificación de usuario registrado, por favor ingrese el documento del mismo.</p>

    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="validarVacio" ControlToValidate="txtBuscarUsuario" ErrorMessage="Debe ingresar una cédula" ValidateEmptyText="True">*</asp:CustomValidator>
    <asp:DropDownList ID="dwTipoCliente" runat="server">
        <asp:ListItem Selected="True">Particular</asp:ListItem>
        <asp:ListItem>Empresa</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="txtBuscarUsuario" runat="server"></asp:TextBox>
    <asp:Button ID="btnVerificarUsuario" runat="server" CssClass="btn btn-info" Text="Verificar" OnClick="btnVerificarUsuario_Click" />
    <br />
    <asp:Label ID="lblError" runat="server" Text="" CssClass="error"></asp:Label>
    
<asp:ValidationSummary ID="ValidationSummary1" runat="server" />

</asp:Content>
