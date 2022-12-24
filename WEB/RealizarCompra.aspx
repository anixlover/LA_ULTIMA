<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="RealizarCompra.aspx.cs" Inherits="WEB.RealizarCompra" %>

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
<%--<asp:Content ID="Content2" ContentPlaceHolderID="cph_Js" runat="server">    
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-12">
            <div class="card">
                <div class="card-header">
                    <h4>REALIZAR COMPRA</h4>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="row-cols-lg-4">
                                <br />
                                <div align="center">
                                    <div class="row" style="color: #ff585b; font-weight: bold; font-style: inherit;">
                                        <h4>No Cuenta:191-96831044-0-33  </h4>
                                        <asp:Label ID="Label1" runat="server" Text="0.00"></asp:Label>
                                    </div>

                                </div>
                                <asp:GridView ID="gvDetalles" runat="server" CssClass="table-borderless table table-bordered table-hover" DataKeyNames="PK_IM_Cod" AutoGenerateColumns="False"
                                    EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" Width="90%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Imagen">
                                            <ItemTemplate>
                                                <img src='ObtieneImagen.ashx?id=<%# Eval("PK_IM_Cod")%>' height="80px" width="80px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PK_IM_Cod"  HeaderText="Coóigo de Moldura" />
                                        <asp:BoundField DataField="VM_Descripcion"  HeaderText="Descripción de Moldura" />
                                        <asp:BoundField DataField="VTM_Nombre"  HeaderText="Tipo de Moldura" />
                                        <asp:BoundField DataField="IMU_Cantidad"  HeaderText="Cantidad" />
                                        <asp:BoundField DataField="DMU_Precio"  HeaderText="Precio" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="row-cols-lg-4">
                                <asp:GridView ID="gvPersonalizado" runat="server" DataKeyNames="PK_IS_Cod" AutoGenerateColumns="False"
                                    EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Imagen">
                                            <ItemTemplate>
                                                <img src='ObtenerImegenPersonalizada_2.ashx?id=<%# Eval("PK_IS_Cod")%>' height="60px" width="60px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PK_IS_Cod"  HeaderText="Código de solicitud" />
                                        <asp:BoundField DataField="DS_Largo"  HeaderText="Largo" />
                                        <asp:BoundField DataField="DS_Ancho"  HeaderText="Ancho" />
                                        <asp:BoundField DataField="VS_Comentario"  HeaderText="Cometario" />
                                        <asp:BoundField DataField="IS_Cantidad"  HeaderText="Cantidad" />
                                        <asp:BoundField DataField="DS_ImporteTotal"  HeaderText="Precio (S/.)" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <br />
                            <div class="row" style="color: #008000; font-weight: bold; font-style: inherit;">
                                <h3>Total: S/. </h3>
                                <asp:Label ID="lblcosto" runat="server" Text="0.00"></asp:Label>
                            </div>
                        </div>
                        <div class="col-lg-8">
                            <div class="row">
                                <asp:FileUpload ID="FileUpload1" runat="server" accept="image/*" onchange="leerImagen(this);" data-plugins="dropify" data-height="300" />
                            </div>
                            <br />
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <asp:RadioButton ID="rbBoleta" runat="server" AutoPostBack="True" Text="Boleta" GroupName="pago" OnCheckedChanged="rbBoleta_CheckedChanged" />
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:RadioButton ID="rbFactura" runat="server" AutoPostBack="True" GroupName="pago" Text="Factura" OnCheckedChanged="rbFactura_CheckedChanged" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <label for="heard">Número de operación: <span class="text-danger">*</span></label>
                                        <asp:TextBox ID="txtNumOP" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <label for="heard">Importe: <span class="text-danger">*</span></label>
                                        <asp:TextBox ID="txtImporte" type="number" runat="server" CssClass="form-control" step=".01"></asp:TextBox>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <asp:CheckBox ID="chbNuevoRUC" runat="server" AutoPostBack="True" Text="Nuevo RUC" OnCheckedChanged="chbNuevoRUC_CheckedChanged" />
                                    </div>
                                    <div class="row">
                                        <asp:Label ID="lblTitulo1" Text="RUCS:" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtNuevoRUC" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        <asp:DropDownList ID="ddlRUC" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col" style="text-align: center">
                                            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-success" Width="50%" OnClick="btnEnviar_Click" />
                                        </div>
                                        <div class="col" style="text-align: center">
                                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" Width="50%" OnClick="btnCancelar_Click" />
                                        </div>
                                        <input type="hidden" runat="server" id="hftxtimg" clientidmode="Static" value="vacio" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
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
</asp:Content>
