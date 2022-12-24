<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="EvaluarPedidosPersonalizados.aspx.cs" Inherits="WEB.Formulario_web13" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Plugins css -->
    <link href="../assets/libs/dropzone/min/dropzone.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/libs/dropify/css/dropify.min.css" rel="stylesheet" />

    <!-- App css -->
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" id="bs-default-stylesheet" />
    <link href="../assets/css/app.min.css" rel="stylesheet" type="text/css" id="app-default-stylesheet" />

    <link href="../assets/css/bootstrap-dark.min.css" rel="stylesheet" type="text/css" id="bs-dark-stylesheet" />
    <link href="../assets/css/app-dark.min.css" rel="stylesheet" type="text/css" id="app-dark-stylesheet" />

    <!-- icons -->
    <link href="../assets/css/icons.min.css" rel="stylesheet" type="text/css" />
    <style>
        input::-webkit-outer-spin-button,
        input::-webkit-inner-spin-button {
            -webkit-appearance: none;
            margin: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" method="POST">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row">
             <div class="col-12">
            <div class="page-title-box pl-0">
                <h4 class="page-title">EVALUAR PEDIDOS</h4>
            </div>
            <div class="card-box">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="gvPersonalizado" runat="server" DataKeyNames="PK_IS_Cod" AutoGenerateColumns="False"
                            EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" CssClass="table-borderless table table-bordered table-hover" Width="100%" OnRowCommand="gvPersonalizado_RowCommand"
                            AllowPaging="true" PageSize="4" OnPageIndexChanging="gvPersonalizado_PageIndexChanging"
                            HeaderStyle-CssClass="thead-dark">
                            <Columns>
                                <asp:TemplateField HeaderText="Imagen">
                                    <ItemTemplate>
                                        <img src='ObtenerImegenPersonalizada_2.ashx?id=<%# Eval("PK_IS_Cod")%>' height="60px" width="60px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PK_IS_Cod" HeaderText="Código de solicitud" />
                                <asp:BoundField DataField="VS_TipoSolicitud" HeaderText="Tipo" />
                                <asp:BoundField DataField="PK_VU_Dni" HeaderText="DNI" />
                                <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                                <asp:BoundField DataField="VSE_Nombre" HeaderText="Estado" />
                                <asp:TemplateField HeaderText="Accion">
                                    <ItemTemplate>
                                        <asp:Button runat="server" DataKeyNames="PK_IS_Cod,VSE_Nombre" ID="btnGetDatos" Text="Evaluar" 
                                            Visible='<%# ValidacionEstado(Eval("VSE_Nombre").ToString()) %>'
                                            CommandName="Evaluar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-soft-blue" data-toggle="modal" data-target="#modalDetalle" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        </div>
       
        <div class="modal fade" id="modalDetalle" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-lg" role="dialog">
                <div class="modal-content">
                    <asp:UpdatePanel runat="server" ID="upPanelModal" UpdateMode="Always">
                        <ContentTemplate>
                            <div class="modal-header">
                                <p class="modal-title" id="tituloModal" runat="server" style="color: #000000; font-weight: bold">
                                    Detalles de la solicitud 
                        <asp:Label ID="lblid" runat="server" Text="0"></asp:Label>
                                </p>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-6">
                                        <div>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="Img1" Height="300px" Width="300px" runat="server" class="img-thumbnail" />
                                        </div>
                                    </div>
                                    <div class="col-6">
                                        <p style="color: #000000; font-style: normal; font-weight: bold">
                                            Ancho:
                                        <asp:Label ID="lblAncho" runat="server" ClientIDMode="Static"></asp:Label>
                                        </p>
                                        <p style="color: #000000; font-style: normal; font-weight: bold">
                                            Largo:
                                        <asp:Label ID="lblLargo" runat="server" ClientIDMode="Static"></asp:Label>
                                        </p>
                                        <p style="color: #000000; font-style: normal; font-weight: bold">Cantidad:
                                            <asp:Label ID="lblcantidad" runat="server" Text="0"></asp:Label></p>
                                        <p style="color: #000000; font-style: normal; font-weight: bold">Precio Aprox: S./<asp:Label ID="lblprecio" runat="server" ClientIDMode="Static"></asp:Label></p>
                                        <p style="color: #000000; font-style: normal; font-weight: bold">Dias de elaboración:<asp:TextBox ID="txtNdias" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                        </p>
                                        <p style="color: #000000; font-style: normal; font-weight: bold">Importe Total:<asp:TextBox ID="txtImporte" CssClass="form-control" runat="server" TextMode="Number" step=".01"></asp:TextBox>
                                        </p>
                                        <p style="color: #000000; font-style: normal; font-weight: bold">
                                            Observación:
                                            <asp:TextBox ID="txtObservacion" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            <asp:Button ID="btnAsignarFecha_Importe" runat="server" Text="Asignar" CssClass="btn btn-warning" OnClick="btnAsignarFecha_Importe_Click" />
                                            <asp:Button ID="btnRechazar" runat="server" Text="Rechazar" CssClass="btn btn-danger" OnClick="btnRechazar_Click1" />
                                            <asp:Button ID="btnMandarObservacion" runat="server" Text="Mandar Observación" CssClass="btn btn-primary" OnClick="btnMandarObservacion_Click" />
                                    </div>
                                </div>
                            </div>
                            <br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
