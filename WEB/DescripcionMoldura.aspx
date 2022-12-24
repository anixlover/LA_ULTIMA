<%@ Page Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="DescripcionMoldura.aspx.cs" Inherits="WEB.DescripcionMoldura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../assets/css/bootstrap-saas.min.css" rel="stylesheet" type="text/css" id="bs-default-stylesheet" />
    <link href="../assets/css/app-saas.min.css" rel="stylesheet" type="text/css" id="app-default-stylesheet" />
    <link href="../assets/css/bootstrap-saas-dark.min.css" rel="stylesheet" type="text/css" id="bs-dark-stylesheet" />
    <link href="../assets/css/app-saas-dark.min.css" rel="stylesheet" type="text/css" id="app-dark-stylesheet" />
    <!-- App favicon -->
    <link rel="shortcut icon" href="../assets/images/favicon.ico">

    <!-- Lightbox css -->
    <link href="../assets/libs/magnific-popup/magnific-popup.css" rel="stylesheet" type="text/css" />

    <!-- icons -->
    <link href="../assets/css/icons.min.css" rel="stylesheet" type="text/css" />

    <link href="assets/css/StyleSheet1.css" rel="stylesheet" type="text/css" />
    <!-- Tour css -->
    <link href="../assets/libs/hopscotch/css/hopscotch.min.css" rel="stylesheet" type="text/css" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
    <section class="seccion contenedor clearfix">
        <h2>Descripcion</h2>
        <div class="descripcion-moldura">
            <asp:UpdatePanel ID="upBotonEnviar" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-12">
                            <div class="card-box">
                                <div class="row">
                                    <div class="col-lg-7">
                                        <style type="text/css">
                                            #Imgae1 {
                                                float: right;
                                                vertical-align: top;
                                                background: url('') no-repeat center center / 100% auto;
                                                width: 50px;
                                                height: 50px;
                                                margin-bottom: 50px;
                                            }
                                        </style>
                                        <%--Imagen del producto--%>
                                        <div class="tab-content pt-0">
                                            <div class="tab-pane active show" id="product-1-item">
                                                <%--<img src="../assets/images/products/product-9.jpg" alt="" class="img-fluid mx-auto d-block rounded">--%>
                                                <asp:Image ID="Image1" Height="700px" Width="680px" runat="server" class="rounded" />
                                            </div>
                                        </div>
                                    </div>
                                    <!-- end col -->

                                    <%--descripcion--%>
                                    <div class="col-lg-5">
                                        <div class="pl-xl-3 mt-3 mt-xl-0">
                                            <%--categoria--%>
                                            <%--<a href="#" class="text-primary">Jack & Jones</a>--%>
                                            <%--end categoria--%>

                                            <%--Codigo de la moldura--%>
                                            <h1>Codigo: #<asp:Label ID="txtcodigomoldura" runat="server"></asp:Label></h1>
                                            <%--end codigo de la moldura--%>

                                            <%--nombre de la moldura--%>
                                            <h4 class="mb-4">
                                                <h2>
                                                    <asp:Label ID="txtnombre" runat="server"></asp:Label></h2>

                                                <%--<h4 class="mb-3">Jack & Jones Men's T-shirt (Blue)</h4>--%>
                                                <%--descuento--%>
                                                <%--<h6 class="text-danger text-uppercase">20 % Off</h6>--%>

                                                <%--estado stock--%>
                                                <h4 class="mb-4">
                                                    <h4>
                                                        <asp:Label ID="lblestadostock" runat="server" ClientIDMode="Static" class="badge bg-soft-success text-success mb-4"></asp:Label>
                                                        <asp:Label ID="lblNostock" runat="server" ClientIDMode="Static" class="badge badge-soft-danger mb-4"></asp:Label>
                                                        <%--end estado stock--%>

                                                        <%--<span class="badge bg-soft-success text-success mb-4">Instock</span>\--%>
                                                    </h4>
                                                    <%--largo--%>
                                                    <h4 class="mb-4">
                                            <p>
                                                Largo:
                                                <asp:Label ID="txtlargo" runat="server" ClientIDMode="Static"></asp:Label>
                                            </p>
                                            <%--end largo--%>

                                            <%--ancho--%>
                                            <h4 class="mb-4">
                                            <p>
                                                Ancho:
                                                <asp:Label ID="txtancho" runat="server" ClientIDMode="Static"></asp:Label>
                                            </p>
                                            <%--end ancho--%>

                                            <%--Precio--%>
                                            <h4 class="mb-4">
                                            <p>
                                                Precio: S./
                                                <asp:Label ID="txtprecio" runat="server" ClientIDMode="Static"></asp:Label>
                                            </p>
                                            <%--<span class="text-muted mr-2"><del>$80 USD</del></span> <b>$64 USD</b></h4>--%>
                                            <%--End Precio--%>

                                            <%--stock--%>
                                            <h4 class="mb-4">
                                            <p>
                                                Stock:
                                                <asp:Label ID="txtstock" runat="server" ClientIDMode="Static"></asp:Label>
                                            </p>
                                            <%--end stock--%>

                                            <%--Cantidad--%>

                                            <h4 class="mb-4">
                                            <p id="cantidad">
                                                Cantidad:
                                                <asp:TextBox ID="txtCantidad" TextMode="Number" Text="1" class="form-control autonumber" max="500" min="1" runat="server"></asp:TextBox>
                                            </p>

                                            <%--End cantidad--%>

                                            <%--Descripcion mas a detalle del producto--%>
                                            <h4 class="mb-4">
                                            <p class="text-muted mb-4">
                                                <asp:Label ID="txtdescripcion" runat="server"></asp:Label>
                                                <%--<textarea ID="txtdescripcion" runat="server"></textarea>--%></>
                                            </p>
                                            <%--end descripcion--%>

                                            <%--boton atras y agregar al carrito--%>
                                            <button type="button" onclick="" class="btn btn-danger waves-effect">
                                                <a href="javascript:history.back()" style="color: white"><span class="btn-label"><i class="mdi dripicons-return"></i></span>Volver Atrás</a>
                                            </button>
                                            <div id="agregarCarrito">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                                <asp:UpdatePanel ID="Btnagregar" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:LinkButton ID="btnAgregarCarrito" OnClientClick="mostrarMensaje()" runat="server" type="button" class="btn btn-success waves-effect waves-light" OnClick="btnAgregarCarrito_Click">
                                                    <span class="btn-label"><i class="mdi mdi-cart"></i></span>Agregar al carrito
                                                        </asp:LinkButton>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>


                                                <%--<button type="button" class="btn btn-success waves-effect waves-light">
                                                    <span class="btn-label"><i class="mdi mdi-cart"></i></span>Agregar al carrito
                                                </button>--%>
                                            </div>
                                            <%--end boton atras y agregar al carrito--%>
                                        </div>
                                    </div>
                                    <!-- end col -->
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>

    <!-- Right bar overlay-->
    <div class="rightbar-overlay"></div>

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


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_Js" runat="Server">
    <script>
        function showSuccessMessage1() {
            swal({
                title: "Agregado Correctamente!",
                type: "success"
            }, function (redirect) {
                if (redirect) {
                    window.location.href = "Administrar_Pedido.aspx"
                }
            });
        }

        function flyToElement(flyer, flyingTo) {
            var $func = $(this);
            var divider = 3;
            var flyerClone = $(flyer).clone();
            $(flyerClone).css({ position: 'absolute', top: $(flyer).offset().top + "px", left: $(flyer).offset().left + "px", opacity: 1, 'z-index': 1000 });
            $('body').append($(flyerClone));
            var gotoX = $(flyingTo).offset().left + ($(flyingTo).width() / 2) - ($(flyer).width() / divider) / 2;
            var gotoY = $(flyingTo).offset().top + ($(flyingTo).height() / 2) - ($(flyer).height() / divider) / 2;

            $(flyerClone).animate({
                opacity: 0.4,
                left: gotoX,
                top: gotoY,
                width: $(flyer).width() / divider,
                height: $(flyer).height() / divider
            }, 700,
                function () {
                    $(flyingTo).fadeOut('fast', function () {
                        $(flyingTo).fadeIn('fast', function () {
                            $(flyerClone).fadeOut('fast', function () {
                                $(flyerClone).remove();
                            });
                        });
                    });
                });
        }

    </script>
    <!-- Tour page js -->
    <script src="../assets/libs/hopscotch/js/hopscotch.min.js"></script>
    <!-- Tour init js-->
    <script src="../assets/js/pages/tour.init.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnAgregarCarrito').on('click', function () {
                //Scroll to top if cart icon is hidden on top
                $('html, body').animate({
                    'scrollTop': $("#btnAgregarCarrito").position().top
                });
                //Select item image and pass to the function
                var itemImg = $(this).parent().find('img').eq(0);
                flyToElement($(itemImg), $('#btnAgregarCarrito'));
            });
        });
    </script>
</asp:Content>
