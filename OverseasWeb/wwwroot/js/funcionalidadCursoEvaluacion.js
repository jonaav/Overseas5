

/*ELEMENTOS*/
var tablaTiposCurso = $("#tablaTiposCurso").DataTable(dataTableConfig);
var tablaTiposEvaluacion = $("#tablaTiposEvaluacion").DataTable(dataTableConfig);

var contenidoTablaTiposCurso = $("#contenidoTablaTiposCurso");
var contenidoTablaTiposEvaluacion = $("#contenidoTablaTiposEvaluacion");
var contenidoTablaTiposEvaluacionAgregar = $("#contenidoTablaTiposEvaluacionAgregar");
var contenidoTablaTiposEvaluacionNoAgregado = $("#contenidoTablaTiposEvaluacionNoAgregado");
var nombreEvaluacion = $("#txtNombreTipoEvaluacion");


var txtTipoCursoSelecc = $("#txtTipoCursoSelecc");

/* VARIABLES*/
var listaTEvaluaciones = [];
var idTipoCursoSelec;



if ($("#ViewCursoEvaluacion").is(':visible')) {
    cambiarTitulo("Evaluaciones");
    ListarTiposCurso();
    ListarTiposEvaluacion();
}



/*
 * LISTAR TIPOS DE CURSOS
 */


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
                    let btnAgregarEvaluacion = '<button onclick = "MostrarEvaluacionesCurso(' + res.idTipoCurso + ','+"'" + res.nombreCurso +"'"+ ')" class="btn btn-outline-info"><span class="fa fa-plus"></span></button>'; 
                    contenidoTablaTiposCurso.append('<tr>' +
                        '<td>' + res.nombreCurso + '</td>' +
                        '<td>' + btnAgregarEvaluacion + ' </td>' +
                        '</tr>');
                });
                tablaTiposCurso = $("#tablaTiposCurso").DataTable(dataTableConfig);
            }
        }
    });
}

/*
 * LISTAR TIPOS DE EVALUACION 
 */

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
                listaTEvaluaciones = response;
                console.log("LISTA TEVALUACIONES");
                console.log(listaTEvaluaciones);
                $.each(response, function (i, res) {
                    let btnEliminarEvaluacion = '<button onclick = "EliminarTipoEvaluacion(' + res.idTipoEvaluacion + ')" class="btn btn-outline-danger"><span class="fa fa-remove"></span></button>';
                    contenidoTablaTiposEvaluacion.append('<tr>' +
                        '<td>' + res.nombreEvaluacion + '</td>' +
                        '<td>' + btnEliminarEvaluacion + ' </td>' +
                        '</tr>');
                });
                tablaTiposEvaluacion = $("#tablaTiposEvaluacion").DataTable(dataTableConfig);
            } 
        }
    });
}


/*
 * MOSTRAR EVALUACIONES CURSOS
 */

function MostrarEvaluacionesCurso(idTipoCurso, nombreCurso) {
    console.log("CURSO: id- " + idTipoCurso)

    txtTipoCursoSelecc.html("");
    txtTipoCursoSelecc.append(nombreCurso);

    idTipoCursoSelec = idTipoCurso;
    ListarTiposEvaluacionNoSeleccionados();
    ListarTiposEvaluacionSeleccionados();
}



/*
 * LISTAR TIPOS DE EVALUACION AGREGADOS
 */

function ListarTiposEvaluacionSeleccionados() {
    $.ajax({
        type: "get",
        url: "/CursoEvaluacion/ListarTCursoTEvaluacion",
        datatype: 'json',
        data: { idCurso: idTipoCursoSelec },
        success: function (response) {
            console.log("seleccioados:");
            console.log(response);
            contenidoTablaTiposEvaluacionAgregar.html("");
            if (response != "") {
                $.each(response, function (i, res) {
                    let btnEliminartt = '<button onclick = "EliminarTCursoTEvaluacion(' + res.idTipoCursoTipoEvaluacion + ')" class="btn btn-outline-danger"><span class="fa fa-remove"></span></button>';
                    contenidoTablaTiposEvaluacionAgregar.append('<tr>' +
                        '<td>' + res.tipoEvaluacion.nombreEvaluacion + '</td>' +
                        '<td>' + btnEliminartt + ' </td>' +
                        '</tr>');
                });
            }
        }
    });
}


/*
 * LISTAR TIPOS DE EVALUACION NO AGREGADOS
 */

function ListarTiposEvaluacionNoSeleccionados() {
    $.ajax({
        type: "get",
        url: "/CursoEvaluacion/ListarTEvaluacionFaltantes",
        datatype: 'json',
        data: { idCurso: idTipoCursoSelec},
        success: function (response) {
            console.log("NO seleccioados:  ");
            console.log(response);
            contenidoTablaTiposEvaluacionNoAgregado.html("");
            if (response != "") {
                $.each(response, function (i, res) {
                    let btnAgregartt = '<button onclick = "AgregarTCursoTEvaluacion(' + res.idTipoEvaluacion + ')" class="btn btn-outline-info"><span class="fa fa-plus"></span></button>';
                    contenidoTablaTiposEvaluacionNoAgregado.append('<tr>' +
                        '<td>' + res.nombreEvaluacion + '</td>' +
                        '<td>' + btnAgregartt + ' </td>' +
                        '</tr>');
                });
            }
        }
    });
}



/*
 * REGISTRAR TIPO EVALUACION
 */

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





/*
 * ELIMINAR TIPO EVALUACION
 */

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



/*
 * REGISTRAR TIPO CURSO TIPO EVALUACION
 */

function AgregarTCursoTEvaluacion(idTEvaluacion) {
    let tt = {
        idTipoEvaluacion: idTEvaluacion,
        idTipoCurso: idTipoCursoSelec
    };
    console.log(tt);
    $.ajax({
        type: "post",
        url: "/CursoEvaluacion/RegistrarTCursoTEvaluacion",
        datatype: 'json',
        data: { tt },
        success: function (response) {
            console.log(response);
            if (response == "Registrado") {
                MostrarEvaluacionesCurso(idTipoCursoSelec);
                msgExito(response);
            } else {
                msgError(response);
            }
        }
    });
}





/*
 * ELIMINAR TIPO CURSO TIPO EVALUACION
 */

function EliminarTCursoTEvaluacion(idtt) {
    $.ajax({
        type: "post",
        url: "/CursoEvaluacion/EliminarTCursoTEvaluacion",
        datatype: 'json',
        data: { idtt: idtt },
        success: function (response) {
            console.log(response);
            if (response == "Eliminado") {
                MostrarEvaluacionesCurso(idTipoCursoSelec);
                msgExito(response);
            } else {
                msgError(response);
            }
            ListarTiposEvaluacion();
        }
    });
}












