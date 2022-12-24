<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="Realizar_Pedido_Personalizado.aspx.cs" Inherits="WEB.Realizar_Pedido_Personalizado" %>

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
    
    <style>
        input::-webkit-outer-spin-button,
        input::-webkit-inner-spin-button {
            -webkit-appearance: none;
            margin: 0;
        }
    </style>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
    <div class="row">
        <div class="col-12">
            <div class="page-title-box">
                <h4 class="page-title">PEDIDO PERSONALIZADO</h4>
            </div>
            <input runat="server" id="valorObtenidoRBTN" clientidmode="Static" type="hidden" />
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card-box">
                        <div class="page-title-box">
                            <h4 class="page-title">Tipo de Pedido</h4>
                        </div>
                        <div style="text-align: center">
                            <asp:RadioButton ID="rbCatalogo" runat="server" AutoPostBack="True" Text="Catalogo" GroupName="Personalizado" value="1" OnCheckedChanged="rbCatalogo_CheckedChanged" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbDiseñoPropio" runat="server" AutoPostBack="True" Text="Diseño Propio" GroupName="Personalizado" value="2" OnCheckedChanged="rbDiseñoPropio_CheckedChanged" />
                        </div>
                    </div>
                </div>

            </div>
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card-box" id="catalogo" runat="server" clientidmode="Static">
                        <div class="page-title-box">
                            <h4 class="page-title text-lg-center">Especificación</h4>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <asp:UpdatePanel runat="server" ID="Calcular1">
                                    <ContentTemplate>
                                        <asp:UpdatePanel runat="server" ID="Buscar">
                                            <ContentTemplate>
                                                <div class="row  align-self-lg-auto">
                                                    <div class="col-lg-12">
                                                        <div class="col-lg-7">
                                                            <div class="row">
                                                                <div class="col-md-4 ">
                                                                    <asp:Label Text="Codigo: " runat="server" />
                                                                    <asp:TextBox runat="server" ID="txtcodigo" class="form-control" pattern="[0-9]+" placeholder="Ej: 950" type="text"> </asp:TextBox>

                                                                </div>
                                                                <div class="col-lg-2">
                                                                    <br />
                                                                    <div class="form-group">
                                                                        <asp:LinkButton ID="btn_BuscarProducto" Text="text" OnClick="btn_BuscarProducto_Click" type="button" class="btn btn-info waves-effect waves-light" runat="server"><i class="mdi mdi-magnify"></i></asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                                <%--text-right m-b-0--%>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                                <br />

                                                <div class="row ">
                                                    <div class="col-lg">
                                                        <div class="tab-content pt-0" style="text-align: center">
                                                            <div class="tab-pane active show " >
                                                                <asp:Image runat="server" ID="Imagen1" class="rounded" Width="480px" Height="500px" />
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label Text="Largo: " runat="server"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtLargo" class="form-control" ReadOnly></asp:TextBox>

                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:Label Text="Ancho: " runat="server"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtAncho" class="form-control" ReadOnly></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:Label Text="Precio: " runat="server"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtPrecio" class="form-control" ReadOnly></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-12">
                                                        <br />
                                                        <asp:Label Text="Descripción: " runat="server"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtDescripcion" class="form-control" ReadOnly TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />

                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <asp:Label Text="Cantidad: " runat="server"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtCantidad" class="form-control autonumber"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:Label Text="Importe: " runat="server"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtImporte" class="form-control" ReadOnly></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:Label Text="Descuento: " runat="server"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtDescuento" class="form-control" ReadOnly></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:Label Text="Sub Total: " runat="server"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtSubTotal" class="form-control" ReadOnly></asp:TextBox>
                                                        <asp:HiddenField runat="server" ID="txtunidadmetrica" />
                                                    </div>
                                                    <div class="col-lg-12">
                                                        <br />
                                                        <div class="form-group text-right m-b-0">

                                                            <asp:LinkButton ID="btnCalcular" OnClick="btnCalcular_Click" class="btn btn-primary waves-effect waves-light" runat="server">
                                                    Calcular<span class="btn-label-right"><i class="mdi mdi-calculator"></i></span>        
                                                            </asp:LinkButton>

                                                        </div>
                                                    </div>

                                                    <br />
                                                    <div class="col-md-12">
                                                        <asp:Label Text="Comentario" runat="server"></asp:Label>
                                                        <asp:TextBox runat="server" class="form-control" ID="txtComentario" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-3 col-md-offset-9">
                                                    </div>

                                                    <br />
                                                    <div class="col-lg-12">
                                                        <br />
                                                        <div class="form-group text-right m-b-0">
                                                            <asp:UpdatePanel ID="upBotonRegistrar" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:LinkButton ID="btnRegistrar" class="btn btn-success waves-effect waves-light" runat="server" OnClick="btnRegistrar_Click">
                                                                        Registrar<span class="btn-label-right"><i class="mdi mdi-check-all"></i></span>        
                                                                    </asp:LinkButton>
                                                                    <asp:LinkButton ID="btnCancelar" class="btn btn-light waves-effect" runat="server" OnClick="btnCancelar_Click">
                                                                        Regresar<span class="btn-label-right"><i class="mdi mdi-arrow-right-bold"></i></span>
                                                                    </asp:LinkButton>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>

                                                    </div>
                                                </div>


                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card-box" id="personalizado" runat="server" clientidmode="Static">
                        <div class="page-title-box">
                            <h4 class="page-title text-lg-center">Especificación</h4>
                        </div>
                        <div class="card-body">
                            <div class="row align-content-center">
                                <asp:Label Text="Subir Imagen: " runat="server"></asp:Label>
                                <asp:FileUpload ID="FileUpload1" runat="server" accept="image/*" onchange="leerImagen(this);" data-plugins="dropify" data-height="300" />
                            </div>
                            <br />
                            <asp:UpdatePanel ID="Calcular2" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-lg-3">
                                            <asp:Label Text="Seleccionar tipo de moldura" runat="server"></asp:Label>
                                            <asp:DropDownList ID="ddlTipoMoldura" class="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-3">
                                            <asp:Label Text="Largo: " runat="server"> </asp:Label>
                                            <asp:TextBox runat="server" ID="txtLargoP" CssClass="form-control autonumber"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:Label Text="Ancho: " runat="server"> </asp:Label>
                                            <asp:TextBox runat="server" ID="txtAnchoP" CssClass="form-control autonumber"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:Label Text="Cantidad: " runat="server"> </asp:Label>
                                            <asp:TextBox runat="server" ID="txtCantidadP" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:Label Text="Importe Aproximado: " runat="server"> </asp:Label>
                                            <asp:TextBox runat="server" ID="txtImporteAproxP" CssClass="form-control" ReadOnly></asp:TextBox>
                                        </div>

                                        <div class="col-lg-12">
                                            <br />
                                            <div class="form-group text-right m-b-0">

                                                <asp:LinkButton ID="btnCalcularP" class="btn btn-primary waves-effect waves-light" OnClick="btnCalcularP_Click" runat="server">
                                                    Calcular<span class="btn-label-right"><i class="mdi mdi-calculator"></i></span>        
                                                </asp:LinkButton>

                                            </div>
                                        </div>

                                        <div class="col-lg-12">
                                            <asp:Label Text="Comentario: " runat="server"></asp:Label>
                                            <asp:TextBox runat="server" class="form-control" ID="txtComentarioP" TextMode="MultiLine"></asp:TextBox>
                                        </div>

                                        <br />
                                        <div class="col-lg-12">
                                            <br />
                                            <div class="form-group text-right m-b-0">
                                                <asp:UpdatePanel ID="upBotonRegistrarP" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:LinkButton ID="btnRegistrarP" class="btn btn-success waves-effect waves-light" OnClick="btnRegistrarP_Click" runat="server">
                                                    Registrar<span class="btn-label-right"><i class="mdi mdi-check-all"></i></span>        
                                                        </asp:LinkButton>
                                                        <asp:LinkButton ID="btnRegresarP" class="btn btn-light waves-effect" OnClick="btnRegresarP_Click" runat="server">
                                                    Regresar<span class="btn-label-right"><i class="mdi mdi-arrow-right-bold"></i></span>
                                                            <input type="hidden" runat="server" id="hftxtimg" clientidmode="Static" value="vacio" />
                                                        </asp:LinkButton>
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
            </div>


        </div>












    </div>


    <script>

        function showSuccessMessage2() {
            setTimeout(function () {
                swal({
                    title: "Enviado correctamente",
                    text: "Pulsa el botón y se te redirigirá",
                    type: "success"
                }, function () {
                    window.location = "ConsultarEstadoPago.aspx";
                });
            }, 1000);
        }
        function showSuccessMessage3() {
            setTimeout(function () {
                swal({
                    title: "Todo guardado",
                    text: "Pulsa el botón 'ok' y se te redirigirá a la lista de pedidos",
                    type: "success"
                }, function () {
                    window.location.href = "ConsultarEstadoPago.aspx";
                });
            }, 1000);
        }
        function showSuccessMessage4() {
            swal({
                title: "ERROR!",
                text: "Ingresar cantidad del producto!!",
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
                text: "Complete todos los campos!!",
                type: "error"
            });
        }
        function showSuccessMessage7() {
            swal({
                title: "ERROR!",
                text: "Codigo de producto no encontrado!!",
                type: "error"
            });
        }

        function getQueryStringParameter(paramToRetrieve) {
            if (document.URL.split("?")[1] != undefined) {
                var params = document.URL.split("?")[1].split("&");
                var strParams = "";
                for (var i = 0; i < params.length; i = i + 1) {
                    var singleParam = params[i].split("=");
                    if (singleParam[0] == paramToRetrieve)
                        return singleParam[1].replace("#", "");
                }
            }
        }
    </script>




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
    <script src="assets/js/Aplicacion/RealizarPedidoPersonalizado.js"></script>
</asp:Content>
