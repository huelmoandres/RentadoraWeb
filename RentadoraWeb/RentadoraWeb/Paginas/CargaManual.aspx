<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="CargaManual.aspx.cs" Inherits="RentadoraWeb.Paginas.CargaManual" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <br />
    <h1>Carga Manual.</h1>
    <br />
    <p>Realiza click en el botón correspondiente a la carga que desea realizar.</p>

    <asp:Button ID="btnCargaTipos" runat="server" CssClass="btn btn-primary" Text="Cargar Tipos" OnClick="btnCargaTipos_Click" />
    <asp:Button ID="btnCargaVehiculos" runat="server" CssClass="btn btn-primary" Text="Cargar Vehiculos" OnClick="btnCargaVehiculos_Click" />
    <br />
    <br />
    <asp:Label ID="lblError" runat="server" Text="" CssClass="error"></asp:Label>
    <asp:Label ID="lblExito" runat="server" Text="" CssClass="exito"></asp:Label>
</asp:Content>
