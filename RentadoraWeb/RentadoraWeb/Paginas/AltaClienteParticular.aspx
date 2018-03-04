<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="AltaClienteParticular.aspx.cs" Inherits="RentadoraWeb.Paginas.AltaAlquilerParticular" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="altaParticular" ContentPlaceHolderID="Body" runat="server">
     <div style="height: 501px">
        <h1>Alta de un cliente del tipo Particular</h1><br />
        <br />
        <p>Por favor rellene el formulario a continuación: </p>
         <hr />
        <asp:Label ID="Label1" runat="server" Text="Nombre: " CssClass="etiqueta"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="borde"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="validarVacio" ControlToValidate="txtNombre" ErrorMessage="El nombre no puede ser vacío" ValidateEmptyText="True" CssClass="validators">*</asp:CustomValidator>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Apellido: " CssClass="etiqueta"></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server" CssClass="borde"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator6" runat="server" ClientValidationFunction="validarVacio" ControlToValidate="txtApellido" ErrorMessage="El apellido no puede ser vacío" ValidateEmptyText="True" CssClass="validators">*</asp:CustomValidator>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Año de inicio: " CssClass="etiqueta"></asp:Label>
        <asp:TextBox ID="txtAnio" runat="server" CssClass="borde"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="validarVacio" ControlToValidate="txtAnio" ErrorMessage="El año no puede ser vacío" ValidateEmptyText="True" CssClass="validators">*</asp:CustomValidator>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Teléfono: " CssClass="etiqueta"></asp:Label>
        <asp:TextBox ID="txtTelefono" runat="server" CssClass="borde"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="validarVacio" ControlToValidate="txtTelefono" ErrorMessage="El teléfono no puede ser vacío" ValidateEmptyText="True" CssClass="validators">*</asp:CustomValidator>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Tipo documento: " CssClass="etiqueta"></asp:Label>
        <asp:DropDownList ID="dwTipoDocumento" runat="server" CssClass="borde">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Identificación: " CssClass="etiqueta"></asp:Label>
        <asp:TextBox ID="txtCi" runat="server" CssClass="borde"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator4" runat="server" ClientValidationFunction="validarVacio" ControlToValidate="txtCi" ErrorMessage="La identificación no puede ser vacía" ValidateEmptyText="True" CssClass="validators">*</asp:CustomValidator>
        <br />
        <asp:Label ID="Label5" runat="server" Text="País del documento: " CssClass="etiqueta"></asp:Label>
        <asp:TextBox ID="txtPaidDoc" runat="server" CssClass="borde"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator5" runat="server" ClientValidationFunction="validarVacio" ControlToValidate="txtPaidDoc" ErrorMessage="Ingrese país de documento: " ValidateEmptyText="True" CssClass="validators">*</asp:CustomValidator>
        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="boton btn btn-success"/>
        <span><asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" Height="51px" Width="428px"/></span>
    </div>
</asp:Content>
