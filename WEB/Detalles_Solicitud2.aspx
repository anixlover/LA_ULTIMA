<%@ Page Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Detalles_Solicitud2.aspx.cs" Inherits="WEB.Detalles_Solicitud2" %>

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
                <h2 style="text-align: center;" class="page-title">Detalle del pedido</h2>
            </div>
            <div class="card-box">
                <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
                <div class="body table-responsive">
                    <input type="hidden" runat="server" id="valorObtenido" clientidmode="Static" />
                    <div class="card">
                        <div class="body">
                            <asp:UpdatePanel ID="UpdateDetalleSolicitudes" runat="server">
                                <ContentTemplate>
                                    <br />
                                    <br />

                                    <%--Codigo , Descripcion , Precio , Estado--%>
                                    <asp:GridView ID="gvDetalleSolicitud" runat="server" AutoGenerateColumns="false"
                                        EmptyDataText="No existen registros!"
                                        ShowHeaderWhenEmpty="True" CssClass="table-borderless table table-bordered table-hover">
                                        <Columns>
                                            <asp:BoundField DataField="PK_IM_Cod" HeaderText="Codigo Moldura" />
                                            <asp:BoundField DataField="VM_Descripcion" HeaderText="Descripcion Moldura" />
                                            <asp:BoundField DataField="VTM_Nombre" HeaderText="Nombre" />
                                            <asp:BoundField DataField="DMU_Precio" HeaderText="Precio" />
                                        </Columns>
                                    </asp:GridView>


                                    <asp:GridView ID="gvDetalleSolicitud2" runat="server" AutoGenerateColumns="false"
                                        EmptyDataText="No existen registros!"
                                        ShowHeaderWhenEmpty="True" CssClass="table-borderless table table-bordered table-hover">
                                        <Columns>
                                            <asp:BoundField DataField="PK_IS_Cod" HeaderText="Codigo Moldura" />
                                            <asp:BoundField DataField="VS_TipoSolicitud" HeaderText="Tipo solicitud" />
                                            <asp:BoundField DataField="VSE_Nombre" HeaderText="Estado" />
                                            <asp:BoundField DataField="DS_Largo" HeaderText="Medida largo" />
                                            <asp:BoundField DataField="DS_Ancho" HeaderText="Medida ancho" />
                                            <asp:BoundField DataField="IS_Cantidad" HeaderText="Cantidad" />
                                            <asp:BoundField DataField="DS_PrecioAprox" HeaderText="Precio aproximado" />
                                            <%--<asp:BoundField DataField="DS_ImporteTotal" HeaderText="Importe total" />--%>
                                        </Columns>
                                    </asp:GridView>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                            <br />
                            <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="col-md-12">
                                        <div class="col-sm-12" id="IdCalendar" align="center" runat="server" clientidmode="Static">
                                            <asp:Label ID="Label4" runat="server" class="form-label"><b>Fecha de entrega:</b></asp:Label>
                                            <asp:HiddenField runat="server" ID="HiddenField3" ClientIDMode="Static" />
                                            <div class="body table-responsive ">
                                                <asp:Calendar ID="Calendar1" runat="server" TodayDayStyle-BackColor="Wheat"></asp:Calendar>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                                
                            <br />
                            <div align="center">
                                <asp:LinkButton ID="btnConfirmar" runat="server" type="button" class="btn btn-success waves-effect waves-light" OnClick="btnConfirmar_Click">
                                                    <span class="btn-label"></span>Confirmar
                                </asp:LinkButton>
                                <%--end boto confirmar--%>


                                <%--boton regresar--%>
                                <button type="button" onclick="" class="btn btn-danger waves-effect">
                                    <a href="Administrar_Pedido.aspx" style="color: white"><span class="btn-label"><i class="mdi dripicons-return"></i></span>Volver Atrás</a>
                                </button>
                                <%--end boton regresar--%>
                            </div>
                        </div>
                        <%--boton regresar--%>
                    </div>
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
    </form>
</asp:Content>
