$(document).ready(function () {

    obtenerVentasPorCatalogo();
    obtenerVentasPersonalizadas();
    obtenerProductosVendidos();
    obtenerIngresos();
    obtenerVentasPorMes();
    obtenerIngresosTotales();
    obtenerVentasAnuales();

});

function obtenerVentasAnuales() {

    $.ajax({
        url: 'Dashboard.aspx/ObtenerVentasAnuales',
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        processData: false,
        success: function (data) {

            crearGraficoVentasAnuales(data.d);
        },
        error: function (err) {
        }

    });
}

function obtenerIngresosTotales() {

    crearGraficoIngresos();

    $.ajax({
        url: 'Dashboard.aspx/ObtenerIngresosTotales',
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        processData: false,
        success: function (data) {

            $("#total-revenue-day").text("S/. " + data.d.IngresoDiario);
            $("#total-revenue-month").text("S/. " + data.d.IngresoMensual);
            $("#total-revenue-week").text("S/. " + data.d.IngresoSemanal);

        },
        error: function (err) {
        }

    });
}

function obtenerVentasPorMes() {
    $.ajax({
        url: 'Dashboard.aspx/ObtenerVentasPorMes',
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        processData: false,
        success: function (data) {

            crearGraficosVentas(data.d);

        },
        error: function (err) {
        }

    });
}

function crearGraficoIngresos() {

    var dataColors;
    var colors = ["#f1556c"]; 


    dataColors = $("#total-revenue").data("colors");
    color = dataColors.split(",");

    obtenerPorcentajeDia();

    var porcentajedias = obtenerPorcentajeDia();

    var chart;
    let options = {
        series: [porcentajedias],
        chart: { height: 220, type: "radialBar" },
        plotOptions: { radialBar: { hollow: { size: "65%" } } },
        colors: colors,
        labels: ["Diario"]
    };

    chart = new ApexCharts(document.querySelector("#total-revenue"), options).render();
    
}

function obtenerPorcentajeDia() {

    var fechaActual = new Date();

    var diaActual = fechaActual.getDate();
    
    fechaActual.setMonth(new Date().getMonth() + 1);
    fechaActual.setDate(0);

    var ultimoDia = fechaActual.getDate();

    var porcentajeDia = (diaActual * 100) / ultimoDia;

    return porcentajeDia.toFixed(2);
}

function crearGraficoVentasAnuales(ventas) {
    var dataColors;
    var colors = ["#4a81d4", "#e3eaef"];

    dataColors = $("#annually-sales-analytics").data("colors");
    color = dataColors.split(",");

    var chart;
    var ventasAnuales = convertVentasParaGraficoAnual(ventas);

    var options = {
        chart: { height: 380, type: "bar" },
        plotOptions: { bar: { horizontal: !1, endingShape: "rounded", columnWidth: "55%" } },
        dataLabels: { enabled: !1 },
        stroke: { show: !0, width: 2, colors: ["transparent"] },
        colors: colors,
        series: [
            {
                name: "Ingreso Actual",
                data: ventasAnuales.ingresosActuales
            },
            {
                name: "Ingreso Año Anterior",
                data: ventasAnuales.ingresosPasados
            }
        ],
        xaxis: { categories: ventasAnuales.meses },
        legend: { offsetY: 5 },
        yaxis: { title: { text: "Ingresos" } },
        fill: { opacity: 1 },
        grid: {
            row: { colors: ["transparent", "transparent"], opacity: .2 },
            borderColor: "#f1f3fa", padding: { bottom: 10 }
        },
        tooltip: {
            y: { formatter: function (e) { return "S/. " + e.toFixed(2); } }
        }
    };

    chart = new ApexCharts(document.querySelector("#annually-sales-analytics"), options).render();
    
    
}


function crearGraficosVentas(ventas) {
    var dataColors;
    var colors = ["#1abc9c", "#4a81d4"];

    dataColors = $("#sales-analytics").data("colors");
    color = dataColors.split(",");

    var chart;
    var analisisVenta = convertirVentasParaGraficoMensual(ventas);

    var options = {
        series: [
            {
                name: "Ingresos",
                type: "column",
                data: analisisVenta.ingresos
            },
            {
                name: "Cantidad",
                type: "line",
                data: analisisVenta.cantidades
            }
        ],
        chart: {
            height: 378, type: "line"
        },
        stroke: {
            width: [2, 3]
        },
        plotOptions: {
            bar: { columnWidth: "50%" }
        },
        colors: colors,
        dataLabels: { enabled: !0, enabledOnSeries: [1] },
        labels: analisisVenta.meses,
        xaxis: { type: "string" },
        legend: { offsetY: 7 },
        grid: { padding: { bottom: 20 } },
        fill: { type: "gradient", gradient: { shade: "light", type: "horizontal", shadeIntensity: .25, gradientToColors: void 0, inverseColors: !0, opacityFrom: .75, opacityTo: .75, stops: [0, 0, 0] } },
        yaxis: [{ title: { text: "Ingresos" } }, { opposite: !0, title: { text: "Número de Ventas" } }]
    }

    chart = new ApexCharts(document.querySelector("#sales-analytics"), options).render();

    
}

function convertVentasParaGraficoAnual(ventas) {

    var meses = ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"];
    var anioActual = new Date().getFullYear();

    var ventasGrafico = {
        ingresosActuales: [],
        ingresosPasados: [],
        meses: []
    };

    for (var i = 0; i < 12; i++) {

        let venta = ventas.filter(venta => venta.Mes == i + 1);

        if (venta === undefined || venta === null) {
            ventasGrafico.ingresosActuales.push(0);
            ventasGrafico.ingresosPasados.push(0);
        }
        else {

            var ingresoActual = venta.find(venta => venta.Anio == anioActual)?.Ingreso ?? 0;
            var ingresoPasado = venta.find(venta => venta.Anio == anioActual - 1)?.Ingreso ?? 0;

            ventasGrafico.ingresosActuales.push(ingresoActual);
            ventasGrafico.ingresosPasados.push(ingresoPasado);

        }

        ventasGrafico.meses.push(meses[i]);
    }

    return ventasGrafico;
}


function convertirVentasParaGraficoMensual(ventas) {

    var meses = ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"];

    var ventasGrafico = {
        ingresos: [],
        cantidades: [],
        meses: []
    };

    for (var i = 0; i < 12; i++) {

        let venta = ventas.find(venta => venta.Mes == i + 1);

        if (venta === undefined || venta === null) {
            ventasGrafico.ingresos.push(0);
            ventasGrafico.cantidades.push(0);
        }
        else {
            ventasGrafico.ingresos.push(venta.Ingreso);
            ventasGrafico.cantidades.push(venta.Cantidad);
            
        }

        ventasGrafico.meses.push(meses[i]);
    }

    return ventasGrafico;

}

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

            $("#ingresos h2").text("S/. " + data.d.TotalIngresosMensual.toFixed(2));

            $("#ingresos #total-ingresos").text("S/. " + data.d.TotalIngresos.toFixed(2));

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

