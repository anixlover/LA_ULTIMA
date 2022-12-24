<%@ Page Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Administrar_Pedido.aspx.cs" Inherits="WEB.Administrar_Pedidos" %>

<%--dev alvaro--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Bootstrap Tables css -->
    <link href="../assets/libs/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" type="text/css" />

    <!-- App css -->
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" id="bs-default-stylesheet" />
    <link href="../assets/css/app.min.css" rel="stylesheet" type="text/css" id="app-default-stylesheet" />

    <link href="../assets/css/bootstrap-dark.min.css" rel="stylesheet" type="text/css" id="bs-dark-stylesheet" />
    <link href="../assets/css/app-dark.min.css" rel="stylesheet" type="text/css" id="app-dark-stylesheet" />

    <!-- icons -->
    <link href="../assets/css/icons.min.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server" method="POST">
        <div class="col-12">
            <div class="page-title-box">
                <h4 class="page-title">ADMINISTRAR PEDIDO</h4>
            </div>
            <div class="card-box">
                <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
                <div class="body table-responsive">
                    <%--<div class="header">
                    <h2>Administrar Pedidos
                                <small></small>
                    </h2>
                    <ul class="header-dropdown m-r--5">
                    </ul>
                </div>--%>
                    <input type="hidden" runat="server" id="valorObtenido" clientidmode="Static" />
                    <div class="card">
                        <div class="body">
                            <asp:UpdatePanel ID="UpdateSolicitudes" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddltipo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddltipo_SelectedIndexChanged"
                                        CssClass="form-control" Width="30%">
                                    </asp:DropDownList><br />
                                    <br />
                                    <asp:GridView ID="gvSolicitudes" DataKeyNames="PK_IS_Cod,VSE_Nombre,PK_VU_Dni"
                                        runat="server" AutoGenerateColumns="false" OnRowCommand="gvSolicitudes_RowCommand"
                                        EmptyDataText="No existen registros, agreguen molduras a su catálogo"
                                        ShowHeaderWhenEmpty="True" CssClass="table-borderless table table-bordered table-hover"
                                        AllowPaging="true" PageSize="10" OnPageIndexChanging="gvSolicitudes_PageIndexChanging" HeaderStyle-CssClass="thead-dark">
                                        <Columns>
                                            <asp:BoundField DataField="PK_IS_Cod" HeaderText="Codigo de solicitud" />
                                            <asp:BoundField DataField="VS_TipoSolicitud" HeaderText="Tipo" />
                                            <asp:BoundField DataField="PK_VU_Dni" HeaderText="DNI" />
                                            <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                                            <asp:BoundField DataField="VSE_Nombre" HeaderText="Estado" />
                                            <%--<asp:BoundField DataField="PK_IMU_Cod" Visible="false" HeaderText="NoVisible" />--%>
                                            <asp:TemplateField HeaderText="Detalles">
                                                <ItemTemplate>
                                                    <asp:Button runat="server" Text="Evaluar"  Visible='<%# ValidacionEstado(Eval("VSE_Nombre").ToString()) %>' CommandName="Evaluar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning" />
                                                    <asp:Button runat="server" Text="Ver"  CommandName="Ver detalles" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-success" />
                                                    <asp:Button runat="server" Text="Asignar Fecha"  CommandName="asignar fecha" Visible='<%# ValidacionEstado2(Eval("VSE_Nombre").ToString()) %>' CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-primary" />
                                                    <asp:Button runat="server" Text="Recibir Restante"  CommandName="Recibir Restante" Visible='<%# validacionEstado4(Eval("PK_IS_Cod").ToString()) %>' CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-primary" data-toggle="modal" data-target="#modalRestante"/>
                                                    <asp:Button runat="server" Text="Despachar"  CommandName="despachar" Visible='<%# validacionEstado3(Eval("PK_IS_Cod").ToString()) %>' CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-primary"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade bd-example-modal-lg" id="modalRestante" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-sm" role="dialog">
                <div class="modal-content">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="modal-header">
                                <p class="modal-title" id="P1" runat="server" style="color: #000000; font-weight: bold">
                                    Solicitud N°
                                    <asp:Label ID="lblidsol" runat="server" Text="0"></asp:Label>
                                </p>
                            </div>
                            <div class="row-sm">
                                <div class="col-sm">
                                    <p>Inserte Restante: <asp:Label ID="lblRestante" runat="server" Text="Label"></asp:Label> </p>
                                    <asp:TextBox ID="txtRestante" runat="server" placeholder="0.00" CssClass="form-control" TextMode="Number" step="0.01" min="0" Width="50%"></asp:TextBox>
                                    <br />
                                    <asp:Button ID="btnAgregar" runat="server" Text="Asignar" CssClass="btn btn-success" OnClick="btnAgregar_Click" />
                                    <br />
                                    <asp:Label ID="lblVuelto" runat="server" Text="0.00"></asp:Label>
                                </div>
                                <br />
                                <br />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
         <script type="text/javascript">
             function cerrarModal() { $('#modalRestante').modal('hide'); $('.modal-backdrop').hide(); }
         </script>
        <!-- Right bar overlay-->
        <div class="rightbar-overlay"></div>

        <!-- Vendor js -->
        <script src="../assets/js/vendor.min.js"></script>

        <!-- Bootstrap Tables js -->
        <script src="../assets/libs/bootstrap-table/bootstrap-table.min.js"></script>

        <!-- Init js -->
        <script src="../assets/js/pages/bootstrap-tables.init.js"></script>
        <script src="../../plugins/sweetalert/sweetalert.min.js"></script>

        <!-- Sweet Alerts js -->
        <script src="../assets/libs/sweetalert2/sweetalert2.min.js"></script>
        <script src="assets/libs/sweetalert2/sweetalert2.all.min.js"></script>

        <!-- Sweet alert init js-->
        <script src="../assets/js/pages/sweet-alerts.init.js"></script>
    </form>
</asp:Content>
