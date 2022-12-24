<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="RegistrarClienteVendedor.aspx.cs" Inherits="WEB.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <br />
    <br />
    <br />
    <br />
    <div class="card" style="background-color: #DDD9D9">        
        <div class="card-body bg-white">
            <p style="text-align: center; font-size: large; font-style: normal; color: #CC0000; font-weight: bold;">╣❖ REGISTRAR CLIENTE ❖╠</p>
            <div style="text-align:center"><i data-feather="user-plus" class="icons-xxl" style="text-align: center"></i></div>
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
                            <asp:TextBox ID="txtFechNac" runat="server" CssClass="form-control" placeholder="mm/dd/yyyy" BackColor="White" TextMode="Date"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    Celular
                    <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control" placeholder="Celular" pattern="[0-9]+" MinLength="9" BackColor="White" Width="100%"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    Correo Electrónico
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Correo electronico" BackColor="White" Width="100%"></asp:TextBox>
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
</asp:Content>
