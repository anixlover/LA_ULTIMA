<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WEB.Dashboard" %>
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

<div class="row mt-2">
    <div class="col-sm-12 col-md-6 col-xl-6">

    </div>
    <div class="col-sm-12 col-md-6 col-xl-6">
        <div class="card-box" id="visualizaciones">
            <i class="fa fa-info-circle text-muted float-right" data-toggle="tooltip" data-placement="bottom" 
                title="Número de visitas en el mes"></i>
            <h4 class="mt-0 font-16">Usuarios Recientes</h4>
            <h2 class="text-primary my-3 text-center">567</h2>
            <p class="text-muted mb-0">Usuarios Totales: <span id="total-visualizaciones">345</span></p>
        </div>
    </div>
    <div class="col-sm-12 col-md-6 col-xl-6">

    </div>
    <div class="col-sm-12 col-md-6 col-xl-6">

    </div>
    <div class="col-sm-12 col-md-6 col-xl-4">

    </div>
    <div class="col-sm-12 col-md-6 col-xl-8">

    </div>
    <div class="col-sm-12 col-md-6 col-xl-8">

    </div>
    <div class="col-sm-12 col-md-6 col-xl-4">
        <div class="card">
            <div class="card-body">

                <h4 class="header-title mb-3">Que hacer</h4>
                <div class="todoapp">
                    <div class="row">
                        <div class="col">
                            <h5 id="todo-message"><span id="todo-remaining"></span> de <span id="todo-total"></span> restantes</h5>
                        </div>
                        <div class="col-auto">
                              <a href="" class="float-right btn btn-light btn-sm" id="btn-archive">Archivar</a>
                        </div>
                     </div>
                    <div style="max-height: 310px;" data-simplebar>
                        <ul class="list-group list-group-flush todo-list" id="todo-list"></ul>
                    </div>

                    <form name="todo-form" id="todo-form" class="needs-validation mt-3" novalidate>
                        <div class="row">
                            <div class="col">
                                <input type="text" id="todo-input-text" name="todo-input-text" class="form-control"
                                    placeholder="Agregar una nueva tarea pendiente" required/>
                                <div class="invalid-feedback">
                                    Ingrese el nombre ed su tarea
                                </div>
                            </div>
                            <div class="col-auto">
                                <button class="btn-primary btn-md btn-block btn waves-effect waves-light" type="submit"
                                    id="todo-btn-submit">Añadir</button>
                            </div>
                        </div>
                    </form>

                </div>
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
<script src="../../plugins/sweetalert/sweetalert.min.js"></script>

<!-- Sweet Alerts js -->
<script src="../assets/libs/sweetalert2/sweetalert2.min.js"></script>
<script src="assets/libs/sweetalert2/sweetalert2.all.min.js"></script>

<!-- Sweet alert init js-->
<script src="../assets/js/pages/sweet-alerts.init.js"></script>

<script src="assets/js/pages/jquery.todo.js"></script>

<script src="assets/js/Dashboard/Dashboard.js"></script>

</asp:Content>
