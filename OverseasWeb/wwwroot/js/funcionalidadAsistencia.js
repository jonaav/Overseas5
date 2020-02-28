



/*
 * 
 * ELEMENTOS
 */


let dataAsistenciasDocente = $("#dataAsistenciasDocente");










/*
 *  LISTAR ASISTENCIAS POR SESION - DOCENTE - la funcion es llamada desde agregarCursoDocenteSelec(idCurso)
 */

function ListarAsistenciasPorSesion(idCurso) {
    idCursoSelecCalif = idCurso;
    $.ajax({
        type: "get",
        url: "/Asistencia/ListarAsistenciasPorSesion",
        datatype: 'json',
        data: { idCurso: idCurso },
        success: function (response) {
            console.log(response);
            dataAsistenciasDocente.html("");
            //tableCalificacionesDocente.clear().destroy();
            if (response != "") {
                $.each(response, function (i, res) {
                    dataAsistenciasDocente.append(
                        '<tr>' +
                        '<td>' + res.estudiante.persona.apellidosPersona + '</td>' +
                        '<td>' + res.estudiante.persona.nombresPersona + '</td>' +
                        '<td>' +
                        //'<button onclick="MarcarAsistencia(' + res.idEstudiante + ')" class="btn btn-outline-info"><span class="fa fa-clipboard "></button>' +
                        //'<button onclick="MarcarFalta(' + res.idEstudiante + ')" class="btn btn-outline-info"><span class="fa fa-clipboard "></button>' +
                        //'<div class="form-check">'+
                        //'<input class= "form-check-input" type = "radio" name = "radioFalta" id = "radioFalta" value = "option1" checked />' +
                        //'<label class="form-check-label" for="radioFalta">Falta</label></div >' +
                        //'<div class="form-check">' +
                        //'<input class= "form-check-input" type = "radio" name = "radioAsistencia" id = "radioAsistencia" value = "option2" checked />' +
                        //'<label class="form-check-label" for="radioAsistencia">Asistencia</label></div >' +
                        '</td>' +
                        '</tr>');
                });
                //tableCalificacionesDocente = $("#tableCalificacionesDocente").DataTable(dataTableConfig);
            }
        }
    });
}







