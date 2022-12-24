<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="GestionarEstadosPedido.aspx.cs" Inherits="WEB.GestionarEstadosPedido" %>
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
        <div class="row">
            <div class="col-12">
               <div class="page-title-box">
                    <h4 class="page-title">GESTIONAR ESTADOS DE PEDIDOS</h4>
                </div>
                <div class="card-box">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="false" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" CssClass="table-borderless table table-bordered table-hover"
                            Width="100%" OnRowCommand="gvPedidos_RowCommand"
                            HeaderStyle-CssClass="thead-dark" AllowPaging="true" PageSize="7" OnPageIndexChanging="gvPedidos_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="PK_IS_Cod" HeaderText="Codigo de solicitud" />
                                <asp:BoundField DataField="VS_TipoSolicitud" HeaderText="Tipo" />
                                <asp:BoundField DataField="DTS_FechaRegistro" HeaderText="Fecha de Registro" />
                                <asp:BoundField DataField="DTS_FechaRecojo"  HeaderText="Fecha de Recojo" />
                                <asp:BoundField DataField="DS_ImporteTotal"  HeaderText="Importe" />
                                <asp:BoundField DataField="FK_VU_Dni"  HeaderText="Dni del cliente" />
                                <asp:BoundField DataField="Nombre"  HeaderText="Nombre y apellido" />
                                <asp:BoundField DataField="VSE_Nombre"  HeaderText="Estado" />
                                <asp:TemplateField HeaderText="Accion" >
                                    <ItemTemplate>
                                        <asp:Button runat="server" Text="Ver Detalles"  data-toggle="modal" data-target="#modalDetalle"
                                            CommandName="Ver detalles" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="modal fade bd-example-modal-xl" id="modalDetalle" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-xl" role="dialog">
                <div class="modal-content">
                    <asp:UpdatePanel runat="server" ID="upPanelModal" UpdateMode="Always">
                        <ContentTemplate>
                            <div class="modal-header">
                                <p class="modal-title" id="tituloModal" runat="server" style="color: #000000; font-weight: bold">
                                    Detalles de la solicitud 
                        <asp:Label ID="lblid" runat="server" Text="0"></asp:Label>
                                </p>
                            </div>
                            <div class="modal-body">
                                   <asp:GridView ID="gvPersonalizado" runat="server" DataKeyNames="PK_IMU_Cod" AutoGenerateColumns="False"
                                EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" CssClass="table-borderless table table-bordered table-hover" Width="100%"
                                OnRowCommand="gvPersonalizado_RowCommand" OnRowDataBound="gvPersonalizado_RowDataBound"
                                HeaderStyle-CssClass="thead-dark">
                                <Columns>
                                    <asp:TemplateField HeaderText="Imagen">
                                        <ItemTemplate>
                                            <img src='ObtenerImegenPersonalizada_2.ashx?id=<%# Eval("PK_IS_Cod")%>' height="60px" width="60px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PK_IMU_Cod"  HeaderText="Código" />
                                    <asp:BoundField DataField="PK_IS_Cod"  HeaderText="Código de solicitud" />
                                    <asp:BoundField DataField="DS_Largo"  HeaderText="Largo" />
                                    <asp:BoundField DataField="DS_Ancho"  HeaderText="Ancho" />
                                    <asp:BoundField DataField="VS_Comentario"  HeaderText="Comentario" />
                                    <asp:BoundField DataField="IS_Cantidad"  HeaderText="Cantidad" />                             
                                    <asp:BoundField DataField="FK_IMXUE_Cod"  HeaderText="Estado" />
                                    <asp:TemplateField HeaderText="Cambiar Estado">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlEstados2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstados2_SelectedIndexChanged"></asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnIncidentes2" runat="server" Text="Qué ocurrió?" Visible='<%# Incidente(Eval("FK_IMXUE_Cod").ToString()) %>' data-toggle="modal" data-target="#modalIncidendia" CommandArgument='<%# Container.DataItemIndex %>' CommandName="Incidencia" CssClass="btn btn-primary" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                                 <br />
                            <asp:GridView ID="gvDetalles" runat="server" DataKeyNames="PK_IMU_Cod" AutoGenerateColumns="False"
                                EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" Width="100%" CssClass="table-borderless table table-bordered table-hover" OnRowDataBound="gvDetalles_RowDataBound" OnRowCommand="gvDetalles_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Imagen">
                                        <ItemTemplate>
                                            <img src='ObtieneImagen.ashx?id=<%# Eval("PK_IM_Cod")%>' height="80px" width="80px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PK_IMU_Cod"  HeaderText="Código" />
                                    <asp:BoundField DataField="PK_IM_Cod"  HeaderText="Código de Moldura" />
                                    <asp:BoundField DataField="VTM_Nombre"  HeaderText="Tipo de Moldura" />
                                    <asp:BoundField DataField="IMU_Cantidad"  HeaderText="Cantidad" />
                                    <asp:BoundField DataField="FK_IMXUE_Cod"  HeaderText="Estado" />
                                    <asp:TemplateField HeaderText="Cambiar Estado">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlEstados" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstados_SelectedIndexChanged"></asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Moldes disponibles">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCantMoldes" runat="server" Text='<%#CantidadMolde(Eval("PK_IM_Cod").ToString())%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="IMU_MoldesUsados"  HeaderText="Moldes usados" />
                                    <asp:TemplateField HeaderText="Acción">
                                        <ItemTemplate>
                                            <asp:Button runat="server" Text="Asignar Moldes"  data-toggle="modal" data-target="#modalCantidadMoldes"
                                                Visible='<%# ExistenMoldes(int.Parse(Eval("PK_IM_Cod").ToString()),int.Parse(Eval("PK_IMU_Cod").ToString())) %>' CommandName="Asignar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning" />
                                            <asp:Button ID="btnDevolver" runat="server" Text="Devolver Moldes"  Visible='<%#HayMoldesEnUso(int.Parse(Eval("PK_IMU_Cod").ToString())) %>' CommandArgument='<%# Container.DataItemIndex %>' CommandName="Devolver" CssClass="btn btn-primary" />
                                            <asp:Button ID="btnIncidentes" runat="server" Text="Qué ocurrió?" Visible='<%# Incidente(Eval("FK_IMXUE_Cod").ToString()) %>' data-toggle="modal" data-target="#modalIncidendia" CommandArgument='<%# Container.DataItemIndex %>' CommandName="Incidencia" CssClass="btn btn-primary"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div class="row justify-content-end">
                            <div class="col text-right">
                            <asp:Button ID="btnComenzar" runat="server" Text="Comenzar" CssClass="btn-lg btn-success" OnClick="btnComenzar_Click" />
                                </div>
                            <div class="col text-right">
                                <asp:Button ID="btnGuardar" runat="server" CssClass="btn-lg btn-success" Text="Guardar" OnClick="btnGuardar_Click"/>
                            </div>
                            </div>
                           </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="modal fade bd-example-modal-lg" id="modalCantidadMoldes" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-sm" role="dialog">
                <div class="modal-content">
                    <asp:UpdatePanel runat="server" ID="upPanelModal3" UpdateMode="Always">
                        <ContentTemplate>
                            <div class="modal-header">
                                <p class="modal-title" id="P1" runat="server" style="color: #000000; font-weight: bold">
                                    Moldura N°
                                    <asp:Label ID="lblIdMoldura" runat="server" Text="0"></asp:Label>
                                </p>
                            </div>
                            <div class="row-sm">
                                <div class="col-sm">
                                    <p>Cuantos Moldes Requiere?</p>
                                    <asp:TextBox ID="txtCantidad" runat="server" placeholder="Cantidad" CssClass="form-control" pattern="[0-9]+" TextMode="Number" step="1" min="0" Width="50%"></asp:TextBox>
                                    <br />
                                    <asp:Button ID="btnAgregar" runat="server" Text="Asignar" CssClass="btn btn-success" OnClick="btnAgregar_Click" OnClientClick="cerrarModal()" />
                                    <br />
                                </div>
                                <br />
                                <br />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="modal fade bd-example-modal-lg" id="modalIncidendia" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-sm" role="dialog">
                <div class="modal-content">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-header">
                                <p class="modal-title" id="P2" runat="server" style="color: #000000; font-weight: bold">
                                    Moldura N°
                                    <asp:Label ID="lblmoldura2" runat="server" Text="0"></asp:Label>
                                </p>
                            </div>
                            <div class="row-sm">
                                <div class="col-sm">
                                    <p>Descripción</p>
                                    <br />
                                    <asp:TextBox ID="txtIncidente" runat="server" CssClass="form-control"></asp:TextBox>
                                    <br />
                                    <p>Cuantos días más Requiere?</p>
                                    <asp:TextBox ID="txtDias" runat="server" placeholder="Cantidad de dias" CssClass="form-control" pattern="[0-9]+" TextMode="Number" step="1" min="0" Width="50%"></asp:TextBox>
                                    <br />
                                    <asp:Button ID="btnAumentarDias" runat="server" Text="Asignar" CssClass="btn btn-success" OnClick="btnAumentarDias_Click" OnClientClick="cerrarModal2()" />
                                    <br />
                                </div>
                                <br />
                                <br />
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
        <script type="text/javascript">
            function cerrarModal() { $('#modalCantidadMoldes').modal('hide'); $('.modal-backdrop').hide(); }
        </script>
        <script type="text/javascript">
            function cerrarModal2() { $('#modalIncidendia').modal('hide'); $('#modalDetalle').modal('hide'); $('.modal-backdrop').hide(); }
        </script>
    </form>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="cph_Js" runat="server">
</asp:Content>--%>
