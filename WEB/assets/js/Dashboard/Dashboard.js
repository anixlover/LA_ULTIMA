$(document).ready(function () {

    obtenerVentasPorCatalogo();
    obtenerVentasPersonalizadas();
    obtenerProductosVendidos();
    obtenerIngresos();

});

function obtenerVentasPorCatalogo() {

    $.ajax({
        url: 'Dashboard.aspx/ObtenerVentasPorCatalogo',
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        processData: false,
        success: function (data) {

            $("#ventas-catalogo h2").text(data.d.TotalVentasCatalogoMensual);

            $("#ventas-catalogo #total-ventas-catalogo").text(data.d.TotalVentasCatalogo);

        },
        error: function (err) {
        }

    });

}

function obtenerVentasPersonalizadas() {
    
    $.ajax({
        url: 'Dashboard.aspx/ObtenerVentasPersonalizadas',
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        processData: false,
        success: function (data) {

            $("#ventas-personalizada h2").text(data.d.TotalVentasPersonalizadasMensual);

            $("#ventas-personalizada #total-ventas-personalizada").text(data.d.TotalVentasPersonalizadas);

        },
        error: function (err) {
        }

    });
}

function obtenerIngresos() {
    
    $.ajax({
        url: 'Dashboard.aspx/ObtenerIngresos',
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        processData: false,
        success: function (data) {

            $("#ingresos h2").text(data.d.TotalIngresosMensual);

            $("#ingresos #total-ingresos").text(data.d.TotalIngresos);

        },
        error: function (err) {
        }

    });
}


function obtenerVisualizaciones() {

    $.ajax({
        url: 'Dashboard.aspx/ObtenerVisualizaciones',
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        processData: false,
        success: function (data) {

            $("#visualizaciones h2").text(convertirCantidad(data.d.TotalVisualizacionesMes, ["B", "M", "K"]));

            $("#visualizaciones #total-visualizaciones").text(convertirCantidad(data.d.TotalVisualizaciones, ["B", "M", "K"]));

        },
        error: function (err) {
        }
          
    });

}

function obtenerProductosVendidos() {
    $.ajax({
        url: 'Dashboard.aspx/ObtenerProductosVendidos',
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        processData: false,
        success: function (data) {

            $("#productos-vendidos tbody").append(obtenerProductos(data.d));
        },
        error: function (err) {
        }
        

    });
}

function obtenerProductos(products) {

    var productos = "";

    for (var i = 0; i < products.length; i++) {

        productos += "<tr>";
        productos += "<td>" + products[i].Codigo + "</td>";
        productos += "<td>" + products[i].Descripcion + "</td>";
        productos += "<td> S/. " + products[i].Precio.toFixed(2) + "</td>";
        productos += "<td>" + products[i].Cantidad + "</td>";
        productos += "<td> S/. " + products[i].Monto.toFixed(2) + "</td>" ;
        productos += "</tr>";
    }

    return productos;
    

}

function convertirCantidad(cantidad, representaciones) {

    return Math.abs(Number(cantidad)) >= 1.0e+9 
        ? Math.abs(Number(cantidad)) / 1.0e+9  + representaciones[0]
        : Math.abs(Number(cantidad)) >= 1.0e+6
        ? Math.abs(Number(cantidad)) / 1.0e+6  + representaciones[1]
        : Math.abs(Number(cantidad)) >= 1.0e+3
        ? Math.abs(Number(cantidad)) / 1.0e+3  + representaciones[2]
        : Math.abs(Number(cantidad));

}

