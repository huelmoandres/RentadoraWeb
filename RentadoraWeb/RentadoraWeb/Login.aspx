<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RentadoraWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="ScriptsRentadora/jquery.js"></script>
    <script src="ScriptsRentadora/bootstrap.bundle.js"></script>
    <link href="ScriptsRentadora/bootstrap.css" rel="stylesheet" />
    <script src="ScriptsRentadora/validaciones.js"></script>
    <title>Login</title>
</head>
<body>
    <div class="container show-top-margin separate-rows tall-rows">
        <form id="form1" runat="server">
            <div class="row">
                <div class="col-md-3">
                </div>
                <div class="col-md-6 .col-md-offset-3">
                    <div class="col-md-12">
                        <h1>Iniciar sesión</h1>
                    </div>
                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                            <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:CustomValidator ID="valUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="El campo usuario es obligatorio" ValidateEmptyText="True" ClientValidationFunction="validarVacio">*</asp:CustomValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblPass" runat="server" Text="Contraseña"></asp:Label>
                            <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:CustomValidator ID="valPass" runat="server" ControlToValidate="txtPass" ErrorMessage="El campo contraseña es obligatorio" ValidateEmptyText="True" ClientValidationFunction="validarVacio">*</asp:CustomValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                </div>
                <div class="col-md-6 col-md-offset-3">
                    <div class="row">
                        <div class="col-md-12 form-group">
                            <asp:Button ID="btnIngresar" CssClass="btn btn-info" runat="server" OnClick="btnIngresar_Click" style="margin-left: 0px" Text="Ingresar" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                        </div>
                        <div class="col-md-12 form-group">

                            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
