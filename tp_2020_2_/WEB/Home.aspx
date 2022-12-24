<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WEB.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <!-- App css -->
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" id="bs-default-stylesheet" />
    <link href="../assets/css/app.min.css" rel="stylesheet" type="text/css" id="app-default-stylesheet" />

    <link href="../assets/css/bootstrap-dark.min.css" rel="stylesheet" type="text/css" id="bs-dark-stylesheet" />
    <link href="../assets/css/app-dark.min.css" rel="stylesheet" type="text/css" id="app-dark-stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12">
            <%--<div class="page-title-box">
                <h4 class="page-title">GESTIONAR CATALOGO</h4>
            </div>--%>
            <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                <ol class="carousel-indicators">
                    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                </ol>
                <div class="carousel-inner" role="listbox">
                    <div class="carousel-item active">
                        <img class="d-block img-fluid" src="../assets/images/small/Portada1.png" alt="First slide">
                    </div>
                    <div class="carousel-item">
                        <img class="d-block img-fluid" src="../assets/images/small/Portada2.png" alt="Second slide">
                    </div>
                    <div class="carousel-item">
                        <img class="d-block img-fluid" src="../assets/images/small/Portada2.png" alt="Third slide">
                    </div>
                </div>
                <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <div class="page-title-box">
                    <h4 class=" page-title">LOS MEJORES ACABADOS EN MOLDURAS PARA REALIZAR LOS DISTINTOS AMBIENTES</h4>
                
            </div>
        </div>
            
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <div class="row">
                    <h4 class="header-title"> Somos una empresa...</h4>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
