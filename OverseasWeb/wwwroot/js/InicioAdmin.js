

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
                        '<td>' + res.nombresPersona + ' ' + res.apellidosPersona + '</td>' +
                        '<td>' + res.fechaNacimientoPersona.substr(8,2) + '</td>' +
                        '</tr>');
                });
                console.log(res);
            }
        }
    });
}













