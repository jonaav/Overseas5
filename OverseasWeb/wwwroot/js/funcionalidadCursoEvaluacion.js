

/*ELEMENTOS*/
var tablaTiposCurso = $("#tablaTiposCurso").DataTable(dataTableConfig);
var tablaTiposEvaluacion = $("#tablaTiposEvaluacion").DataTable(dataTableConfig);

var contenidoTablaTiposCurso = $("#contenidoTablaTiposCurso");
var contenidoTablaTiposEvaluacion = $("#contenidoTablaTiposEvaluacion");
var nombreEvaluacion = $("#txtNombreTipoEvaluacion");

if ($("#ViewCursoEvaluacion").is(':visible')) {
    cambiarTitulo("Evaluaciones");
    ListarTiposCurso();
    ListarTiposEvaluacion();
}



function ListarTiposCurso() {

    $.ajax({
        type: "get",
        url: "/CursoEvaluacion/ListarTiposCurso",
        datatype: 'json',
        success: function (response) {
            console.log(response);
            contenidoTablaTiposCurso.html("");
            tablaTiposCurso.clear().destroy();
            if (response != "") {
                $.each(response, function (i, res) {
                    let btnAgregarEvaluacion = '<button onclick = "BuscarEvaluacion()" class="btn btn-outline-info"><span class="fa fa-plus"></span></button>'; 
                    contenidoTablaTiposCurso.append('<tr>' +
                        '<td>' + res.nombreCurso + '</td>' +
                        '<td>' + btnAgregarEvaluacion + ' </td>' +
                        '</tr>');
                });
                tablaTiposCurso = $("#tablaTiposCurso").DataTable(dataTableConfig);
            } else {
                msgError("No se encontraron datos");
            }
        }
    });
}


function ListarTiposEvaluacion() {
    $.ajax({
        type: "get",
        url: "/CursoEvaluacion/ListarTiposEvaluacion",
        datatype: 'json',
        success: function (response) {
            console.log(response);
            contenidoTablaTiposEvaluacion.html("");
            tablaTiposEvaluacion.clear().destroy();
            if (response != "") {
                $.each(response, function (i, res) {
                    let btnEliminarEvaluacion = '<button onclick = "EliminarEvaluacion(' + res.idTipoEvaluacion + ')" class="btn btn-outline-danger"><span class="fa fa-remove"></span></button>';
                    contenidoTablaTiposEvaluacion.append('<tr>' +
                        '<td>' + res.nombreEvaluacion + '</td>' +
                        '<td>' + btnEliminarEvaluacion + ' </td>' +
                        '</tr>');
                });
                tablaTiposEvaluacion = $("#tablaTiposEvaluacion").DataTable(dataTableConfig);
            } else {
                msgError("No se encontraron datos");
            }
        }
    });
}

function RegistrarTipoEvaluacion() {
    let TipoEvaluacion = {NombreEvaluacion: nombreEvaluacion.val()}
    $.ajax({
        type: "post",
        url: "/CursoEvaluacion/RegistrarTipoEvaluacion",
        datatype: 'json',
        data: { tEvaluacion : TipoEvaluacion },
        success: function (response) {
            console.log(response);
            if (response == "Registrado") {
                ListarTiposEvaluacion();
                msgExito(response);
            }
        }
    });
}



function EliminarTipoEvaluacion(idTipoEvaluacion) {
    $.ajax({
        type: "post",
        url: "/CursoEvaluacion/EliminarTipoEvaluacion",
        datatype: 'json',
        data: { idTipoEvaluacion: idTipoEvaluacion },
        success: function (response) {
            console.log(response);
            if (response == "Eliminado") {
                msgExito(response);
            } else {
                msgError(response);
            }
            ListarTiposEvaluacion();
        }
    });
}












