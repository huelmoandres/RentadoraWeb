<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="ListadoVehiculos.aspx.cs" Inherits="RentadoraWeb.Paginas.ListadoVehiculos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <asp:GridView ID="GvDisponibles" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Matricula" HeaderText="Matricula" />
        </Columns>
    </asp:GridView>
</asp:Content>
