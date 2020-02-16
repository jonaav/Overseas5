

/*
 *  ELEMENTOS
 */

let tableCalificacionesAdmin = $("#tableCalificacionesAdmin").DataTable(dataTableConfig);
let dataCalificacionesAdmin = $("#dataCalificacionesAdmin");

let dataNotasAdmin = $("#dataNotasAdmin");
let txtNotasEstudiante = $("#txtNotasEstudiante");



/*
 *  LISTAR ESTUDIANTES - la funcion es llamada desde agregarCursoInscripcion()
 */

function ListarEstudiantesDeUnCurso() {
    $.ajax({
        type: "get",
        url: "/Inscripcion/ListarInscripcionesPorCurso",
        datatype: 'json',
        data: { idCurso: idCursoSelec },
        success: function (response) {
            dataCalificacionesAdmin.html("");
            if (response != "") {
                console.log(response);
                tableCalificacionesAdmin.clear().destroy();
                $.each(response, function (i, res) {
                    dataCalificacionesAdmin.append(
                        '<tr>' +
                        '<td>' + res.estudiante.persona.apellidosPersona + '</td>' +
                        '<td>' + res.estudiante.persona.nombresPersona + '</td>' +
                        '<td>' +
                        '<button onclick="VerNotasDelEstudiante(' + res.idEstudiante + ')" class="btn btn-outline-info"><span class="fa fa-clipboard "></button>' +
                        '</td>' +
                        '</tr>');
                });
                tableCalificacionesAdmin = $("#tableCalificacionesAdmin").DataTable(dataTableConfig);
            } else {
                console.log(response);
            }
        }
    });
}



/*
 *  LISTAR NOTAS DE UN ESTUDIANTE EN UN CURSO
 */

function VerNotasDelEstudiante(idEstudiante) {
    console.log("ESTUDIANTE----");
    console.log(idEstudiante);
    $.ajax({
        type: "get",
        url: "/Calificacion/VerNotasDelEstudiantePorCurso",
        datatype: 'json',
        data: { idCurso: idCursoSelec, idEstudiante: idEstudiante },
        success: function (response) {
            console.log("NOTAS");
            console.log(response);
            txtNotasEstudiante.html("");
            dataNotasAdmin.html("");
            if (response != "") {
                console.log(response);
                //txtNotasEstudiante.append(response.historialEvaluacion.estudiante.persona.nombresPersona +
                //    ' ' + response.historialEvaluacion.estudiante.persona.apellidosPersona);
                $.each(response, function (i, res) {

                    dataNotasAdmin.append(
                        '<tr>' +
                        '<td>'+ res.tipoEvaluacion.nombreEvaluacion +'</td>'+
                        '<td>'+ res.calificacionEvaluacion +'</td>'+
                        '</tr>');
                });
            }
        }
    });
}



