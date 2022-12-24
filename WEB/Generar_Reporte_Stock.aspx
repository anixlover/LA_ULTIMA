<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="Generar_Reporte_Stock.aspx.cs" Inherits="WEB.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../assets/css/bootstrap-saas.min.css" rel="stylesheet" type="text/css" id="bs-default-stylesheet" />
    <link href="../assets/css/app-saas.min.css" rel="stylesheet" type="text/css" id="app-default-stylesheet" />
    <link href="../assets/css/bootstrap-saas-dark.min.css" rel="stylesheet" type="text/css" id="bs-dark-stylesheet" />
    <link href="../assets/css/app-saas-dark.min.css" rel="stylesheet" type="text/css" id="app-dark-stylesheet" />
    <script src="../libs/morris.min.js" charset="utf-8"></script>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-page">
        <div class="content">

            <!-- Start Content-->
            <div class="container-fluid">

                <!-- start page title -->
                <div class="row">
                    <div class="col-12">
                        <div class="page-title-box">
                            <div class="page-title-right">
                                <ol class="breadcrumb m-0">
                                    <li class="breadcrumb-item"><a href="javascript: void(0);">UBold</a></li>
                                    <li class="breadcrumb-item"><a href="javascript: void(0);">CRM</a></li>
                                    <li class="breadcrumb-item active">Dashboard</li>
                                </ol>
                            </div>
                            <h4 class="page-title">Dashboard</h4>
                        </div>
                    </div>
                </div>
                <!-- end page title -->

                <div class="row">
                    <div class="col-lg-6 col-xl-3">
                        <div class="card-box bg-pattern">
                            <div class="row">
                                <div class="col-6">
                                    <div class="avatar-md bg-blue rounded">
                                        <i class="fe-layers avatar-title font-22 text-white"></i>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="text-right">
                                        <h3 class="text-dark my-1"><span data-plugin="counterup">12,008</span></h3>
                                        <p class="text-muted mb-0 text-truncate">Campaign Sent</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- end card-box-->
                    </div>
                    <!-- end col -->

                    <div class="col-lg-6 col-xl-3">
                        <div class="card-box bg-pattern">
                            <div class="row">
                                <div class="col-6">
                                    <div class="avatar-md bg-success rounded">
                                        <i class="fe-award avatar-title font-22 text-white"></i>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="text-right">
                                        <h3 class="text-dark my-1"><span data-plugin="counterup">7,410</span></h3>
                                        <p class="text-muted mb-0 text-truncate">New Leads</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- end card-box-->
                    </div>
                    <!-- end col -->
                    <div class="col-lg-6 col-xl-3">
                        <div class="card-box bg-pattern">
                            <div class="row">
                                <div class="col-6">
                                    <div class="avatar-md bg-danger rounded">
                                        <i class="fe-delete avatar-title font-22 text-white"></i>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="text-right">
                                        <h3 class="text-dark my-1"><span data-plugin="counterup">2,125</span></h3>
                                        <p class="text-muted mb-0 text-truncate">Deals</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- end card-box-->
                    </div>
                    <!-- end col -->
                    <div class="col-lg-6 col-xl-3">
                        <div class="card-box bg-pattern">
                            <div class="row">
                                <div class="col-6">
                                    <div class="avatar-md bg-warning rounded">
                                        <i class="fe-dollar-sign avatar-title font-22 text-white"></i>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="text-right">
                                        <h3 class="text-dark my-1">$<span data-plugin="counterup">256</span>k</h3>
                                        <p class="text-muted mb-0 text-truncate">Booked Revenue</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- end card-box-->
                    </div>
                    <!-- end col -->
                </div>
                <!-- end row-->


                <div class="row">
                    <div class="col-xl-6">
                        <div class="card-box pb-2">
                            <div class="float-right d-none d-md-inline-block">
                                <div class="btn-group mb-2">
                                    <button type="button" class="btn btn-xs btn-light">Today</button>
                                    <button type="button" class="btn btn-xs btn-light">Weekly</button>
                                    <button type="button" class="btn btn-xs btn-secondary">Monthly</button>
                                </div>
                            </div>

                            <h4 class="header-title mb-3">Deals Analytics</h4>

                            <div dir="ltr">
                                <div id="deal-analytics" class="mt-4" data-colors="#1abc9c,#f1556c"></div>
                            </div>
                        </div>
                        <!-- end card-box -->
                    </div>
                    <!-- end col-->

                    <div class="col-xl-6">
                        <div class="card-box">
                            <div class="float-right d-none d-md-inline-block">
                                <div class="btn-group mb-2">
                                    <button type="button" class="btn btn-xs btn-light">Today</button>
                                    <button type="button" class="btn btn-xs btn-light">Weekly</button>
                                    <button type="button" class="btn btn-xs btn-secondary">Monthly</button>
                                </div>
                            </div>

                            <h4 class="header-title mb-3">Sales Analytics</h4>
                            <div dir="ltr">
                                <div id="sales-analytics" class="apex-charts" data-colors="#6658dd,#1abc9c"></div>
                            </div>
                        </div>
                        <!-- end card-box -->
                    </div>
                    <!-- end col-->
                </div>
                <!-- end row -->
            </div>
        </div>
    </div>
    <!-- Right bar overlay-->
    <div class="rightbar-overlay"></div>

    <!-- Vendor js -->
    <script src="../assets/js/vendor.min.js"></script>

    <!-- Plugins js-->
    <script src="../assets/libs/flatpickr/flatpickr.min.js"></script>
    <script src="../assets/libs/apexcharts/apexcharts.min.js"></script>

    <script src="../assets/libs/selectize/js/standalone/selectize.min.js"></script>

    <!-- Dashboar 1 init js-->
    <script src="../assets/js/pages/dashboard-1.init.js"></script>

    <!-- App js-->
    <script src="../assets/js/app.min.js"></script>

</asp:Content>
