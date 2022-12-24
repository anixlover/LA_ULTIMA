<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="Administrar_Solicitud_Pedido.aspx.cs" Inherits="WEB.Administrar_Solicitud_Pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--dev alvaro--%>

    <!-- Bootstrap Tables css -->
    <link href="../assets/libs/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" type="text/css" />

    <!-- App css -->
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/app.min.css" rel="stylesheet" type="text/css" />

    <link href="../assets/css/bootstrap-dark.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/app-dark.min.css" rel="stylesheet" type="text/css" />
    <script src="../../plugins/momentjs/moment.js"></script>
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" id="bs-default-stylesheet" />
    <link href="../assets/css/app.min.css" rel="stylesheet" type="text/css" id="app-default-stylesheet" />
    <link href="../assets/css/bootstrap-dark.min.css" rel="stylesheet" type="text/css" id="bs-dark-stylesheet" />
    <link href="../assets/css/app-dark.min.css" rel="stylesheet" type="text/css" id="app-dark-stylesheet" />
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
                            <asp:GridView ID="gvCarrito"
                                DataKeyNames="PK_IMU_Cod,VM_Descripcion,VTM_Nombre,IMU_Cantidad,DMU_Precio,FK_IM_Cod" runat="server" AutoGenerateColumns="False"
                                EmptyDataText="No existen registros, agreguen molduras a su carrito" ShowHeaderWhenEmpty="True"
                                OnRowCommand="gvCarrito_RowCommand" CssClass="table-borderless table table-bordered table-hover"
                                HeaderStyle-CssClass="thead-dark" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvCarrito_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Imagen">
                                        <ItemTemplate>
                                            <img src='ObtieneImagen.ashx?id=<%# Eval("FK_IM_Cod")%>' height="80px" width="80px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FK_IM_Cod" HeaderText="Codigo Moldura" />
                                    <asp:BoundField DataField="VTM_Nombre" HeaderText="Tipo Moldura" />
                                    <asp:BoundField DataField="IMU_Cantidad" HeaderText="Cantidad" />
                                    <asp:BoundField DataField="DMU_Precio" HeaderText="Precio Total" />
                                    <asp:TemplateField HeaderText="Country" ItemStyle-Width="150" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("PK_IMU_Cod") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Country" ItemStyle-Width="150" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrecioItems" runat="server" Text='<%# Eval("DMU_Precio") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Agregar al carrito de compras">
                                        <ItemTemplate>
                                            <div style="text-align: center">
                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:ButtonField ButtonType="button" HeaderText="Detalles" CommandName="Ver" Text="Ver">
                                        <ControlStyle CssClass="btn btn-warning" />
                                    </asp:ButtonField>
                                    <asp:ButtonField ButtonType="button" HeaderText="Eliminar" CommandName="Eliminar" Text="Eliminar">
                                        <ControlStyle CssClass="btn btn-warning" />
                                    </asp:ButtonField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:LinkButton ID="btncrear" runat="server" type="button" class="btn btn-success waves-effect waves-light"  onclick="btnPagar_Click1">
                                                    <span class="btn-label"></span>Crear solicitud
                </asp:LinkButton>

               


                <br />
                <br />
            </div>

        </div>
    </div>



    <%--   MODAL--%>

    <div class="modal fade" id="defaultmodal" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel runat="server" ID="updPanelModal" UpdateMode="Always">
                    <ContentTemplate>
                        <div class="modal-header navbar">
                            <h4 class="modal-title" id="tituloModal" runat="server">Detalles y actualización</h4>
                        </div>
                        <div class="modal-body">

                            <div class="row">
                                <div class="col-md-6">
                                    <div>
                                        <asp:Image ID="Image1" Height="300px" Width="300px" runat="server" class="rounded" />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-12">
                                        <div class="row clearfix">
                                            <div class="form-group form-float">
                                                <label class="form-label">Codigo Solicitud:</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtcodigoModal" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                        <asp:TextBox ID="txtcodM" class="form-control" runat="server" Visible="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="row clearfix">
                                            <div class="form-group form-float">
                                                <label class="form-label">Descripción :</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtDescripcionModal" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                        <input id="txtprecior" class="form-control" runat="server" clientidmode="Static" type="hidden" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="row clearfix">
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
                                    <div class="col-md-12">
                                        <div class="row clearfix">
                                            <div class="form-group form-float">
                                                <label class="form-label">Largo :</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtlargo" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="row clearfix">
                                            <div class="form-group form-float">
                                                <label class="form-label">Ancho :</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtancho" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="row clearfix">
                                            <div class="form-group form-float">
                                                <label class="form-label">unidad metrica :</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtUMModal" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="row clearfix">
                                            <div class="form-group form-float">
                                                <label class="form-label">Cantidad :</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtcantidadModal" class="form-control" max="500" min="1" runat="server" onkeyup="checkCantidad()" ClientIDMode="Static" type="number"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="row clearfix">
                                            <div class="form-group form-float">
                                                <label class="form-label">Precio Unitario:</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:UpdatePanel runat="server">
                                                            <ContentTemplate>
                                                                <input type="text" id="txtPrecioModal" class="form-control" runat="server" readonly clientidmode="Static" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer btn-group-sm">
                            <asp:UpdatePanel ID="UpdatePanelA" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-success btn-group-sm" OnClick="btnActualizar_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <button type="button" class="btn btn-link waves-effect" data-dismiss="modal">Cerrar</button>
                        </div>

                        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                                            <ContentTemplate>
                                                <asp:Button runat="server" ID="Button1" CssClass="btn btn-primary nextBtn-2" Style="float: right" Text="Crear solicitud de compra" OnClick="btnPagar_Click1" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="modal fade" id="confirmacionmodal" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
                            <div class="modal-dialog modal-sm" role="document">
                                <div class="modal-content">
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Always">
                                        <ContentTemplate>
                                            <div class="modal-body">
                                                <h4 id="mensaje" runat="server"></h4>
                                            </div>
                                            <div class="modal-footer">
                                                <asp:Button runat="server" ID="btnAceptarRedirigir" CssClass="button" Text="Ir a pedido personalizado" OnClick="btnAceptarRedirigir_Click" />

                                                <button type="button" class="btn btn-link waves-effect button" data-dismiss="modal">Cerrar</button>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>


    <script>
        function showSuccessMessage2() {
            $('#defaultmodal').modal('hide');
            swal(
                'Excelente',
                'Todo Actualizado!',
                'success'
            );
        };
    </script>


    <!-- Right bar overlay-->
    <div class="rightbar-overlay"></div>

    <!-- Vendor js -->
    <script src="../assets/js/vendor.min.js"></script>

    <!-- Bootstrap Tables js -->
    <script src="../assets/libs/bootstrap-table/bootstrap-table.min.js"></script>

    <!-- Init js -->
    <script src="../assets/js/pages/bootstrap-tables.init.js"></script>

    <!-- Plugin js-->
    <script src="../assets/libs/parsleyjs/parsley.min.js"></script>

    <!-- Validation init js-->
    <script src="../assets/js/pages/form-validation.init.js"></script>

    <!-- App js -->
    <script src="../assets/js/app.min.js"></script>



</asp:Content>
