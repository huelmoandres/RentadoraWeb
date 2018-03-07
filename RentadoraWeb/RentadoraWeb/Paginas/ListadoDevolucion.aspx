<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="ListadoDevolucion.aspx.cs" Inherits="RentadoraWeb.Paginas.ListadoDevolucion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="devolucion" ContentPlaceHolderID="Body" runat="server">
    <br />
    <h1>Devolución vehículo</h1>
    <br />
    <asp:Label ID="lblSubTitulo" runat="server" Text="Ingrese matrícula del vehículo devuelto::"></asp:Label>
    <div style="height: 135px">
        <asp:Label ID="lblMatricula" runat="server" Text="Matrícula:"></asp:Label>
        <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="validarVacio" ControlToValidate="txtMatricula" ErrorMessage="Debe ingresar matrícula" ValidateEmptyText="True">*</asp:CustomValidator>
        <br />
        <br />
        <asp:Label ID="txtMsg" runat="server"></asp:Label>
        <asp:Button ID="txtButton" runat="server" OnClick="txtButton_Click" Text="Aceptar" />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
</asp:Content>
