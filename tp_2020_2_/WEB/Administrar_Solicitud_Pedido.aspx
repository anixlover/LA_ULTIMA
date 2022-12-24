<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="Administrar_Solicitud_Pedido.aspx.cs" Inherits="WEB.Administrar_Solicitud_Pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <!-- Bootstrap Tables css -->
    <link href="../assets/libs/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" type="text/css" />

    <!-- App css -->
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/app.min.css" rel="stylesheet" type="text/css" />

    <link href="../assets/css/bootstrap-dark.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/app-dark.min.css" rel="stylesheet" type="text/css" />

    <!-- icons -->
    <link href="../assets/css/icons.min.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12">
            <div class="card-box">
                <h4 class="header-title">CARRITO DE COMPRAS</h4>

                <p></p>


<%--                <button id="demo-delete-row" class="btn btn-danger btn-sm" disabled><i class="mdi mdi-trash-can mr-1"></i>Delete</button>--%>


                    <%--TABLA--%>
                <%--CssClass="table-borderless table table-bordered table-hover"--%>


                    <%--HeaderStyle-CssClass="table-borderless"--%>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <div>
                                <asp:GridView ID="gvCarrito" CssClass="table-borderless table table-bordered table-hover"
                                    DataKeyNames="PK_IM_Cod,VTM_Nombre,IMU_Cantidad,DMU_Precio" runat="server" AutoGenerateColumns="False"
                                    EmptyDataText="No existen registros, agreguen molduras a su carrito" ShowHeaderWhenEmpty="True" OnRowCommand="gvCarrito_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Agregar al carrito de compras">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" CssClass="checkbox" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PK_IM_Cod" HeaderText="Codigo" />
                                        <asp:BoundField DataField="VTM_Nombre" HeaderText="Tipo de Moldura" />
                                        <asp:BoundField DataField="IMU_Cantidad" HeaderText="Cantidad" />
                                        <asp:BoundField DataField="DMU_Precio" HeaderText="Presio" />
                                        <asp:TemplateField HeaderText="Country" ItemStyle-Width="150" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("PK_IM_Cod") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Country" ItemStyle-Width="150" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrecioItems" runat="server" Text='<%# Eval("DMU_Precio") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
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

    <!-- App js -->
    <script src="../assets/js/app.min.js"></script>



</asp:Content>
