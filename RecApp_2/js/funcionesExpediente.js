//<!--Funciones del expediente. -->
     
/*FUNCIONES PARA EL ODONTOGRAMA*/
function cambiarOdontograma() {
    if(document.getElementById('decidua').checked){
        document.getElementById('ninoArriba').style.display = 'block';
        document.getElementById('ninoAbajo').style.display = 'block';
        document.getElementById('adultoArriba').style.display = 'none';
        document.getElementById('adultoAbajo').style.display = 'none';
    }
    else{
        document.getElementById('adultoArriba').style.display = 'block';
        document.getElementById('adultoAbajo').style.display = 'block';
        document.getElementById('ninoArriba').style.display = 'none';
        document.getElementById('ninoAbajo').style.display = 'none';
    }



}

function activarDiente() {
    var numDiente = document.getElementById("num").value;
}

function colocarTabOdontograma() {
    $('.nav-tabs a[href="#tabDefault4"]').tab('show');
}

function FiltrarTratamientoDiente(button) {
    var idDiente =button.value;
    var idPaciente = @Html.Raw(Json.Encode(Model.Item1.id));
    $.ajax({
        url:'@Url.Action("FiltrarTratamientosPorDiente", "Records")',
        type: 'GET',
        data: { idDiente: button.value, idPaciente_1: idPaciente },
        //dataType: "json",
        success: function (data) {

            $('#PartialViewTratamientosPaciente').html(data)
        },
        error: function (data) {
            alert("error!"+ data);  //
        }

    });
}

function FiltrarTratamientoPorFecha() {
    var startDate = $('#reportrange').data('daterangepicker').startDate.format('DD/MM/YYYY');
    var endDate = $('#reportrange').data('daterangepicker').endDate.format('DD/MM/YYYY');
    var idPaciente = @Html.Raw(Json.Encode(Model.Item1.id));
    $.ajax({
        url:'@Url.Action("FiltrarTratamientosPorFecha", "Records")',
        type: 'GET',
        data: { fechaInicio: startDate, fechaFin: endDate, idPaciente_1: idPaciente },
        //dataType: "json",
        success: function (data) {
            $('#PartialViewTratamientosPaciente').html(data)
        },
        error: function (data) {
            alert("error!"+ data);  //
        }

    });
}

function FiltrarTratamientoPorTratamiento() {
    var idTratamiento = $('#drpTratamientoFiltro').val();
    //var endDate = $('#reportrange').data('daterangepicker').endDate.format('DD/MM/YYYY');
    var idPaciente = @Html.Raw(Json.Encode(Model.Item1.id));
    $.ajax({
        url:'@Url.Action("FiltrarTratamientosPorTratamiento", "Records")',
        type: 'GET',
        data: { idTratamiento_1: idTratamiento, idPaciente_1: idPaciente },
        //dataType: "json",
        success: function (data) {
            $('#PartialViewTratamientosPaciente').html(data)
        },
        error: function (data) {
            alert("error!"+ data);  //
        }

    });
}

function FiltrarTratamientoPorCaraDiente() {
    var idCara = $('#drpCarasDiente').val();
    //var endDate = $('#reportrange').data('daterangepicker').endDate.format('DD/MM/YYYY');
    var idPaciente = @Html.Raw(Json.Encode(Model.Item1.id));
    $.ajax({
        url:'@Url.Action("FiltrarTratamientosPorCaraDiente", "Records")',
        type: 'GET',
        data: { idCaraDiente_1: idCara, idPaciente_1: idPaciente },
        //dataType: "json",
        success: function (data) {
            $('#PartialViewTratamientosPaciente').html(data)
        },
        error: function (data) {
            alert("error!"+ data);  //
        }

    });
}

function FiltrarTratamientoPorDiente() {
    var idDiente_1 = Number($('#drpNoDiente').val());
    //var endDate = $('#reportrange').data('daterangepicker').endDate.format('DD/MM/YYYY');
    var idPaciente = @Html.Raw(Json.Encode(Model.Item1.id));
    $.ajax({
        url:'@Url.Action("FiltrarTratamientosPorDiente", "Records")',
        type: 'GET',
        data: { idDiente: idDiente_1, idPaciente_1: idPaciente },
        //dataType: "json",
        success: function (data) {
            $('#PartialViewTratamientosPaciente').html(data)
        },
        error: function (data) {
            alert("error!"+ data);  //
        }

    });
}

function show_popup() {
    $("#popup").modal();
}
