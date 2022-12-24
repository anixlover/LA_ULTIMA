<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ReporteStockMoldura.aspx.cs" Inherits="WEB.ReporteStockMoldura" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="row table-responsive">
            <div class="col-12">
                <div class="page-title-box">
                    <h4 class="page-title">REPORTE DE STOCK DE MOLDURAS</h4>
                </div>
                <div class="card-box">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:GridView ID="gvMolduras" runat="server" CssClass="table-borderless table table-bordered table-hover"
                        DataKeyNames="Codigo,T. de Moldura" AutoGenerateColumns="False"
                        EmptyDataText="No existen registros, agreguen molduras a su catálogo" ShowHeaderWhenEmpty="True"
                        HeaderStyle-CssClass="thead-dark"  AllowPaging="true" PageSize="5"
                        OnPageIndexChanging="gvMolduras_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                            <asp:BoundField DataField="T. de Moldura" HeaderText="T. de Moldura" />
                            <asp:BoundField DataField="Largo" HeaderText="Largo" />
                            <asp:BoundField DataField="Ancho" HeaderText="Ancho" />
                            <asp:BoundField DataField="U. Metrica" HeaderText="U. Metrica" />
                            <asp:BoundField DataField="Stock" HeaderText="Stock" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="btnExport" CssClass="btn btn-danger" runat="server" Text="Export To PDF" OnClick = "ExportToPDF" /> 
                </div>
            </div>
        </div>
    </form>
</asp:Content>
