
/* ELEMENTOS */


var dataInscripciones = $("#dataInscripciones");


/*SE USA EN REGISTRAR*/
var dataCursoInscripcion = $("#dataCursoInscripcion");
var dataEstudianteInscripcion = $("#dataEstudianteInscripcion");

var dataCursoSeleccionado = $("#dataCursoSeleccionado");
var dataEstudianteSeleccionado = $("#dataEstudianteSeleccionado");

var btnRegistro = $("#btnRegistroInscripcion");

var idCursoSelec = 0;
var idEstudianteSelec = 0;

/*SE CREA EL DT INICIAL*/
var tableCursoInscripcion = $("#dataTableCursoInscripcion").DataTable(dataTableConfig);
var tableEstudiante = $("#dataTableEstudianteInscripcion").DataTable(dataTableConfig);
var tableInscripciones = $("#tableInscripciones").DataTable(dataTableConfig);



if ($('#viewListarInscripciones').is(':visible')) {
    cambiarTitulo("Matriculas");
}


/*ACTIVAR/DESACTIVAR BOTON REGISTRO*/

function DesactivarBtnRegistro(activo) {
    btnRegistro.prop('disabled', activo);
}

/*LISTAR DATOS*/
if ($("#viewRegistroInscripcion").is(':visible')) {
    cambiarTitulo("Matriculas");
    DesactivarBtnRegistro(true);
}

function ListarCursosInscripcion() {
    let nombreDocente;
    $.ajax({
        type: "get",
        url: "/Inscripcion/ListarCursosHabiles",
        datatype: 'json',
        success: function (response) {
            console.log("CURSOS");
            console.log(response);
            dataCursoInscripcion.html("");
            if (response != "") {
                tableCursoInscripcion.clear().destroy();
                $.each(response, function (i, res) {
                    if (res.docente != null) { nombreDocente = '<td>' + res.docente.persona.nombresPersona + ' ' + res.docente.persona.apellidosPersona + '</td>' }
                    else { nombreDocente = '<td class="sinAsignar">-Sin asignar-</td>'; }
                    dataCursoInscripcion.append(
                        '<tr>' +
                        '<td>' + res.idCurso + '</td>' +
                        '<td>' + res.programa + '</td>' +
                        '<td>' + res.tipoCurso.nombreCurso + '</td>' +
                        '<td>' + res.nivel + ' - ' + res.ciclo + '</td>' +
                        '<td>' + res.fechaInicio.substr(0, 10) + ' - ' + res.fechaFin.substr(0, 10) + '</td>' +
                        nombreDocente +
                        '<td>' +
                        '<button onclick="agregarCursoInscripcion(' + res.idCurso + ')" class="btn btn-outline-info" data-dismiss="modal"><span class="fa fa-plus"></button>' +
                        '</td>' +
                        '</tr>');
                });
                tableCursoInscripcion = $("#dataTableCursoInscripcion").DataTable(dataTableConfig);
            } else {
                console.log(response);
            }
        }
    });
}

function ListarEstudiantesInscripcion() {
    $.ajax({
        type: "get",
        url: "/Inscripcion/ListarEstudiantesNoInscritos",
        datatype: 'json',
        data: { idCurso: idCursoSelec },
        success: function (response) {
            dataEstudianteInscripcion.html("");
            if (response != "") {
                tableEstudiante.clear().destroy();
                $.each(response, function (i, res) {
                    dataEstudianteInscripcion.append(
                        '<tr>' +
                        '<td>' + res.persona.dniPersona + '</td>' +
                        '<td>' + res.persona.apellidosPersona + '</td>' +
                        '<td>' + res.persona.nombresPersona + '</td>' +
                        '<td>' +
                        '<button onclick="agregarEstudianteInscripcion(' + res.idEstudiante + ')" class="btn btn-outline-info" data-dismiss="modal"><span class="fa fa-plus"></button>' +
                        '</td>' +
                        '</tr>');
                });
                tableEstudiante = $("#dataTableEstudianteInscripcion").DataTable(dataTableConfig);
            } else {
                console.log(response);
            }
        }
    });
}

function ListarInscripciones() {
    console.log("LISTAR INSCRIPCIONES");
    console.log("idCursoselec: " + idCursoSelec);
    $.ajax({
        type: "get",
        url: "/Inscripcion/ListarInscripcionesPorCurso",
        datatype: 'json',
        data: { idCurso: idCursoSelec },
        success: function (response) {
            console.log("ESTUDIANTES INSCRITOS");
            console.log(response);
            dataInscripciones.html("");
            if (response != "") {
                tableInscripciones.clear().destroy();
                $.each(response, function (i, res) {
                    dataInscripciones.append(
                        '<tr>' +
                        '<td>' + res.estudiante.persona.dniPersona + '</td>' +
                        '<td>' + res.estudiante.persona.apellidosPersona + '</td>' +
                        '<td>' + res.estudiante.persona.nombresPersona + '</td>' +
                        '<td>' + res.fechaInscripcion.substr(0, 10) + '</td>' +
                        '<td>' +
                        '<button onclick="AnularInscripcion(' + res.idInscripcion + ')" class="btn btn-outline-danger"><span class="fa fa-remove"></button>' +
                        '</td>' +
                        '</tr>');
                });
                tableInscripciones = $("#tableInscripciones").DataTable(dataTableConfig);
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
}


/**
 * AGREGAR CURSO
 */
function agregarCursoInscripcion(idCurso) {

    console.log("CURSO AGREGADO");
    let nombreDocente;
    $.ajax({
        type: "get",
        url: "/Inscripcion/BuscarCurso",
        datatype: 'json',
        data: { idCurso },
        success: function (response) {
            console.log(response);
            dataCursoSeleccionado.html("");
            if (response != "") {
                idCursoSelec = response.idCurso;
                console.log("CURSO seleccionado:: " +idCursoSelec);
                if (response.docente != null) { nombreDocente = '<td>' + response.docente.persona.nombresPersona + ' ' + response.docente.persona.apellidosPersona + '</td>' }
                else { nombreDocente = '<td class="sinAsignar">-Sin asignar-</td>'; }
                dataCursoSeleccionado.append(
                    '<tr>' +
                    '<td>' + response.programa + '</td>' +
                    '<td>' + response.tipoCurso.nombreCurso + '</td>' +
                    '<td>' + response.nivel + ' - ' + response.ciclo + '</td>' +
                    '<td>' + response.fechaInicio.substr(0, 10) + ' - ' + response.fechaFin.substr(0, 10) + '</td>' +
                     nombreDocente +
                    '</tr>'
                );
            } 

            if ($("#viewListarInscripciones").is(':visible')) {
                ListarInscripciones();
            }
            if ($("#viewCalificacionAdmin").is(':visible')) {
                console.log("LISTANDO");
                ListarEstudiantesDeUnCurso();
            }

        }
    });
}



/**
 * AGREGAR ESTUDIANTE
 */
function agregarEstudianteInscripcion(idEstudiante) {
    $.ajax({
        type: "get",
        url: "/Estudiante/BuscarEstudiante",
        datatype: 'json',
        data: { id: idEstudiante },
        success: function (response) {
            dataEstudianteSeleccionado.html("");
            console.log(response);
            if (response != "") {
                idEstudianteSelec = response.idEstudiante;
                dataEstudianteSeleccionado.append(
                    '<tr>' +
                    '<td>' + response.persona.dniPersona + '</td>' +
                    '<td>' + response.persona.apellidosPersona + '</td>' +
                    '<td>' + response.persona.nombresPersona + '</td>' +
                    '</tr>'
                );
                DesactivarBtnRegistro(false);
            } else {
                console.log(response);
            }
        }
    });
}


/* REGISTRO INSCRIPCION*/

function RegistrarInscripcion() {
    console.log("idCurso");
    console.log(idCursoSelec);
    console.log("idEstudiante");
    console.log(idEstudianteSelec);
    if (idCursoSelec != 0 && idEstudianteSelec != 0) {
        $.ajax({
            type: "post",
            url: "/Inscripcion/RegistrarInscripcion",
            datatype: 'json',
            data: { idCurso: idCursoSelec, idEstudiante: idEstudianteSelec },
            success: function (response) {
                console.log(response);
                if (response == "Exito") {
                    msgExito("matriculado");
                    LimpiarPagina();
                    ListarCursosInscripcion();
                } else {
                    console.log(response);
                }
            }
        });
    } else {
        msgError("Por favor seleccione un curso y un estudiante");
    }

    
}

/* ANULAR INSCRIPCION*/

function AnularInscripcion(idInscripcion) {
    $.ajax({
        type: "post",
        url: "/Inscripcion/AnularInscripcion",
        datatype: 'json',
        data: { id: idInscripcion },
        success: function (response) {
            console.log(response);
            if (response == "Exito") {
                msgExito("Matricula anulada");
                ListarInscripciones();
            } else {
                console.log(response);
            }
        }
    });
}


/*LIMPIAR PAGINA*/

function LimpiarPagina() {
    DesactivarBtnRegistro(true);
    dataCursoInscripcion.html("");
    dataEstudianteInscripcion.html("");
    dataCursoSeleccionado.html("");
    dataEstudianteSeleccionado.html("");
    idCursoSelec = 0;
    idEstudianteSelec = 0;
}



