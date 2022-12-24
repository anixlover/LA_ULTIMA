$('input[type=radio][name=TipoPedido]').change(function () {
    if (this.value == '1') {
        $("#valorObtenidoRBTN").val('1');
    }
    else if (this.value == '2') {
        $("#valorObtenidoRBTN").val('2');
    }
    console.log($("#valorObtenidoRBTN").val());

});


$("#rbCatalogo").change(function () {
    var rdb = $('#rbCatalogo').val();
    console.log($('#rbCatalogo').val());
    if (rdb == "1") {
        $("#catalogo").fadeIn();

        $("#personalizado").fadeOut();
    }
});

$("#rbDiseñoPropio").change(function () {
    var rdb2 = $('#rbDiseñoPropio').val();
    console.log($('#rbDiseñoPropio').val());
    if (rdb2 == "2") {
        $("#personalizado").fadeIn();
        $("#catalogo").fadeOut();
    }
});