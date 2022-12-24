<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ReporteVentas.aspx.cs" Inherits="WEB.ReporteVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Bootstrap Tables css -->
    <link href="../assets/libs/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" type="text/css" />
    <!-- App css -->
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" id="bs-default-stylesheet" />
    <link href="../assets/css/app.min.css" rel="stylesheet" type="text/css" id="app-default-stylesheet" />
    <link href="../assets/css/bootstrap-dark.min.css" rel="stylesheet" type="text/css" id="bs-dark-stylesheet" />
    <link href="../assets/css/app-dark.min.css" rel="stylesheet" type="text/css" id="app-dark-stylesheet" />
    <!-- icons -->
    <link href="../assets/css/icons.min.css" rel="stylesheet" type="text/css" />
     <!-- Sweet Alert-->
    <link href="../assets/libs/sweetalert2/sweetalert2.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
         <div class="row">
            <div class="col-12">
                <div class="page-title-box">
                <h4 class="page-title">REPORTE DE VENTAS</h4>
                </div>
                <div class="card-box">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col pl-0">
                                    Fecha Inicio:
                                    <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col">
                                    Fecha Fin:
                                    <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <br />
                                <asp:Button ID="btnBuscar" runat="server" Text="🔎" CssClass="btn btn-primary" OnClick="btnBuscar_Click"/>
                                <br />
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-12 pl-0">
                                    <asp:GridView ID="gvVentas" runat="server" CssClass="table-borderless table table-bordered table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="No existen registros!" ShowHeaderWhenEmpty="True" HeaderStyle-CssClass="thead-dark">
                                    <Columns>
                                        <asp:BoundField DataField="PK_IS_Cod" HeaderText="Codigo" />
                                        <asp:BoundField DataField="VS_TipoSolicitud" HeaderText="Tipo" />
                                        <asp:BoundField DataField="DS_ImporteTotal" HeaderText="Importe" />
                                        <asp:BoundField DataField="DTS_FechaRecojo" HeaderText="Fecha" />
                                        <asp:BoundField DataField="FK_VU_Dni" HeaderText="DNI cliente" />
                                        <asp:BoundField DataField="IP_TipoCerficado" HeaderText="Certificado" />
                                    </Columns>
                                    </asp:GridView>
                                </div>

                                  
                            </div>
                            <div class="row mb-1">
                                 <asp:Button ID="btnExport"  CssClass="btn btn-danger" runat="server" Text="Export To PDF" OnClick = "ExportToPDF" />   
                            </div>
                            <div class="row"  style="color: #008000; font-weight: bold; font-style: inherit; font-size: 20px">
                                 Total: S/. <asp:Label ID="lbltotal" runat="server" Text="0.00"></asp:Label>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

         <!-- Vendor js -->
    <script src="../assets/js/vendor.min.js"></script>

    <!-- Plugin js-->
    <script src="../assets/libs/dropzone/min/dropzone.min.js"></script>
    <script src="../assets/libs/dropify/js/dropify.min.js"></script>
    <script src="../assets/libs/parsleyjs/parsley.min.js"></script>
    <script src="../assets/libs/jquery-mask-plugin/jquery.mask.min.js"></script>
    <script src="../assets/libs/autonumeric/autoNumeric-min.js"></script>

    <!-- Validation init js-->
    <script src="../assets/js/pages/form-validation.init.js"></script>
    <script src="../assets/js/pages/form-fileuploads.init.js"></script>

    <!-- Init js-->
    <script src="../assets/js/pages/form-masks.init.js"></script>

    <!-- App js -->
    <script src="../assets/js/app.min.js"></script>
    <script src="assets/js/Aplicacion/UploadFile.js"></script>
    <!-- Validation init js-->
    <script src="../assets/js/pages/form-validation.init.js"></script>
        <!-- Sweet Alerts js -->
    <script src="../assets/libs/sweetalert2/sweetalert2.min.js"></script>
    <script src="assets/libs/sweetalert2/sweetalert2.all.min.js"></script>

    <!-- Sweet alert init js-->
    <script src="../assets/js/pages/sweet-alerts.init.js"></script>

    <script src="../../plugins/sweetalert/sweetalert.min.js"></script>

    </form>
</asp:Content>
