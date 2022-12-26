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
    <div class="col-sm-12 col-md-4 col-xl-4">
        <div class="card-box" id="ventas-catalogo">
            <i class="fa fa-info-circle text-muted float-right" data-toggle="tooltip" data-placement="bottom" 
                title="Ventas del mes"></i>
            <h4 class="mt-0 font-16">Estado de ventas por catálogo</h4>
            <h2 class="text-primary my-3 text-center">567</h2>
            <p class="text-muted mb-0">Ventas Totales: <span id="total-ventas-catalogo">345</span></p>
        </div>
    </div>
    <div class="col-sm-12 col-md-4 col-xl-4">
        <div class="card-box" id="ventas-personalizada">
            <i class="fa fa-info-circle text-muted float-right" data-toggle="tooltip" data-placement="bottom" 
                title="Ventas del mes"></i>
            <h4 class="mt-0 font-16">Estado de ventas personalizada</h4>
            <h2 class="text-primary my-3 text-center">567</h2>
            <p class="text-muted mb-0">Ventas Totales: <span id="total-ventas-personalizada">345</span></p>
        </div>
    </div>
    <div class="col-sm-12 col-md-4 col-xl-4">
        <div class="card-box" id="ingresos">
            <i class="fa fa-info-circle text-muted float-right" data-toggle="tooltip" data-placement="bottom" 
                title="Ingresos totales del mes"></i>
            <h4 class="mt-0 font-16">Los ingresos totales</h4>
            <h2 class="text-primary my-3 text-center">567</h2>
            <p class="text-muted mb-0">Ingresos Totales: <span id="total-ingresos">345</span></p>
        </div>
    </div>
    <div class="col-sm-12 col-md-6 col-xl-4">
        <div class="card-box">
             <h4 class="header-title mb-0">Ingresos Totales</h4>
            <div class="widget-chart text-center" dir="ltr">
                                        
                <div id="total-revenue" class="mt-0"  data-colors="#f1556c"></div>

                <h5 class="text-muted mt-0">Ventas totales realizadas hoy</h5>
                <h2 id="total-revenue-day">S/. 0.00</h2>

                <div class="row mt-3">
                    <div class="col-6">
                        <p class="text-muted font-15 mb-1 text-truncate">La semana </p>
                        <h4 id="total-revenue-week">S/. 0.00</h4>
                    </div>
                    <div class="col-6">
                        <p class="text-muted font-15 mb-1 text-truncate">Mes pasado</p>
                        <h4 id="total-revenue-month">S/. 0.00</h4>
                    </div>
                </div>                      
            </div>
        </div>
         
    </div>
    <div class="col-sm-12 col-md-6 col-xl-8">
        <div class="card-box pb-2">
           <%-- <div class="float-right d-none d-md-inline-block">
                <div class="btn-group mb-2">
                    <button type="button" class="btn btn-xs btn-light">Hoy día</button>
                    <button type="button" class="btn btn-xs btn-light">Semanalmente</button>
                    <button type="button" class="btn btn-xs btn-secondary">Mensual</button>
                </div>
            </div>--%>

            <h4 class="header-title mb-3">Análisis de Ventas</h4>

            <div dir="ltr">
                <div id="sales-analytics" class="mt-4" data-colors="#1abc9c,#4a81d4"></div>
            </div>
        </div>
    </div>
    <div class="col-sm-12 col-md-12 col-xl-12">
        <div class="card-box pb-2">
            <div class="float-right d-none d-md-inline-block">
                <%--<div class="btn-group mb-2">
                    <button type="button" class="btn btn-xs btn-light">Hoy día</button>
                    <button type="button" class="btn btn-xs btn-light">Semanalmente</button>
                    <button type="button" class="btn btn-xs btn-secondary">Mensual</button>
                </div>--%>
            </div>

            <h4 class="header-title mb-3">Año Actual vs Año Anterior</h4>

            <div dir="ltr">
                <div id="annually-sales-analytics" class="mt-4" data-colors="#4a81d4,#e3eaef"></div>
            </div>
        </div>
    </div>
    <div class="col-sm-12 col-md-6 col-xl-8">
        <div class="card">
            <div class="card-body">
                <div class="card-widgets">
                    <a href="javascript: void(0);" data-toggle="reload"><i class="mdi mdi-refresh"></i></a>
                    <a data-toggle="collapse" href="#productos-vendidos" role="button" aria-expanded="false" aria-controls="productos-vendidos"><i class="mdi mdi-minus"></i></a>
                    <a href="javascript: void(0);" data-toggle="remove"><i class="mdi mdi-close"></i></a>
                </div>
                <h4 class="header-title mb-0">Productos Más Vendidos</h4>
                <div class="collapse pt-3 show" id="productos-vendidos">
                    <div class="table-responsive">
                        <table class="table table-hover table-centered mb-0">
                            <thead>
                                <tr>
                                    <th>Código</th>
                                    <th>Tipo de Producto</th>
                                    <th>Precio</th>
                                    <th>Cantidad</th>
                                    <th>Monto</th>
                                </tr>
                            </thead>
                            <tbody>
                                
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
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
                                    Ingrese el nombre de su tarea
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
