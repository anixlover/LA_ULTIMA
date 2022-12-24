<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="WEB.IniciarSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        body {
            background-image: url('assets/images/small/Portada2.png');
            background-position: center;
            background-repeat: no-repeat;
            background-size: cover;
            background-attachment: fixed;
        }
    </style>
    <!-- icons -->
    <link href="../assets/css/icons.min.css" rel="stylesheet" type="text/css" />
    <!-- css -->
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/bootstrap-creative.min.css" rel="stylesheet" />
    <link href="assets/css/app-creative.min.css" rel="stylesheet" />
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/app.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/libs/sweetalert2/sweetalert2.min.css" rel="stylesheet" />
    <link href="../assets/libs/flatpickr/flatpickr.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/libs/selectize/css/selectize.bootstrap3.css" rel="stylesheet" type="text/css" />
    <!-- Tour css -->
    <link href="../assets/libs/hopscotch/css/hopscotch.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
        <div class="auth-fluid" style="background-image: url('https://localhost:44363/assets/images/small/Portada2.png'); background-position: center; background-attachment: fixed; background-repeat: no-repeat">
            <div class="auth-fluid-form-box">
                <div class="align-items-center d-flex h-100">
                    <div class="card-body bg-White">
                        <a href="Home.aspx">
                            <img src="assets/images/Icono.ico" style="width: 50%" />
                        </a>

                        <div class="form-group" runat="server">
                            Usuario:
                            <asp:TextBox ID="txtDNI" runat="server" placeholder="DNI" MinLength="8" MaxLength="8" BackColor="White" Width="100%" TextMode="SingleLine" CssClass="form-control"></asp:TextBox>
                        </div>
                        Contraseña:
                    <div class="input-group input-group-merge">
                        <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" placeholder="Contraseña" BackColor="White" TextMode="Password"></asp:TextBox>
                        <div class="input-group-append" data-password="false">
                            <div class="input-group-text">
                                <span class="password-eye font-12"></span>
                            </div>
                        </div>
                    </div>
                        <br />
                        <asp:HyperLink ID="hlCambiarContraseña" runat="server" NavigateUrl="~/CambiarContraseña.aspx">¿Olvido su contraseña?</asp:HyperLink>
                        <asp:HyperLink ID="hlRegistrarCliente" runat="server" NavigateUrl="~/RegistrarClienteUE.aspx">¡Registrese!</asp:HyperLink>
                        <br />
                        <br />
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Button ID="btnIniciarSesion" CssClass="btn-lg btn-primary" runat="server" Text="Iniciar sesión" OnClick="btnIniciarSesion_Click" />
                                &nbsp;
                                <asp:Button ID="btnCancelar" CssClass="btn-lg btn-secondary" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script type="text/javascript">
        function validarInput() {
            document.getElementById("btnLogin").disabled = !document.getElementById("txtDni").value.length;
        }
    </script>

    <script type="text/javascript">
        function solonumeros(n) {
            key = e.keyCode || e.which;
            teclado = Int32Array(key);
            numeros = "0123456789";
            especiales = "8-37-38-46-146";
            teclado_especial = false;
            for (var i in especiales) {
                if (key == especiales[i]) {
                    teclado_especial = true; break;
                }
            }
            if (numeros.indexOf(teclado) == -1 && !teclado_especial) {
                return false;
            }

        }
    </script>
</body>
<!-- Plugins js-->
<script src="../assets/libs/flatpickr/flatpickr.min.js"></script>
<script src="../assets/libs/apexcharts/apexcharts.min.js"></script>
<script src="../assets/libs/selectize/js/standalone/selectize.min.js"></script>
<script src="assets/libs/sweetalert2/sweetalert2.all.min.js"></script>
<script src="assets/libs/sweetalert2/sweetalert2.min.js"></script>
<script src="../assets/libs/jquery-sparkline/jquery.sparkline.min.js"></script>
<!-- Vendor js -->
<script src="../assets/js/vendor.min.js"></script>
<!-- App js -->
<script src="../assets/js/app.min.js"></script>
<!-- Tour page js -->
<script src="../assets/libs/hopscotch/js/hopscotch.min.js"></script>
</html>
