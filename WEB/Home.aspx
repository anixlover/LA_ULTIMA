<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WEB.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <!-- App css -->
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" id="bs-default-stylesheet" />
    <link href="../assets/css/app.min.css" rel="stylesheet" type="text/css" id="app-default-stylesheet" />

    <link href="../assets/css/bootstrap-dark.min.css" rel="stylesheet" type="text/css" id="bs-dark-stylesheet" />
    <link href="../assets/css/app-dark.min.css" rel="stylesheet" type="text/css" id="app-dark-stylesheet" />
    <!-- Tour css -->
    <link href="../assets/libs/hopscotch/css/hopscotch.min.css" rel="stylesheet" type="text/css" />
    <style>
        .div-card{
            display: flex;
            flex-direction: column;
            min-height: 506px
        }
        .card-image {
            width: 100%;
            height: 60%;
        }
        .card-text {
            width: 100%;
            height: 40%
        }
        .card-image img{
          height: calc(100% - XXpx); 
          object-fit: contain;
        }
    </style>
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
                        <img class="d-block img-fluid" src="../assets/images/ANA.png" alt="Second slide">
                    </div>
                    <div class="carousel-item">
                        <img class="d-block img-fluid" src="../assets/images/ANA4.png" alt="Third slide">
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
                    <h4 class="header-title" style="margin-left: 12px;"> Somos una empresa...</h4>
                </div>
                <div class="row">
                    <div class="col-4 div-card">
                       <div class="card-image" style="display: flex; justify-content: center; background-image: url('../assets/images/3.jpeg'); background-size:cover"></div>
                       <div class="card-text" style="text-align: justify">
                            Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
                       </div>
                    </div>
                    <div class="col-4 div-card">
                       <div class="card-image" style="background-image: url('../assets/images/2.jpeg'); background-size:cover"></div>
                       <div class="card-text" style="text-align: justify">
                            Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
                       </div>
                    </div>
                    <div class="col-4 div-card">
                       <div class="card-image" style="background-image: url('../assets/images/1.jpeg'); background-size:cover"></div>
                       <div class="card-text" style="text-align: justify">
                            Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
                       </div>
                    </div>
                </div>
            </div>
        </div>  
  </div>
     <!-- Tour page js -->
    <script src="../assets/libs/hopscotch/js/hopscotch.min.js"></script>

    <!-- Tour init js-->
    <script src="../assets/js/pages/tour.init.js"></script>
<%--    <script>
        var tour = {
            id: "hello-hopscotch",
            steps: [
                {
                    title: "Iniciar sesión",
                    content: "dar click aqui para acceder a su cuenta, caso de no tener cuenta puede registrarse.",
                    target: "login",
                    placement: "left"
                },
                {
                    title: "Carrito de compras",
                    content: "Para acceder al carrito de compras debe haberse registrado o iniciado sesión.",
                    target: "carrito",
                    placement: "left"
                },
                {
                    title: "Catalogo",
                    content: "Da click para visualizar las distintas variedades molduras.",
                    target: "catalogo",
                    placement: "left"
                }
            ]
        };
        hopscotch.startTour(tour);
    </script>--%>
</asp:Content>
