<%@ Page Title="ListadoTipos" Language="C#" MasterPageFile="~/Maestra/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="ListadoTipos.aspx.cs" Inherits="RentadoraWeb.Paginas.ListadoTipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ListadoTipos" ContentPlaceHolderID="Body" runat="server">
    <br />
    <h1>Tipo de Vehículos.</h1>
    <asp:GridView ID="gvTipos" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Marca" HeaderText="Marca" />
            <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
            <asp:BoundField DataField="PrecioDiario" HeaderText="Precio Diario" />
        </Columns>
    </asp:GridView>
</asp:Content>
