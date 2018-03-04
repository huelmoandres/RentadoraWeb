<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="AltaClienteEmpresa.aspx.cs" Inherits="RentadoraWeb.Paginas.AltaClienteEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="altaEmpresa" ContentPlaceHolderID="Body" runat="server">
    <div style="height: 396px">
        <h1>Alta de un cliente del tipo Empresa</h1><br />
        <br />
        <p>Por favor rellene el formulario a continuación: </p>
        <hr />
        <asp:Label ID="Label1" runat="server" Text="Nombre de contacto: " CssClass="etiqueta"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="borde"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="validarVacio" ControlToValidate="txtNombre" ErrorMessage="El nombre no puede ser vacío" ValidateEmptyText="True" CssClass="validators">*</asp:CustomValidator>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Año de inicio: " CssClass="etiqueta"></asp:Label>
        <asp:TextBox ID="txtAnio" runat="server" CssClass="borde"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="validarVacio" ControlToValidate="txtAnio" ErrorMessage="El año no puede ser vacío" ValidateEmptyText="True" CssClass="validators">*</asp:CustomValidator>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Teléfono: " CssClass="etiqueta"></asp:Label>
        <asp:TextBox ID="txtTelefono" runat="server" CssClass="borde"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="validarVacio" ControlToValidate="txtTelefono" ErrorMessage="El teléfono no puede ser vacío" ValidateEmptyText="True" CssClass="validators">*</asp:CustomValidator>
        <br />
        <asp:Label ID="Label4" runat="server" Text="RUT: " CssClass="etiqueta"></asp:Label>
        <asp:TextBox ID="txtRut" runat="server" CssClass="borde"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator4" runat="server" ClientValidationFunction="validarVacio" ControlToValidate="txtRut" ErrorMessage="El Rut no puede ser vacío" ValidateEmptyText="True" CssClass="validators">*</asp:CustomValidator>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Razón social: " CssClass="etiqueta"></asp:Label>
        <asp:TextBox ID="txtRazon" runat="server" CssClass="borde"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator5" runat="server" ClientValidationFunction="validarVacio" ControlToValidate="txtRazon" ErrorMessage="Debe agregar una razón social" ValidateEmptyText="True" CssClass="validators">*</asp:CustomValidator>
        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="boton btn btn-success"/>
        <span><asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" Height="51px" Width="428px"/></span>
    </div>
</asp:Content>
