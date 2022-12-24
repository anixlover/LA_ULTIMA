<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarContraseña.aspx.cs" Inherits="WEB.CambiarContraseña" %>

<!DOCTYPE html>
<script type="text/javascript">
</script>

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
    <link href="assets/css/app-dark.min.css" rel="stylesheet" />
    <link href="assets/css/bootstrap-creative-dark.min.css" rel="stylesheet" />
    <link href="assets/css/app.min.css" rel="stylesheet" />
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
        <div class="auth-fluid" style="background-image: url('https://localhost:44363/assets/images/small/Portada2.png'); background-position: center; background-attachment: fixed; background-repeat: no-repeat">
            <div class="auth-fluid-form-box">
                <div class="align-items-center d-flex h-100">
                    <div class="card-body bg-White">
                        <img src="assets/images/logo1.png" style="width: 100%" />
                        <div class="form-group" runat="server">
                            <div class="form-group mb-auto">
                                <br />
                                <asp:TextBox ID="txtCorreo" name="texto" runat="server" class="form-control" type="email" placeholder="Correo Electronico" MinLength="8" MaxLength="150" BackColor="White" Width="100%"></asp:TextBox>
                                <br />
                                <div class="input-group input-group-merge">
                                    <asp:TextBox ID="txtContraseña" name="texto" runat="server" CssClass="form-control" type="password" placeholder="Nueva Contraseña" MinLength="8" MaxLength="50" BackColor="White" Width="100%"></asp:TextBox>
                                    <div id="txtpass1" runat="server" class="input-group-append" data-password="false">
                                        <div class="input-group-text">
                                            <span class="password-eye font-12"></span>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="input-group input-group-merge">
                                    <asp:TextBox ID="txtContraseña2" name="texto" runat="server" CssClass="form-control" type="password" placeholder="Confirmar Contraseña" MinLength="8" MaxLength="50" BackColor="White" Width="100%"></asp:TextBox>
                                    <div id="txtpass2" runat="server" class="input-group-append" data-password="false">
                                        <div class="input-group-text">
                                            <span class="password-eye font-12"></span>
                                        </div>
                                    </div>
                                </div>
                                <br />

                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar 📧" CssClass="btn btn-xl btn-success" OnClick="btnEnviar_Click" />
                                        <asp:Button ID="btnContraseña" class="btn btn-primary" runat="server" Text="Cambiar" OnClick="btnContraseña_Click" />
                                        &nbsp;
                                <asp:Button ID="btnCancelar1" class="btn btn-secondary" runat="server" Text="Cancelar" OnClick="btnCancelar1_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
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
</html>
