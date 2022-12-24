$(document).ready(function () {

    obtenerVisualizaciones();

});

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

function convertirCantidad(cantidad, representaciones) {

    return Math.abs(Number(cantidad)) >= 1.0e+9 
        ? Math.abs(Number(cantidad)) / 1.0e+9  + representaciones[0]
        : Math.abs(Number(cantidad)) >= 1.0e+6
        ? Math.abs(Number(cantidad)) / 1.0e+6  + representaciones[1]
        : Math.abs(Number(cantidad)) >= 1.0e+3
        ? Math.abs(Number(cantidad)) / 1.0e+3  + representaciones[2]
        : Math.abs(Number(cantidad));

}

