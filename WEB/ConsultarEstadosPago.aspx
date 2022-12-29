<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="ConsultarEstadosPago.aspx.cs" Inherits="WEB.ConsultarEstadosPago" %>

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
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="cph_Js" runat="server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-12">
            <div class="page-title-box">
                <h4 class="page-title">MIS PEDIDOS</h4>
            </div>
            <div class="card-box">
                <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlEstadoSolicitud" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstadoSolicitud_SelectedIndexChanged" CssClass="form-control" Width="25%"></asp:DropDownList>
                        <br />
                        <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="false" OnRowCommand="gvPedidos_RowCommand" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" CssClass="table-borderless table table-bordered table-hover" Width="100%"
                            HeaderStyle-CssClass="thead-dark">
                            <Columns>
                                <asp:BoundField DataField="PK_IS_Cod" HeaderText="Codigo de solicitud" />
                                <asp:BoundField DataField="DTS_FechaEmicion" HeaderText="Fecha de emision del pago" />
                                <asp:BoundField DataField="DTS_FechaRecojo" HeaderText="Fecha de Recojo" />
                                <asp:BoundField DataField="VS_TipoSolicitud" HeaderText="Tipo" />
                                <asp:BoundField DataField="DS_ImporteTotal" HeaderText="Importe" />
                                <asp:BoundField DataField="VSE_Nombre" HeaderText="Estado" />
                                <asp:TemplateField HeaderText="Accion">
                                    <ItemTemplate>
                                        <asp:Button runat="server" DataKeyNames="PK_IS_Cod,VSE_Nombre" Text="Pago 💵"
                                            Visible='<%# ValidacionEstado1(Eval("VSE_Nombre").ToString()) %>'
                                            CommandName="Pago" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-soft-blue" />
                                        <asp:Button runat="server" Text="Actualizar"
                                            Visible='<%# ValidacionEstado2(Eval("VSE_Nombre").ToString()) %>'
                                            CommandName="Actualizar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-success" />
                                        <asp:Button runat="server" Text="Ver Detalles" data-toggle="modal" data-target="#modalDetalle"
                                            CommandName="Ver detalles" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-success" />
                                        <asp:Button runat="server" Text="Ver proceso" data-toggle="modal" data-target="#modalDetalle"
                                            Visible='<%# ValidacionEstado5(Eval("VSE_Nombre").ToString()) %>'
                                            CommandName="Ver proceso" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-success" />
                                        <asp:Button runat="server" Text="Ver incidencias"
                                            Visible='<%# ValidacionEstado6(Eval("VSE_Nombre").ToString()) %>'
                                            CommandName="Ver incidencias" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-success" data-toggle="modal" data-target="#modalIncidencias" />
                                        <asp:Button runat="server" Text="Aceptar"
                                            Visible='<%# ValidacionEstado3(Eval("VSE_Nombre").ToString(),Eval("VS_TipoSolicitud").ToString()) %>'
                                            CommandName="Aceptar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-success" />
                                        <asp:Button runat="server" Text="Rechazar"
                                            Visible='<%# ValidacionEstado3(Eval("VSE_Nombre").ToString(),Eval("VS_TipoSolicitud").ToString()) %>'
                                            CommandName="Rechazar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-danger" />
                                        <asp:Button runat="server" Text="Recotizar"
                                            Visible='<%# ValidacionEstado7(Eval("VSE_Nombre").ToString(),Eval("VS_TipoSolicitud").ToString()) %>'
                                            CommandName="Recotizar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning" data-toggle="modal" data-target="#modalRecotizar" />

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalIncidencias" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="dialog">
            <div class="modal-content">
                <asp:UpdatePanel ID="UpIncidencias" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvIncidencias" runat="server" AutoGenerateColumns="False"
                            EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" CssClass="table-borderless table table-bordered table-hover" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Imagen Propia">
                                    <ItemTemplate>
                                        <img src='ObtenerImegenPersonalizada_2.ashx?id=<%# Eval("FK_IS_Cod")%>' height="60px" width="60px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Imagen">
                                    <ItemTemplate>
                                        <img src='ObtieneImagen.ashx?id=<%# Eval("PK_IM_Cod")%>' height="80px" width="80px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="FK_IS_Cod" HeaderText="Código de solicitud" />
                                <asp:BoundField DataField="PK_IM_Cod" HeaderText="Código de Moldura" />
                                <asp:BoundField DataField="VMXU_Incidente" HeaderText="Incidente" />
                                <asp:BoundField DataField="DTMXUI_Fecha" HeaderText="Fecha" />
                                <asp:BoundField DataField="FK_IMXUE_Cod" HeaderText="Estado de la moldura" />
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
                        <asp:GridView ID="gvPersonalizado" runat="server" DataKeyNames="PK_IS_Cod" AutoGenerateColumns="False"
                            EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" CssClass="table-borderless table table-bordered table-hover" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Imagen">
                                    <ItemTemplate>
                                        <img src='ObtenerImegenPersonalizada_2.ashx?id=<%# Eval("PK_IS_Cod")%>' height="60px" width="60px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PK_IS_Cod" HeaderText="Código de solicitud" />
                                <asp:BoundField DataField="DS_Largo" HeaderText="Largo" />
                                <asp:BoundField DataField="DS_Ancho" HeaderText="Ancho" />
                                <asp:BoundField DataField="VS_Comentario" HeaderText="Comentario" />
                                <asp:BoundField DataField="IS_Cantidad" HeaderText="Cantidad" />
                                <asp:BoundField DataField="DS_PrecioAprox" HeaderText="Precio Aprox(S/.)" />
                                <asp:BoundField DataField="DS_ImporteTotal" HeaderText="Importe total(S/.)" />
                            </Columns>
                        </asp:GridView>
                        <br />
                        <asp:GridView ID="gvDetalles" runat="server" DataKeyNames="PK_IM_Cod" AutoGenerateColumns="False"
                            EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" Width="100%" CssClass="table-borderless table table-bordered table-hover">
                            <Columns>
                                <asp:TemplateField HeaderText="Imagen">
                                    <ItemTemplate>
                                        <img src='ObtieneImagen.ashx?id=<%# Eval("PK_IM_Cod")%>' height="80px" width="80px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PK_IM_Cod" HeaderText="Código de Moldura" />
                                <asp:BoundField DataField="VM_Descripcion" HeaderText="Descripción de Moldura" />
                                <asp:BoundField DataField="VTM_Nombre" HeaderText="Tipo de Moldura" />
                                <asp:BoundField DataField="IMU_Cantidad" HeaderText="Cantidad" />
                                <asp:BoundField DataField="DMU_Precio" HeaderText="Precio" />
                            </Columns>
                        </asp:GridView>
                        <br />
                        <asp:GridView ID="gvProceso" runat="server" DataKeyNames="PK_IM_Cod" AutoGenerateColumns="False"
                            EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" Width="100%" CssClass="table-borderless table table-bordered table-hover">
                            <Columns>
                                <asp:TemplateField HeaderText="Imagen">
                                    <ItemTemplate>
                                        <img src='ObtieneImagen.ashx?id=<%# Eval("PK_IM_Cod")%>' height="80px" width="80px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PK_IM_Cod" HeaderText="Código de Moldura" />
                                <asp:BoundField DataField="VTM_Nombre" HeaderText="Tipo de Moldura" />
                                <asp:BoundField DataField="IMU_Cantidad" HeaderText="Cantidad" />
                                <asp:BoundField DataField="DMU_Precio" HeaderText="Precio" />
                                <asp:BoundField DataField="FK_IMXUE_Cod" HeaderText="Estado" />
                            </Columns>
                        </asp:GridView>
                        <br />
                        <asp:GridView ID="gvPersonalizado2" runat="server" DataKeyNames="PK_IS_Cod,PK_IMU_Cod" AutoGenerateColumns="False"
                            EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" CssClass="table-borderless table table-bordered table-hover" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Imagen">
                                    <ItemTemplate>
                                        <img src='ObtenerImegenPersonalizada_2.ashx?id=<%# Eval("PK_IS_Cod")%>' height="60px" width="60px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PK_IMU_Cod" HeaderText="Código" />
                                <asp:BoundField DataField="PK_IS_Cod" HeaderText="Código de solicitud" />
                                <asp:BoundField DataField="DS_Largo" HeaderText="Largo" />
                                <asp:BoundField DataField="DS_Ancho" HeaderText="Ancho" />
                                <asp:BoundField DataField="VS_Comentario" HeaderText="Comentario" />
                                <asp:BoundField DataField="IS_Cantidad" HeaderText="Cantidad" />
                                <asp:BoundField DataField="DS_PrecioAprox" HeaderText="Precio Aprox(S/.)" />
                                <asp:BoundField DataField="DS_ImporteTotal" HeaderText="Importe total(S/.)" />
                                <asp:BoundField DataField="FK_IMXUE_Cod" HeaderText="Estado" />
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalRecotizar" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel runat="server" ID="updPanelModal" UpdateMode="Always">
                    <ContentTemplate>
                        <div class="modal-header navbar">
                            <h4 class="modal-title" id="H1" runat="server">Recotización</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-12" style="text-align: center">
                                    <asp:Image ID="Img1" Height="300px" Width="300px" runat="server" class="img-thumbnail" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="row clearfix" style="justify-content: center;">
                                        <div class="form-group form-float">
                                            <label class="form-label">Codigo Solicitud:</label>
                                            <div class="form-line">
                                                <asp:TextBox ID="txtcodigoModal" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                <asp:TextBox ID="txtcodM" class="form-control" runat="server" Visible="false"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row clearfix" style="justify-content: center;">
                                        <div class="form-group form-float">
                                            <label class="form-label">Tipo Moldura :</label>
                                            <div class="form-line focused">
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtTMModal" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="row clearfix" style="justify-content: center;">
                                        <div class="form-group form-float">
                                            <label class="form-label">Largo :</label>
                                            <div class="form-line focused">
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtlargo" class="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row clearfix" style="justify-content: center;">
                                        <div class="form-group form-float">
                                            <label class="form-label">Ancho :</label>
                                            <div class="form-line focused">
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtancho" class="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row clearfix" style="justify-content: center;">
                                        <div class="form-group form-float" style="width: 194px">
                                            <label class="form-label">Cantidad :</label>
                                            <div class="form-line focused">
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtcantidadModal" class="form-control" max="500" min="1" runat="server" onkeyup="checkCantidad()" ClientIDMode="Static" type="number"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />

                            </div>
                            <div class="col-md-12">
                                <label class="form-label">Comentario :</label>
                                <div class="form-line focused">
                                    <asp:TextBox ID="txtDescripcionModal" class="form-control" runat="server" TextMode="MultiLine" Style="height: 85px;"></asp:TextBox>
                                    <input id="txtprecior" class="form-control" runat="server" clientidmode="Static" type="hidden" />

                                </div>
                            </div>
                            <br />
                            <div class="col-md-12">
                                <label class="form-label">Cotización :</label>
                                <div class="form-line focused">
                                    <asp:TextBox ID="txtCotización" class="form-control" runat="server" TextMode="MultiLine" Style="height: 360px;"></asp:TextBox>
                                    <input id="Hidden1" class="form-control" runat="server" clientidmode="Static" type="hidden" />

                                </div>
                            </div>
                        </div>
                        <div class="modal-footer btn-group-sm">
                            <asp:UpdatePanel ID="UpdatePanelA" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Button ID="btnActualizar" runat="server" Text="Recotizar" CssClass="btn btn-warning btn-group-sm" OnClick="btnActualizar_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <button type="button" class="btn btn-link waves-effect" data-dismiss="modal">Cerrar</button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Right bar overlay-->
    <div class="rightbar-overlay"></div>

    <!-- Vendor js -->
    <script src="../assets/js/vendor.min.js"></script>

    <!-- Bootstrap Tables js -->
    <script src="../assets/libs/bootstrap-table/bootstrap-table.min.js"></script>

    <!-- Init js -->
    <script src="../assets/js/pages/bootstrap-tables.init.js"></script>
</asp:Content>
