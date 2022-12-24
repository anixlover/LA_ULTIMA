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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
    <section class="seccion contenedor clearfix">
        <h2>Descripcion</h2>
        <div class="descripcion-moldura">
            <asp:UpdatePanel ID="upBotonEnviar" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <%--Medida--%>
                    <%--<p>Medida:<asp:Label ID="txtmedida" runat="server"></asp:Label></p>
                    <p>
                        Largo:
                        <asp:Label ID="txtlargo" runat="server"></asp:Label>
                        Ancho:
                        <asp:Label ID="txtancho" runat="server"></asp:Label>
                    </p>--%>
                    <%--Precio--%>
                    <%--Descripcion--%>

                    <%--                    <asp:Button runat="server" ID="Button1" CssClass="button" Text="Regresar" OnClick="Button1_Click" />
                    <asp:LinkButton runat="server" ID="Button2" CssClass="button" Text="Agregar al carrito" OnClick="Button1_Click"></asp:LinkButton>
                    <a href="#" class="button" onclick="btn_regresar()"><i class="fas fa-shopping-cart"></i></a>--%>

                    <%--<asp:Button runat="server" ID="btnModal" CssClass="button" Text="Agregar a carrito de compra" data-target="#defaultmodal" data-toggle="modal" />--%>


                    <div class="row">
                        <div class="col-12">
                            <div class="card-box">
                                <div class="row">
                                    <div class="col-lg-5">

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
                                    <div class="col-lg-7">
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
                                                <asp:Label ID="txtlargo" runat="server" ClientIDMode="Static"></asp:Label>cm
                                            </p>
                                            <%--end largo--%>

                                            <%--ancho--%>
                                            <h4 class="mb-4">
                                            <p>
                                                Ancho:
                                                <asp:Label ID="txtancho" runat="server" ClientIDMode="Static"></asp:Label>cm
                                            </p>
                                            <%--end ancho--%>


                                            <%--Precio--%>
                                            <h4 class="mb-4">
                                                <%--Precio : --%>
                                            <p>Precio: S./<asp:Label ID="txtprecio" runat="server" ClientIDMode="Static"></asp:Label></p>
                                            <%--<span class="text-muted mr-2"><del>$80 USD</del></span> <b>$64 USD</b></h4>--%>

                                            <%--stock--%>
                                            <h4 class="mb-4">
                                            <p>
                                                Stock:
                                                <asp:Label ID="txtstock" runat="server" ClientIDMode="Static"></asp:Label>
                                            </p>

                                            <%--end stock--%>


                                            <%--end precio--%>
                                            
                                            <%--Descripcion mas a detalle del producto--%>
                                            <h4 class="mb-4">
                                            <p class="text-muted mb-4">
                                                <asp:Label ID="txtdescripcion" runat="server"></asp:Label></>
                                                <%--The languages only differ in their grammar, their pronunciation 
                                                and their most common words. Everyone realizes why a new common language would be desirable: 
                                                one could refuse to pay expensive translators.--%>
                                            </p>
                                            <%--end descripcion--%>

                                           <%-- <form class="form-inline mb-4">
                                                <label class="my-1 mr-2" for="quantityinput">Quantity</label>
                                                <select class="custom-select my-1 mr-sm-3" id="quantityinput">
                                                    <option value="1">1</option>
                                                    <option value="2">2</option>
                                                    <option value="3">3</option>
                                                    <option value="4">4</option>
                                                    <option value="5">5</option>
                                                    <option value="6">6</option>
                                                    <option value="7">7</option>
                                                </select>
                                            </form>--%>

                                            <div>
                                                <%--<button type="button" class="btn btn-danger mr-2"><i class="mdi mdi-heart-outline"></i></button>--%>
                                                <button type="button" class="btn btn-danger waves-effect">
                                                    <span class="btn-label"><i class="mdi dripicons-return"></i></span>Atras 
                                                </button>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <button type="button" class="btn btn-success waves-effect waves-light">
                                                    <span class="btn-label"><i class="mdi mdi-cart"></i></span>Add to cart
                                                </button>
                                            </div>
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
</asp:Content>

