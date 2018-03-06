<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="AltaAlquilerDatos.aspx.cs" Inherits="RentadoraWeb.Paginas.AltaAlquilerDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/jquery-ui.css" rel="stylesheet" />
    <link href="../ScriptsRentadora/bootstrap.css" rel="stylesheet" />
    <link href="../CSS/estilos.css" rel="stylesheet" />
    <script src="../ScriptsRentadora/jquery-ui.js"></script>
  <script>
      $(function () { $("#Body_fechaI").datepicker({ dateFormat: 'dd-mm-yy' }); });
      $(function () { $("#Body_fechaE").datepicker({ dateFormat: 'dd-mm-yy' }); });
  </script>
  <style type="text/css">
        #TextArea1 {
            height: 46px;
            width: 180px;
        }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <br />
    <h1>Alquiler del vehículo</h1>
    <br />
    <p>Por favor rellene el formulario a continuación:</p>
    <hr />
    <div id="formularioAlquiler" class="row">
        <div class="col-md-12">
            <asp:Label ID="Label2" runat="server" Text="Fecha inicio: " CssClass="etiqueta"></asp:Label>
            <asp:TextBox ID="fechaI" runat="server" CssClass="borde"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Fecha entrega: " CssClass="etiqueta"></asp:Label>
            <asp:TextBox ID="fechaE" runat="server" CssClass="borde"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="Hora de inicio: " CssClass="etiqueta"></asp:Label>
            <asp:TextBox ID="txtHoraI" runat="server" CssClass="borde"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Hora entrega: " CssClass="etiqueta"></asp:Label>
            <asp:TextBox ID="txtHoraE" runat="server" CssClass="borde"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" Text="Marcas: " CssClass="etiqueta"></asp:Label>
            <asp:DropDownList ID="listMarca" runat="server" CssClass="borde" OnSelectedIndexChanged="listMarca_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Selected="True" Value="1">Seleccionar Marca</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblModelo" runat="server" Text="Modelos: " CssClass="etiqueta"></asp:Label>
            <asp:DropDownList ID="listModelo" runat="server" CssClass="borde" AutoPostBack="True">
            </asp:DropDownList>
            <asp:Label ID="Label6" runat="server" Text="Vehículos disponibles: " CssClass="etiqueta" Visible="False"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" CssClass="etiqueta">
            </asp:GridView>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="validarVacio" ControlToValidate="fechaI" CssClass="etiqueta" ErrorMessage="-La fecha inicio no puede ser vacía " ValidateEmptyText="True" ForeColor="Red" Width="283px"></asp:CustomValidator>
            <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="validarVacio" ControlToValidate="fechaE" CssClass="etiqueta" ErrorMessage="-La fecha de entrega no puede ser vacía" ForeColor="Red" ValidateEmptyText="True" Width="323px"></asp:CustomValidator>
            <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="validarVacio" ControlToValidate="txtHoraI" CssClass="etiqueta" ErrorMessage="-La hora de inicio no puede ser vacía" ForeColor="Red" ValidateEmptyText="True" Width="299px"></asp:CustomValidator>
            <asp:CustomValidator ID="CustomValidator4" runat="server" ClientValidationFunction="validarVacio" ControlToValidate="txtHoraE" CssClass="etiqueta" ErrorMessage="-La hora de entrega no puede ser vacía" ForeColor="Red" ValidateEmptyText="True" Width="314px"></asp:CustomValidator>
        </div>
        <div class="col-md-12">   
            <asp:Button ID="btnAceptar" runat="server" Text="Enviar" CssClass="btn btn-success" OnClick="btnAlta_Click"/>
            <br />
            <asp:Label ID="lblError" runat="server" Text="" CssClass="error"></asp:Label>
            <asp:Label ID="lblExito" runat="server" Text="" CssClass="exito"></asp:Label>
            <br />
        </div> 
    </div>
</asp:Content>
