

/* ELEMENTOS */

var estudiantesActivos = $("#estudiantesActivos");
var docentesActivos = $("#docentesActivos");
var cursosActivos = $("#cursosActivos");
var traduccionesPendientes = $("#traduccionesPendientes");

// TABLAS

var dataCumpleaños = $("#dataCumpleaños");
var dataClasesDiarias = $("#dataClasesDiarias");



if ($("#viewInicioAdmin").is(":visible")) {
    console.log("INICIO");
    ContarEstudiantesActivos();
    ContarDocentesActivos();
    ContarCursosActivos();
    ContarTraduccionesPendientes();
    BuscarCumpleañosCercanos();
    BuscarHorariosDelDia();
}


/* DATOS GENERALES - CARDS */


function ContarEstudiantesActivos() {
    $.ajax({
        type: "get",
        url: "/Home/ContarEstudiantesActivos",
        datatype: 'json',
        success: function (res) {
            estudiantesActivos.append(res);
            console.log(res);
        }
    });
}



function ContarDocentesActivos() {
    $.ajax({
        type: "get",
        url: "/Home/ContarDocentesActivos",
        datatype: 'json',
        success: function (res) {
            docentesActivos.append(res);
            console.log(res);
        }
    });
}



function ContarCursosActivos() {
    $.ajax({
        type: "get",
        url: "/Home/ContarCursosActivos",
        datatype: 'json',
        success: function (res) {
            cursosActivos.append(res);
            console.log(res);
        }
    });
}



function ContarTraduccionesPendientes() {
    $.ajax({
        type: "get",
        url: "/Home/ContarTraduccionesPendientes",
        datatype: 'json',
        success: function (res) {
            traduccionesPendientes.append(res);
            console.log(res);
        }
    });
}



/* TABLA DE CUMPLEAÑOS DEL MES */

function BuscarCumpleañosCercanos() {
    $.ajax({
        type: "get",
        url: "/Home/BuscarCumpleañosCercanos",
        datatype: 'json',
        success: function (res) {
            if (res != "") {
                $.each(res, function (i, res) {
                    dataCumpleaños.append(
                        '<tr>' +
                        '<td>' + res.persona.nombresPersona + ' ' + res.persona.apellidosPersona + '</td>' +
                        '<td>' + res.persona.fechaNacimientoPersona.substr(8, 2) + '</td>' +
                        '</tr>');
                });
                console.log(res);
            }
        }
    });
}




/* TABLA HORARIOS DEL DIA */

function BuscarHorariosDelDia() {
    $.ajax({
        type: "get",
        url: "/Home/BuscarHorariosDelDia",
        datatype: 'json',
        success: function (response) {
            console.log('HORARIOS');
            console.log(response);
            if (response != "") {
                $.each(response, function (i, res) {
                    let nombreDocente = '-Sin Asignar-';
                    let aula = '-Sin Asignar-';
                    console.log(res);
                    if (res.horario.curso.docente != null) {
                        nombreDocente = res.horario.curso.docente.persona.nombresPersona + ' ' + res.horario.curso.docente.persona.apellidosPersona;
                    } 
                    if (res.horario.ambiente != null) {
                        aula = res.horario.ambiente.aula;
                    }
                    dataClasesDiarias.append(
                        '<tr>' +
                        '<td>' + res.horario.curso.tipoCurso.nombreCurso + ' - ' + res.horario.curso.programa + '</td>' +
                        '<td>' + res.horario.curso.nivel + ' - ' + res.horario.curso.ciclo + '</td>' +
                        '<td>' + nombreDocente + '</td>' +
                        '<td>' + res.horario.horaInicio + ' - ' + res.horario.horaFin + '</td>' +
                        '<td>' + aula + '</td>' +
                        '</tr>');
                });
            }
        }
    });
}













