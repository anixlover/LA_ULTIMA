<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Gestionar_Catalogo.aspx.cs" Inherits="WEB.Gestionar_Catalogo" %>

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
    <form id="form1" runat="server" method="POST">
        <div class="row">
            <div class="col-12">
                <div class="page-title-box">
                    <h4 class="page-title">GESTIONAR CATALOGO</h4>
                </div>
                <div class="card-box">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <%--TABLA--%>
                    <%--HeaderStyle-CssClass="table-borderless"--%>
                    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div>
                                <div class="row">
                                    <div class="col-6">
                                        <asp:DropDownList ID="ddlTipoMoldura" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoMoldura_SelectedIndexChanged1" CssClass="form-control" Width="50%"></asp:DropDownList>
                                    </div>
                                    <div class="col-6">
                                        <div class="form-group text-right m-b-0">
                                            <asp:Button ID="btnAgregarMoldura" class="btn btn-danger" runat="server" Text="➕ Agregar" OnClick="btnAgregarMoldura_Click" />
                                        </div>
                                    </div>
                                </div>
                                <asp:GridView ID="gvCatalogo" runat="server" CssClass="table-borderless table table-bordered table-hover"
                                    DataKeyNames="Codigo,T. de Moldura" AutoGenerateColumns="False"
                                    EmptyDataText="No existen registros, agreguen molduras a su catálogo" ShowHeaderWhenEmpty="True" OnRowDataBound="gvCatalogo_RowDataBound" OnRowCommand="gvCatalogo_RowCommand"
                                    AllowPaging="true" PageSize="5" OnPageIndexChanging="gvCatalogo_PageIndexChanging" HeaderStyle-CssClass="thead-dark">
                                    <Columns>
                                        <%--<asp:TemplateField HeaderText="Agregar al carrito de compras">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" CssClass="checkbox" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Imagen">
                                            <ItemTemplate>
                                                <img src='ObtieneImagen.ashx?id=<%# Eval("Codigo")%>' height="80px" width="80px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                                        <asp:BoundField DataField="T. de Moldura" HeaderText="T. de Moldura" />
                                        <asp:BoundField DataField="Largo" HeaderText="Largo" />
                                        <asp:BoundField DataField="Ancho" HeaderText="Ancho" />
                                        <asp:BoundField DataField="U. Metrica" HeaderText="U. Metrica" />
                                        <asp:BoundField DataField="Stock" HeaderText="Stock" />
                                        <asp:BoundField DataField="Precio V." HeaderText="Precio V." />
                                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnGetMoldura" Text="Consultar" class="btn btn-sm btn-warning"
                                                    CommandArgument="<%# Container.DataItemIndex %>" CommandName="getMoldura"
                                                    runat="server" data-toggle="modal" data-target="#modalDetalle" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:ButtonField ButtonType="Button" AccessibleHeaderText="btnActualizar" Text="Modificar" CommandName="Actualizar">
                                            <ControlStyle CssClass="btn btn-sm btn-blue" />
                                        </asp:ButtonField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <%--MODAL--%>

            <%--class="swal2-popup swal2-modal swal2-show"--%>
            <%--swal2-fade--%>
            <div class="modal fade" id="modalDetalle" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="dialog">
                    <div class="modal-content">
                        <asp:UpdatePanel runat="server" ID="upPanelModal" UpdateMode="Always">
                            <ContentTemplate>
                                <div class="modal-header">
                                    <p class="modal-title" id="tituloModal" runat="server" style="color: #000000; font-weight: bold">
                                        Moldura N°
                                        <asp:Label ID="lblId" runat="server" Text="..."></asp:Label>
                                    </p>
                                </div>
                                <div class="row">
                                    <div class="col-6">
                                        <div>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="Img1" Height="300px" Width="300px" runat="server" class="img-thumbnail" />
                                        </div>
                                    </div>
                                    <div class="col-6">
                                        <p style="color: #000000; font-style: normal; font-weight: bold">
                                            Medida:
                                            <asp:Label ID="lblmetrica" runat="server"></asp:Label>
                                        </p>
                                        <p style="color: #000000; font-style: normal; font-weight: bold">
                                            Ancho:
                                        <asp:Label ID="lblAncho" runat="server" ClientIDMode="Static"></asp:Label>
                                        </p>
                                        <p style="color: #000000; font-style: normal; font-weight: bold">
                                            Largo:
                                        <asp:Label ID="lblLargo" runat="server" ClientIDMode="Static"></asp:Label>
                                        </p>
                                        <p style="color: #000000; font-style: normal; font-weight: bold">
                                            Tipo:
                                            <asp:Label ID="lblTipo" runat="server"></asp:Label>
                                        </p>
                                        <p style="color: #000000; font-style: normal; font-weight: bold">Precio: S./<asp:Label ID="lblprecio" runat="server" ClientIDMode="Static"></asp:Label></p>
                                        <p style="color: #000000; font-style: normal; font-weight: bold">
                                            Descripción:<br />
                                            <asp:TextBox Style="resize: none;" ID="txtDescripcion" Rows="5" Columns="50" runat="server" MaxLength='1999' TextMode="MultiLine" Enabled="False" Width="90%" ReadOnly="True"></asp:TextBox>
                                        </p>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
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

        <!-- App js -->
        <%--<script src="../assets/js/app.min.js"></script>--%>
    </form>
</asp:Content>
