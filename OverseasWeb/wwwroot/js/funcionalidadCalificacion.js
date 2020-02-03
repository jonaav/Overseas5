

/*
 *  ELEMENTOS
 */

let tableCalificacionesAdmin = $("#tableCalificacionesAdmin").DataTable(dataTableConfig);
let dataCalificacionesAdmin = $("#dataCalificacionesAdmin");



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
                        '<button onclick="VerNotasDelEstudiante(' + res.idInscripcion + ')" class="btn btn-outline-info"><span class="fa fa-clipboard "></button>' +
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






