<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="ListadoVehiculos.aspx.cs" Inherits="RentadoraWeb.Paginas.ListadoVehiculos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <br />
    <h1>Listado de vehículos retrasados.</h1>
    <br />
    <p>Presione el botón para realizar el listado de vehiúclos retrasados.</p>
    <div style="height: 135px">
        <asp:Label ID="txtError" CssClass="error" runat="server"></asp:Label>
        <br />
        <asp:Button ID="txtButton" runat="server" OnClick="txtButton_Click" Text="Realizar Listado" />
    </div>
    <br />
    <asp:GridView ID="GvRetrasados" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GvRetrasados_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="AlquilerMatricula" HeaderText="Matricula" />
            <asp:BoundField DataField="FechaInicio" HeaderText="Fecha de Inicio" />
            <asp:BoundField DataField="FechaFinal" HeaderText="Fecha de Entrega" />
            <asp:CommandField SelectText="Ver Detalles" ShowCancelButton="False" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:Label ID="txtMsg" runat="server"></asp:Label>
</asp:Content>
