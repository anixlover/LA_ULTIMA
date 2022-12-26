<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Ingresa_Venta.aspx.cs" Inherits="WEB.Ingresa_Venta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Bootstrap Tables css -->
    <link href="../assets/libs/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" type="text/css" />

    <!-- Animation css -->
    <link href="../assets/libs/animate.css/animate.min.css" rel="stylesheet" type="text/css" />

    <!-- App css -->
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" id="bs-default-stylesheet" />
    <link href="../assets/css/app.min.css" rel="stylesheet" type="text/css" id="app-default-stylesheet" />

    <link href="../assets/css/bootstrap-dark.min.css" rel="stylesheet" type="text/css" id="bs-dark-stylesheet" />
    <link href="../assets/css/app-dark.min.css" rel="stylesheet" type="text/css" id="app-dark-stylesheet" />

    <!-- Vendor js -->
    <script src="../assets/js/vendor.min.js"></script>

    <!-- Bootstrap Tables js -->
    <script src="../assets/libs/bootstrap-table/bootstrap-table.min.js"></script>

    <!-- App js -->
    <script src="../assets/js/app.min.js"></script>
    <script src="assets/js/Aplicacion/UploadFile.js"></script>


    <!-- Plugins js -->
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
    <script src="../assets/js/app.min.js"></script>
    <script src="assets/js/Aplicacion/UploadFile.js"></script>

    <!-- icons -->
    <link href="../assets/css/icons.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        textarea {
            resize: none;
        }
    </style>
    <style>
        input::-webkit-outer-spin-button,
        input::-webkit-inner-spin-button {
            -webkit-appearance: none;
            margin: 0;
        }
    </style>
    <!-- Libreria JQuery -->
    <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="assets/js/Aplicacion/UploadFile.js"></script>
    <!--JS leerImagen-->
    <script type="text/javascript">
        function leerImagen(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#hfileupload').val("Lleno");
                    console.log(reader.result);
                    convertDataURIToBinary(reader.result);
                };
                var BASE64_MARKER = ';base64,';

                function convertDataURIToBinary(dataURI) {
                    var base64Index = dataURI.indexOf(BASE64_MARKER) + BASE64_MARKER.length;
                    var base64 = dataURI.substring(base64Index);
                    var raw = window.atob(base64);
                    var rawLength = raw.length;
                    var array = new Uint8Array(new ArrayBuffer(rawLength));

                    for (i = 0; i < rawLength; i++) {
                        array[i] = raw.charCodeAt(i);
                    }
                    $('#hftxtimg').val(array);
                    console.log(array);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" method="POST">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
        <div class="row">
            <div class="col-12">
                <div class="page-title-box">
                    <h4 class="page-title">INGRESO DE VENTA</h4>
                </div>
            </div>
        </div>
        <%--Tipo de venta--%>
        <div class="row" style="display: none">
            <div class="col-12">
                <div class="page-title-box">
                    <div class="card-box">
                        <h5 class="text-uppercase bg-light p-2 mt-0 mb-3">Tipo de Venta</h5>
                        <asp:Panel runat="server" ID="PanelO">
                            <div class="row justify-content-center">
                                <div>
                                    <div class="input-group">
                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updPanelddl" ClientIDMode="Static">
                                            <ContentTemplate>
                                                <asp:DropDownList runat="server" class="btn btn-primary   dropdown-toggle" aria-haspopup="true" aria-expanded="false" ID="ddl_TipoComprobante" ClientIDMode="Static" OnSelectedIndexChanged="ddl_TipoComprobante_SelectedIndexChanged">
                                                    <asp:ListItem Text="Seleccionar"/>
                                                    <asp:ListItem Value="1" Text="Boleta" Selected="True"/>
                                                    <asp:ListItem Value="2" Text="Factura" />
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>


        <%--Datos del Cliente--%>
        <div class="row">
            <div class="col-12">
                <div class="page-title-box">
                    <div class="card-box">
                        <h5 class="text-uppercase bg-light p-2 mt-0 mb-3">Datos del Cliente</h5>
                        <div class="row">
                            <div class="col-lg-6">
                                <%--<input type="hidden" runat="server" id="valorObtenidoRBTN1" clientidmode="Static" />--%>
                                <%--<label for="heard">Documento de Identidad: <span class="text-danger">*</span></label>--%>
                                <div id="lbldni" runat="server" clientidmode="Static">
                                    <asp:HiddenField runat="server" ID="HiddenField5" ClientIDMode="Static" />
                                    <asp:Label ID="lbldniu" runat="server" class="form-label">Documento de Identidad: <span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="form-inline">

                                    <div class="form-group">

                                        <asp:Panel runat="server" ID="panelDoc">
                                            <div class="input-group">
                                                <asp:TextBox runat="server" ID="txtDocumento" class="form-control" data-toggle="input-mask" data-mask-format="00000000" ClientIDMode="Static"></asp:TextBox>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                    <div class="form-group mx-sm-3">
                                        <asp:UpdatePanel runat="server" ID="upBotonBuscar" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="btnBuscarDocumento" Visible="true" class="btn btn-primary waves-effect waves-light" runat="server" OnClick="btnBuscarDocumento_Click">
                                        Buscar<span class="btn-label-right"><i class="mdi mdi-content-save-edit"></i></span>
                                                </asp:LinkButton>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <span class="font-13 text-muted">e.g (8 Digitos)</span>
                                <br />
                                <br />

                                <%--ddl RUC existente--%>
                                <div class="form-group mb-3" id="divSelectRucHide" runat="server" clientidmode="Static">
                                    <asp:HiddenField runat="server" ID="HiddenSelectRUC" ClientIDMode="Static" />
                                    <div class="input-group">
                                        <asp:UpdatePanel ID="upRUC" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:DropDownList class="btn btn-light dropdown-toggle" runat="server" 
                                                    aria-haspopup="true" aria-expanded="false" ID="ddlListRUC" ClientIDMode="Static" 
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddl_Ruc_SelectedIndexChanged">
                                                    <%--<asp:ListItem Text="Seleccionar" Selected="True" />--%>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <%--RUC input--%>
                                <asp:Label Text="Ingrese RUC nuevo: " runat="server" ID="lblRUCnuevo" ClientIDMode="Static"></asp:Label>
                                <div class="form-inline" id="divIngresarRucHide" runat="server">
                                    <asp:HiddenField runat="server" ID="HiddenIngresaRUC" ClientIDMode="Static" />
                                    <div class="form-group">
                                        <asp:Panel runat="server" ID="panelRUC">
                                            <div class="input-group">
                                                <%--<asp:Label for="heard" Text="Ingrese RUC nuevo:" runat="server"></asp:Label>--%>
                                                <asp:TextBox runat="server" ID="txtIngresarRuc" ClientIDMode="Static" class="form-control" data-toggle="input-mask" MinLength="11" MaxLength="11" data-mask-format="00000000000"></asp:TextBox>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                    <div class="form-group mx-sm-3">
                                        <asp:UpdatePanel runat="server" ID="upBotonAñadirRuc" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="btnIngresarRuc" Visible="true" ClientIDMode="Static" class="btn btn-primary waves-effect waves-light" runat="server" OnClick="btnIngresarRuc_Click">
                                        Agregar<span class="btn-label-right"><i class="mdi mdi-content-save-edit"></i></span>
                                                </asp:LinkButton>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-6">
                                <asp:UpdatePanel ID="upDatosCliente" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="form-group mb-3">
                                            <asp:Label Text="Nombre: " runat="server"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtNombre" class="form-control" ReadOnly></asp:TextBox>
                                        </div>
                                        <div class="form-group mb-3">
                                            <asp:Label Text="Apellido: " runat="server"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtApellido" class="form-control" ReadOnly></asp:TextBox>
                                        </div>
                                        <div class="form-group mb-3">
                                            <asp:Label Text="Telefono: " runat="server"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtTelefono" class="form-control" ReadOnly></asp:TextBox>
                                        </div>
                                        <div class="form-group mb-3">
                                            <asp:Label Text="Correo: " runat="server"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtCorreo" class="form-control" ReadOnly></asp:TextBox>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--Detalles--%>
        <div class="row">
            <div class="col-12">
                <div class="page-title-box">
                    <div class="card-box">
                        <h5 class="text-uppercase bg-light p-2 mt-0 mb-3">Detalles</h5>
                        <asp:Label Text="El pedido es:" runat="server"></asp:Label>
                        <br />
                        <asp:Panel runat="server" ID="panelRadioButtonServicio">
                            <div class="row justify-content-center">
                                <div>
                                    <div class="form-inline">
                                        <div class="form-group mb-3">
                                            <div class="demo-checkbox input-group">
                                                <div class="radio form-check-inline">
                                                    <input type="radio" id="cbx_Catalogo" name="TipoPedido" class="radio-col-red" value="1" />
                                                    <label for="cbx_Catalogo">Catalogo</label>
                                                </div>
                                                <div class="radio form-check-inline mx-sm-3">
                                                    <input type="radio" id="cbx_Personalizado" name="TipoPedido" class="radio-col-red" value="2" />
                                                    <label for="cbx_Personalizado">Personalizado</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>

                        <%--ddl Por:--%>
                        <input type="hidden" runat="server" id="valorObtenidoRBTN" clientidmode="Static" />
                        <asp:Panel runat="server" ID="panelPor">
                            <div class="form-group mb-3" id="div1" runat="server">
                                <div class="input-group">
                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="ddlPedidoMuestra" ClientIDMode="Static">
                                        <ContentTemplate>
                                            <asp:Label Text="Por:" runat="server"></asp:Label>
                                            <asp:DropDownList class="btn btn-light dropdown-toggle" runat="server" aria-haspopup="true"
                                                aria-expanded="false" ID="ddlPedidoPor" AutoPostBack="true" ClientIDMode="Static"
                                                OnSelectedIndexChanged="ddlPedidoPor_SelectedIndexChanged">
                                                <asp:ListItem Text="Seleccionar" Selected="True" />
                                                <asp:ListItem Value="1" Text="Catalogo" />
                                                <asp:ListItem Value="2" Text="Diseño Propio" />
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </asp:Panel>

                        <%--ddlTipoMoldura--%>
                        <div class="col-12" id="idTipoMoldura" runat="server" clientidmode="Static">
                            <%--hidden--%>
                            <div class="row">
                                <div class="col-6">
                                    <asp:Label Text="Tipo Moldura:" runat="server" ID="lblTipoMoldura"></asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlTipoMoldura" class="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-6">
                                    <div class="page-title-box">
                                        <div class="card-box">
                                            <h5 class="text-uppercase bg-light p-2 mt-0 mb-3">Detalle de Moldura</h5>
                                            <%--datos--%>
                                            <div class="row p-2 mt-0 mb-3 align-content-center" runat="server" id="div2">
                                                <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="form-group">
                                                            <asp:Label Text="Largo: " runat="server" ID="Label7"></asp:Label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text">
                                                                        <asp:Label ID="lblLargo" runat="server" Text="Cm"></asp:Label></span>
                                                                </div>
                                                                <asp:TextBox ID="txtLargo" runat="server" parsley-trigger="change" class="form-control autonumber " data-v-max="250" data-v-min="1" TextMode="Number" step=".01"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <asp:Label Text="Ancho: " runat="server" ID="lblanchoPersonalizado"></asp:Label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text">
                                                                        <asp:Label ID="lblAncho" runat="server" Text="Cm"></asp:Label></span>
                                                                </div>
                                                                <asp:TextBox ID="txtAncho" runat="server" class="form-control autonumber" data-v-max="250" data-v-min="1" TextMode="Number" step=".01"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <asp:Label Text="Cantidad: " runat="server" ID="lblCantidadPersonalizado"></asp:Label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text">
                                                                        <asp:Label ID="lblCantidadP" runat="server" Text="u."></asp:Label></span>
                                                                </div>
                                                                <asp:TextBox runat="server" ID="txtCantidadPersonalizado" class="form-control number" data-toggle="input-mask" data-mask-format="000"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <%--<div class="form-group">
                                                            <asp:Label Text="Cantidad: " runat="server" ID="lblCantidadPersonalizado"></asp:Label>
                                                            <asp:TextBox runat="server" ID="txtCantidadPersonalizado" class="form-control number" data-toggle="input-mask" data-mask-format="000"></asp:TextBox>
                                                        </div>--%>
                                                        <div class="form-group" style="text-align: center">
                                                            <asp:Label Text="Imagen: " runat="server" ID="lblImagen"></asp:Label>
                                                            <div style="text-align: center">
                                                                <asp:Label ID="txtTitulo2" runat="server" Text=""></asp:Label>
                                                                <br />
                                                                <%--<asp:Image ID="imgdefault" runat="server" Height="300px" Width="300px" CssClass="img-thumbnail" />
                                                                <br />
                                                                
                                                                    <input type="file" id="FileUpload1" accept=".jpg,.png" onchange="leerImagen(this);" data-plugins="dropify" />
                                                                </div>--%>
                                                                <asp:Image ID="Image1" Height="250px" Width="250px" runat="server" CssClass="img-thumbnail" />
                                                                <br />
                                                                <asp:Button ID="btnRemover" runat="server" Text="Remover" OnClick="btnRemover_Click" />
                                                                <div runat="server" id="Div">
                                                                    <input name="fileAnexo" type="file" id="FileUpload2" runat="server" accept=".png,.jpg"
                                                                        class="btn btn-warning" style="width: 50%;" onchange="ImagePreview(this);" />

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <asp:Label Text="Precio Aprox: " runat="server" ID="lblPrecioAprox"></asp:Label>
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text">
                                                                        <asp:Label ID="lblPrecioA" runat="server" Text="S/."></asp:Label></span>
                                                                </div>
                                                                <asp:TextBox ID="txtpriceaprox" class="form-control autonumber" data-parsley-type="digits" data-v-max="600" data-v-min="0" runat="server" TextMode="Number" required></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <%--btn calcular--%>
                                                        <div class="form-group">
                                                            <asp:UpdatePanel runat="server" ID="panelCalcPersonalizado" runat="server"
                                                                UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:LinkButton ID="btnCalcularPersonalizado" Visible="true"
                                                                        class="btn btn-primary waves-effect waves-light" runat="server"
                                                                        OnClick="btnCalcularPersonalizado_Click">
                                                                    Calcular<span class="btn-label-right"><i class="mdi mdi-content-save-edit"></i></span>
                                                                    </asp:LinkButton>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>

                                                        <%--btn botón Enviar--%>
                                                        <div class="form-group">
                                                            <asp:UpdatePanel runat="server" ID="UpdatePaneCustom" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:LinkButton ID="btnEnviar1" Visible="true" class="btn btn-primary waves-effect waves-light" runat="server" OnClick="btnEnviar1_Click">
                                                                    Enviar<span class="btn-label-right"><i class="mdi mdi-content-save-edit"></i></span>
                                                                    </asp:LinkButton>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <%--Pedido por Catalogo--%>
                        <div id="DivCodigoSubtotal" runat="server" clientidmode="Static">

                            <div class="row">
                                <div class="col-6">
                                    <asp:Label Text="Codigo Producto:" runat="server"></asp:Label>
                                    <br />
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <div class="input-group">
                                                <asp:UpdatePanel runat="server" ID="upCodigo" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:TextBox runat="server" ID="txtCodProducto"
                                                            class="form-control autonumber" data-toggle="input-mask"
                                                            data-mask-format="000"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <%--Boton Buscar Producto--%>
                                        <div class="form-group mx-sm-3">
                                            <asp:UpdatePanel runat="server" ID="upBotonBuscarProducto" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="btnIngresarProducto" Visible="true" class="btn btn-primary waves-effect waves-light" runat="server" OnClick="btnIngresarProducto_Click">
                                                    Buscar<span class="btn-label-right"><i class="mdi mdi-content-save-edit"></i></span>
                                                    </asp:LinkButton>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <%--Cantidad--%>
                                <div class="col-6">
                                    <asp:Label Text="Cantidad:" runat="server"></asp:Label>
                                    <br />
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <div class="input-group">
                                                <asp:UpdatePanel runat="server" ID="uptxtcantidad" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:TextBox runat="server" ID="txtCantidadProducto" class="form-control" data-toggle="input-mask" data-mask-format="000"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <%--Boton Calcular--%>
                                        <div class="form-group mx-sm-3">
                                            <asp:UpdatePanel runat="server" ID="UpdatePanel4" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="btnIngresarCantidad" Visible="true" class="btn btn-primary waves-effect waves-light" runat="server" OnClick="btnIngresarCantidad_Click">
                                                    Calcular<span class="btn-label-right"><i class="mdi mdi-content-save-edit"></i></span>
                                                    </asp:LinkButton>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <%--Grilla Datos Moldura--%>
                                <div class="col-12">
                                    <div class="table-borderless">
                                        <asp:UpdatePanel runat="server" ID="updPanelGVDetalle" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:GridView ID="gvdetalle" runat="server" CssClass="table-borderless table table-bordered table-hover"
                                                    DataKeyNames="PK_IM_Cod,VBM_Imagen,VTM_Nombre,DM_Largo,DM_Ancho,IM_Stock,DM_Precio"
                                                    OnRowDataBound="gvdetalle_RowDataBound" OnRowCommand="gvdetalle_RowCommand"
                                                    ShowHeaderWhenEmpty="true" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Imagen">
                                                            <ItemTemplate>
                                                                <img src='ObtieneImagen.ashx?id=<%# Eval("PK_IM_Cod")%>' height="80px" width="80px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PK_IM_Cod" HeaderText="Codigo" Visible="false" />
                                                        <asp:BoundField DataField="VBM_Imagen" HeaderText="Imagen" Visible="false" />
                                                        <asp:BoundField DataField="VTM_Nombre" HeaderText="Tipo Moldura" />
                                                        <asp:BoundField DataField="DM_Largo" HeaderText="Medida Largo" />
                                                        <asp:BoundField DataField="DM_Ancho" HeaderText="Medida Ancho" />
                                                        <asp:BoundField DataField="IM_Stock" HeaderText="Stock(u)" />
                                                        <asp:BoundField DataField="DM_Precio" HeaderText="Precio(u) S/" />
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <br />
                                        <asp:UpdatePanel runat="server" ID="updPanelGVDetalle2" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:GridView ID="gvdetalle2" CssClass="table-borderless table table-bordered table-hover" runat="server"
                                                    DataKeyNames="PK_IM_Cod,VBM_Imagen,VTM_Nombre,DM_Largo,DM_Ancho,IM_Stock,DM_Precio,Subtotal"
                                                    OnRowDataBound="gvdetalle_RowDataBound" OnRowCommand="gvdetalle_RowCommand" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Imagen">
                                                            <ItemTemplate>
                                                                <img src='ObtieneImagen.ashx?id=<%# Eval("PK_IM_Cod")%>' height="80px" width="80px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PK_IM_Cod" HeaderText="Codigo" Visible="false" />
                                                        <asp:BoundField DataField="VBM_Imagen" HeaderText="Imagen" Visible="false" />
                                                        <asp:BoundField DataField="VTM_Nombre" HeaderText="Tipo Moldura" />
                                                        <asp:BoundField DataField="DM_Largo" HeaderText="Medida Largo" />
                                                        <asp:BoundField DataField="DM_Ancho" HeaderText="Medida Ancho" />
                                                        <asp:BoundField DataField="IM_Stock" HeaderText="Stock(u)" />
                                                        <asp:BoundField DataField="DM_Precio" HeaderText="Precio(u) S/" />
                                                        <asp:BoundField DataField="Subtotal" HeaderText="Subtotal S/" />
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                    </div>
                                    <%--btn agregar--%>
                                    <br />
                                    <div class="form-group" id="btnadd" runat="server" clientidmode="Static">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton runat="server" ID="btnagregar" class="btn btn-primary waves-effect waves-light" 
                                                    OnClick="btnagregar_Click">            
                                                    Agregar<span class="btn-label-right"><i class="mdi mdi-content-save-edit"></i></span>
                                                </asp:LinkButton>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <%--Calendario--%>
                                <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="col-12" id="IdCalendar" runat="server" clientidmode="Static">
                                            <asp:Label Text="Fecha de Entrega:" ID="lblEntrega" runat="server"></asp:Label>
                                            <asp:HiddenField runat="server" ID="HiddenFieldFecha" ClientIDMode="Static" />
                                            <div class="body table-responsive ">
                                                <asp:Calendar ID="Calendar1" runat="server" TodayDayStyle-BackColor="Wheat"></asp:Calendar>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <%--subtotal--%>
                                <div class="col-12" id="divSubAddGv" runat="server"  clientidmode="Static">
                                    <asp:HiddenField runat="server" ID="HiddenField2" ClientIDMode="Static" />
                                    <%--2nd gridv--%>

                                    <%--producto agregados--%>
                                    <div>
                                        <asp:Label ID="lblProductoAgregado" runat="server"></asp:Label>
                                        <div class="table-responsive ">
                                            <asp:UpdatePanel runat="server" ID="updPanelGV2" UpdateMode="Always">
                                                <ContentTemplate>
                                                    <asp:GridView runat="server" ID="gv2" CssClass="table-borderless table table-bordered table-hover" 
                                                        OnSelectedIndexChanged="gv2_SelectedIndexChanged" OnRowDeleting="gv2_RowDeleting" 
                                                        DataKeyNames="Codigo Producto,Cantidad,Precio(u) S/.,Subtotal S/.">
                                                        <Columns>
                                                            <asp:ButtonField ButtonType="button" HeaderText="Accion" CommandName="delete" Text="Borrar">
                                                                <ControlStyle CssClass="btn btn-warning" />
                                                            </asp:ButtonField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <%--Importe Total--%>
                                <div class="col-12" id="txtimportetotal" runat="server" clientidmode="Static">
                                    <div>
                                        <asp:Label Text="Importe Total S/." runat="server" ID="Label1"></asp:Label>
                                        <div class="form-inline">
                                            <asp:UpdatePanel runat="server" ID="upImpoTot" UpdateMode="Always">
                                                <ContentTemplate>
                                                    <asp:TextBox runat="server" ID="txtimporttot" 
                                                        class="form-control" Value="0" pattern="[0-8]+" 
                                                        ReadOnly></asp:TextBox>
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
        </div>

        <%--Forma de Pago--%>
        <div class="row">
            <div class="col-12">
                <div class="page-title-box">
                    <div class="card-box">
                        <h5 class="text-uppercase bg-light p-2 mt-0 mb-3">Forma de Pago</h5>
                        <asp:Label Text="Importe Total:" runat="server"></asp:Label>
                        <br />
                        <asp:UpdatePanel runat="server" UpdateMode="Always">
                            <ContentTemplate>
                                <div>
                                    <%--<asp:Label ID="lblimporteigv" runat="server">Importe total:</asp:Label>--%>
                                    <div class="form-inline">
                                        <asp:TextBox ID="txtimporteigv" class="form-control autonumber" runat="server" ClientIDMode="Static" ReadOnly></asp:TextBox>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <asp:Label ID="lblmontopagado" Text="Monto Pagado:" runat="server"></asp:Label>
                        <div class="input-group">
                            <asp:TextBox runat="server" type="number" ID="txtmontopagado" class="form-control autonumber" onkeyup="CalcularVuelto()" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <br />
                        <asp:Label ID="lblvuelto" Text="Vuelto:" runat="server"></asp:Label>
                        <div class="form-inline">
                            <input type="text" id="txtvuelto" class="form-control autonumber" runat="server" clientidmode="Static" readonly />
                        </div>
                        <br />
                        <%--btn send n pay boleta--%>
                        <asp:UpdatePanel runat="server" ID="updBotonEnviar" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <div runat="server" id="divbtnboleta1">
                                    <asp:LinkButton ID="btnboleta" runat="server" OnClick="btnboleta_Click1"
                                        class="btn btn-primary waves-effect waves-light">Pagar<span class="btn-label-right"><i class="mdi mdi-content-save-edit"></i></span>
                                    </asp:LinkButton>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
										<Triggers>
											<asp:AsyncPostBackTrigger ControlID="btnboleta" EventName="Click" />
										</Triggers>
                        <br />
                        <%--btn send n print factura--%>
                        <div runat="server" id="btnfactura1">
                            <asp:LinkButton runat="server" ID="btnfactura" class="btn btn-primary waves-effect waves-light" OnClick="btnfactura_Click">
                            Imprimir<span class="btn-label-right"><i class="mdi mdi-content-save-edit"></i></span>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>


    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" runat="server">
    <script src="assets/js/Aplicacion/RealizarVenta.js"></script>
    <script>
        function CalcularVuelto() {
            var textboxpago = $('#txtmontopagado').val();
            var textboximporte = $('#txtimporteigv').val();

            var valuevuelto = parseFloat(textboxpago) - parseFloat(textboximporte);
            $('#txtvuelto').val(valuevuelto);
        }

        function showSuccessMessage2() {
            swal({
                title: "Todo guardado",
                text: "Pulsa el botón y se te redirigirá",
                type: "success"
            }, function (redirect) {
                if (redirect) {
                    window.location.href = "Ingresa_Venta.aspx"
                }
            });
        }
        function showSuccessMessage3() {
            swal({
                title: "Enviado Correctamente",
                text: "Pulsa el botón y se te redirigirá",
                type: "success"
            }, function (redirect) {
                if (redirect) {
                    window.location.href = "Ingresa_Venta.aspx"
                }
            });
        }
        function showSuccessMessage4() {
            swal({
                title: "ERROR!",
                text: "Identificar al cliente!!",
                type: "error"
            });
        }
        function showSuccessMessage5() {
            swal({
                title: "ERROR!",
                text: "Ingresar codigo del producto!!",
                type: "error"
            });
        }
        function showSuccessMessage6() {
            swal({
                title: "ERROR!",
                text: "Ingresar cantidad del producto!!",
                type: "error"
            });
        }
        function showSuccessMessage7() {
            swal({
                title: "ERROR!",
                text: "Complete espacios en blanco!!",
                type: "error"
            });
        }
        function showSuccessMessage8() {
            swal({
                title: "ERROR!",
                text: "Ingresar medida!!",
                type: "error"
            });
        }
        function showSuccessMessage9() {
            swal({
                title: "ERROR!",
                text: "Ingresar cantidad!!",
                type: "error"
            });
        }
        function showSuccessMessage10() {
            swal({
                title: "ERROR!",
                text: "Ingresar imagen!!",
                type: "error"
            });
        }
        function showSuccessMessage11() {
            swal({
                title: "ERROR!",
                text: "Seleccionar una moldura!!",
                type: "error"
            });
        }
        function showSuccessMessage12() {
            swal({
                title: "ERROR!",
                text: "Seleccionar tipo de comprobante!!",
                type: "error"
            });
        }
        function showSuccessMessage13() {
            swal({
                title: "ERROR!",
                text: "Monto insuficiente!!",
                type: "error"
            });
        }
        function showSuccessMessage14() {
            swal({
                title: "ERROR!",
                text: "Monto pagado incorrecto!!",
                type: "error"
            });
        }
        function showSuccessMessage15() {
            swal({
                title: "CORRECTO!",
                text: "RUC AGREGADO CORRECTAMENTE!!",
                type: "success"
            });
        }
        function showSuccessMessage16() {
            swal({
                title: "ERROR!",
                text: "Asigne un RUC!!",
                type: "error"
            });
        }
        function showSuccessMessage17() {
            swal({
                title: "ERROR!",
                text: "La cantidad debe ser mayor a 30 unidades!!",
                type: "error"
            });
        }
        function showSuccessMessage18() {
            swal({
                title: "ERROR!",
                text: "Ingresar monto a pagar!!",
                type: "error"
            });
        }
    </script>

    <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="js/Aplicacion/UploadFile.js"></script>

    <!--JS leerImagen-->
    <script type="text/javascript">
        function leerImagen(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#hfileupload').val("Lleno");
                    console.log(reader.result);
                    convertDataURIToBinary(reader.result);
                };
                var BASE64_MARKER = ';base64,';

                function convertDataURIToBinary(dataURI) {
                    var base64Index = dataURI.indexOf(BASE64_MARKER) + BASE64_MARKER.length;
                    var base64 = dataURI.substring(base64Index);
                    var raw = window.atob(base64);
                    var rawLength = raw.length;
                    var array = new Uint8Array(new ArrayBuffer(rawLength));

                    for (i = 0; i < rawLength; i++) {
                        array[i] = raw.charCodeAt(i);
                    }
                    $('#hftxtimg').val(array);
                    console.log(array);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>

    <script type="text/javascript">
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=Image1.ClientID%>').prop('src', e.target.result)
                        .width(250)
                        .height(250);
                };
                reader.readAsDataURL(input.files[0]);
                $.plot($("#placeholder"), data, options);
            }
        }

        function getQueryStringParameter(paramToRetrieve) {
            var params = document.URL.split("?");
            var strParams = "";
            for (var i = 0; i < params.length; i = i + 1) {
                var singleParam = params[i].split("=");
                if (singleParam[0] == paramToRetrieve)
                    return singleParam[1].replace("#", "");
            }
        }
    </script>

</asp:Content>
