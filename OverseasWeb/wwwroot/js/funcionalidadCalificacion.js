

/*
 *  ELEMENTOS
 */

let tableCalificacionesAdmin = $("#tableCalificacionesAdmin").DataTable(dataTableConfig);
let dataCalificacionesAdmin = $("#dataCalificacionesAdmin");
let tableCalificacionesDocente = $("#tableCalificacionesDocente").DataTable(dataTableConfig);
let dataCalificacionesDocente = $("#dataCalificacionesDocente");
let dataTableCursosDocente = $("#dataTableCursosDocente").DataTable(dataTableConfig);
let dataCursosDocente = $("#dataCursosDocente");


let dataCursoDocenteSeleccionado = $("#dataCursoDocenteSeleccionado");


let dataNotasAdmin = $("#dataNotasAdmin");
let dataNotasDocente = $("#dataNotasDocente");
let txtNotasEstudiante = $("#txtNotasEstudiante");
let txtNotasDocenteEstudiante = $("#txtNotasDocenteEstudiante");

let idCursoSelecCalif;
let idEstudianteSelecCalif;

//EDITAR

let txtNombreExamen = $("#txtNombreExamen");
let txtCalificacion = $("#txtCalificacion");
let idEvaluacionSelecc;



/*
 *  LISTAR ESTUDIANTES - ADMIN - la funcion es llamada desde agregarCursoInscripcion()
 */

function ListarEstudiantesDeUnCurso() {
    $.ajax({
        type: "get",
        url: "/Inscripcion/ListarInscripcionesPorCurso",
        datatype: 'json',
        data: { idCurso: idCursoSelec }, //variable en inscripcion
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





/*
 *  LISTAR CURSOS DEL DOCENTE
 */

function ListarCursosDelDocente() {
    $.ajax({
        type: "get",
        url: "/Calificacion/ListarCursosHabilesDelDocente",
        datatype: 'json',
        success: function (response) {
            console.log("CURSOS");
            console.log(response);
            dataCursosDocente.html("");
            if (response != "") {
                dataTableCursosDocente.clear().destroy();
                $.each(response, function (i, res) {
                    dataCursosDocente.append(
                        '<tr>' +
                        '<td>' + res.idCurso + '</td>' +
                        '<td>' + res.programa + '</td>' +
                        '<td>' + res.tipoCurso.nombreCurso + '</td>' +
                        '<td>' + res.nivel + ' - ' + res.ciclo + '</td>' +
                        '<td>' + res.fechaInicio.substr(0, 10) + ' - ' + res.fechaFin.substr(0, 10) + '</td>' +
                        '<td>' +
                        '<button onclick="agregarCursoDocenteSelec(' + res.idCurso + ')" class="btn btn-outline-info" data-dismiss="modal"><span class="fa fa-plus"></button>' +
                        '</td>' +
                        '</tr>');
                });
                dataTableCursosDocente = $("#dataTableCursosDocente").DataTable(dataTableConfig);
            } else {
                console.log(response);
            }
        }
    });
}




/*
 *  SELECCIONAR CURSO DOCENTE
 */

function agregarCursoDocenteSelec(idCurso) {
    $.ajax({
        type: "get",
        url: "/Curso/BuscarCursoPorID",
        datatype: 'json',
        data: { idCurso: idCurso },
        success: function (response) {
            console.log("CURSO");
            console.log(response);
            dataCursoDocenteSeleccionado.html("");
            if (response != "") {
                dataCursoDocenteSeleccionado.append(
                    '<tr>' +
                    '<td>' + response.programa + '</td>' +
                    '<td>' + response.tipoCurso.nombreCurso + '</td>' +
                    '<td>' + response.nivel + ' - ' + response.ciclo + '</td>' +
                    '<td>' + response.fechaInicio.substr(0, 10) + ' - ' + response.fechaFin.substr(0, 10) + '</td>' +
                    '</tr>');
            } 
        }
    });
    ListarEstudiantesDeUnCursoDocente(idCurso); 
    ListarAsistenciasPorSesion(idCurso); 
}


/*
 *  LISTAR ESTUDIANTES - DOCENTE - la funcion es llamada desde agregarCursoDocenteSelec(idCurso)
 */

function ListarEstudiantesDeUnCursoDocente(idCurso) {
    idCursoSelecCalif = idCurso;
    $.ajax({
        type: "get",
        url: "/Inscripcion/ListarInscripcionesPorCurso",
        datatype: 'json',
        data: { idCurso: idCurso },
        success: function (response) {
            console.log(response);
            dataCalificacionesDocente.html("");
            tableCalificacionesDocente.clear().destroy();
            if (response != "") {
                $.each(response, function (i, res) {
                    dataCalificacionesDocente.append(
                        '<tr>' +
                        '<td>' + res.estudiante.persona.apellidosPersona + '</td>' +
                        '<td>' + res.estudiante.persona.nombresPersona + '</td>' +
                        '<td>' +
                        '<button onclick="VerNotasDelEstudianteDocente(' + res.idEstudiante +')" class="btn btn-outline-info"><span class="fa fa-clipboard "></button>' +
                        '</td>' +
                        '</tr>');
                });
                tableCalificacionesDocente = $("#tableCalificacionesDocente").DataTable(dataTableConfig);
            } 
        }
    });
}


/*
 *  LISTAR NOTAS DE UN ESTUDIANTE EN UN CURSO
 */

function VerNotasDelEstudianteDocente(idEstudiante) {
    idEstudianteSelecCalif = idEstudiante;
    $.ajax({
        type: "get",
        url: "/Calificacion/VerNotasDelEstudiantePorCurso",
        datatype: 'json',
        data: { idCurso: idCursoSelecCalif, idEstudiante: idEstudianteSelecCalif },
        success: function (response) {
            console.log("NOTAS");
            console.log(response);
            txtNotasDocenteEstudiante.html("");
            dataNotasDocente.html("");
            if (response != "") {
                console.log(response);
                $.each(response, function (i, res) {
                    dataNotasDocente.append(
                        '<tr>' +
                        '<td>' + res.tipoEvaluacion.nombreEvaluacion + '</td>' +
                        '<td>' + res.calificacionEvaluacion + '</td>' +
                        '<td>' +
                        '<button onclick="cargarModalCalificacion(' + res.idEvaluacion + ')" class="btn btn-outline-warning" data-toggle="modal" data-target="#formEditarCalificacionModal" rel="tooltip" title="Editar"><span class="fa fa-pencil "></button>' +
                        '</td>' +
                        '</tr>');
                });
            }
        }
    });
}







/*
 *  CARGAR MODAL CALIFICACION
 */

function cargarModalCalificacion(idEvaluacion) {
    idEvaluacionSelecc = idEvaluacion;
    $.ajax({
        type: "get",
        url: "/Calificacion/BuscarEvaluacion",
        datatype: 'json',
        data: { idEvaluacion: idEvaluacion },
        success: function (response) {
            console.log("NOTAS");
            console.log(response);
            if (response != "") {
                txtNombreExamen.html("");
                txtNombreExamen.append(response.tipoEvaluacion.nombreEvaluacion);
                txtCalificacion.val(response.calificacionEvaluacion);
            }
        }
    });
}






/*
 *  GUARDAR CALIFICACION
 */

function GuardarCalificacion() {
    $.ajax({
        type: "post",
        url: "/Calificacion/EditarEvaluacion",
        datatype: 'json',
        data: { idEvaluacion: idEvaluacionSelecc, nota: txtCalificacion.val() },
        success: function (response) {
            if (response == "Calificacion Actualizada") {
                VerNotasDelEstudianteDocente(idEstudianteSelecCalif);
                msgExito(response);
            }
        }
    });
}















