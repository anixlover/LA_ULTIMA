<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="RegistrarClienteUE.aspx.cs" Inherits="WEB.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" id="bs-default-stylesheet" />
    <link href="../assets/css/app.min.css" rel="stylesheet" type="text/css" id="app-default-stylesheet" />

    <link href="../assets/css/bootstrap-dark.min.css" rel="stylesheet" type="text/css" id="bs-dark-stylesheet" />
    <link href="../assets/css/app-dark.min.css" rel="stylesheet" type="text/css" id="app-dark-stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID
        ="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>    
    <div class="auth-fluid" style="background-image: url('https://localhost:44363/assets/images/logo8.png'); background-position: left; background-repeat: no-repeat; background-attachment: inherit">
        <div class="auth-fluid-form-box" style="background-color: #FFFFFF">
            <div class="align-items-center d-flex h-100">
                <div class="card-body bg-white">
                    <div style="text-align:center"><img src="assets/images/logo1-sm.png" width="25%" /></div>
                    <p style="text-align: center; color: #000000;"><strong></strong>╣❖ REGISTRARSE ❖╠</p>
                    <div class="row">
                        <div class="col-md-6" runat="server">
                            DNI
                            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="DNI" MinLength="8" MaxLength="8" BackColor="White" Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            Nombres
                            <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control" placeholder="Nombres" BackColor="White" Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            Apellidos
                            <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" placeholder="Apellidos" BackColor="White" Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            Fecha de nacimiento
                            <asp:TextBox ID="txtFechNac" runat="server" CssClass="form-control" placeholder="mm/dd/yyyy" BackColor="White" Width="100%" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        Celular
                    <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control" placeholder="Celular" pattern="[0-9]+" MinLength="9" BackColor="White" Width="100%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        Correo Electrónico
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Correo electronico" BackColor="White" Width="100%"></asp:TextBox>
                    </div>
                    Contraseña   
                    <div class="input-group input-group-merge">
                        <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" placeholder="Contraseña" BackColor="White" TextMode="Password"></asp:TextBox>
                        <div class="input-group-append" data-password="false">
                            <div class="input-group-text" style="background-color: #CCCCCC; color: #000000;">
                                <span class="password-eye font-12"></span>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div style="text-align: center">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Button ID="btnRegistrar" CssClass="btn-lg btn-primary" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
                                &nbsp;
                                <asp:Button ID="btnCancelar" CssClass="btn-lg btn-secondary" runat="server" Text="Cancelar" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
