<%@ Page Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="Inspeccionar_Catalogo.aspx.cs" Inherits="WEB.Inspeccionar_Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../assets/css/bootstrap-saas.min.css" rel="stylesheet" type="text/css" id="bs-default-stylesheet" />
    <link href="../assets/css/app-saas.min.css" rel="stylesheet" type="text/css" id="app-default-stylesheet" />
    <link href="../assets/css/bootstrap-saas-dark.min.css" rel="stylesheet" type="text/css" id="bs-dark-stylesheet" />
    <link href="../assets/css/app-saas-dark.min.css" rel="stylesheet" type="text/css" id="app-dark-stylesheet" />
    <!-- Lightbox css -->
    <link href="../assets/libs/magnific-popup/magnific-popup.css" rel="stylesheet" type="text/css" />

    <!-- icons -->
    <link href="../assets/css/icons.min.css" rel="stylesheet" type="text/css" />

    <link href="assets/css/StyleSheet1.css" rel="stylesheet" type="text/css" />
    <!-- Tour css -->
    <link href="../assets/libs/hopscotch/css/hopscotch.min.css" rel="stylesheet" type="text/css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <style>
        .image-popup img{
            width: 259px !important;
            height: 194px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="seccion contenedor clearfix">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <h2>Catalogo</h2>
        <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Always">
            <ContentTemplate>
                <div class="row">
                    <div class="col-12">
                        <div class="text-center filter-menu">
                            <div class="contenedor-molduras">
                                <asp:LinkButton runat="server" class="filter-menu-item" ID="btnTodos" OnClick="btnTodos_Click">Todos</asp:LinkButton>
                                <asp:LinkButton runat="server" class="filter-menu-item" ID="btnBaquetonClasico" OnClick="btnBaquetonClasico_Click">Baqueton Clasico</asp:LinkButton>
                                <asp:LinkButton runat="server" class="filter-menu-item" ID="btnBaquetonDecorado" OnClick="btnBaquetonDecorado_Click">Baqueton Decorado</asp:LinkButton>
                                <asp:LinkButton runat="server" class="filter-menu-item" ID="btnRosetonClasico" OnClick="btnRosetonClasico_Click">Roseton Clasico</asp:LinkButton>
                                <asp:LinkButton runat="server" class="filter-menu-item" ID="btnRosetonDecorado" OnClick="btnRosetonDecorado_Click">Roseton Decorado</asp:LinkButton>
                                <asp:LinkButton runat="server" class="filter-menu-item" ID="btnCornisaClasica" OnClick="btnCornisaClasica_Click">Cornisa Clasica</asp:LinkButton>
                                <asp:LinkButton runat="server" class="filter-menu-item" ID="btnCornisaDecorada" OnClick="btnCornisaDecorada_Click">Cornisa Decorada</asp:LinkButton>
                                <asp:LinkButton runat="server" class="filter-menu-item" ID="btnPlaca3D" OnClick="btnPlaca3D_Click">Placa 3D</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <ul class="row filterable-content" id="ListaMoldura" runat="server"></ul>

            </ContentTemplate>
        </asp:UpdatePanel>

        <script>
            function cargarInformacion(PK_IM_Cod) {
                location.href = `DescripcionMoldura.aspx?id=${PK_IM_Cod}`;
            }
        </script>
    </section>
    <script src="js/Aplicacion/UploadFile.js"></script>
    <script>
        function showSuccessMessage2() {
            setTimeout(function () {
                swal({
                    title: "Todo guardado",
                    text: "Pulsa el botón y se te redirigirá",
                    type: "success"
                }, function () {
                    window.location = ".aspx";
                });
            }, 1000);
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
        function mostrarMensaje() {
            alert('Aham, lo que parecía un link en realidad lo que está haciendo es ejecutar una función javascript!');
        }

   
    < !--Tour page js-- >
            <script src="../assets/libs/hopscotch/js/hopscotch.min.js"></script>

    <!-- Tour init js-->

</asp:Content>

