



/*
 * 
 * ELEMENTOS
 */


let dataAsistenciasDocente = $("#dataAsistenciasDocente");

let asistieron = [];








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
            if (response != "") {
                $.each(response, function (i, res) {
                    dataAsistenciasDocente.append(
                        '<tr>' +
                        '<td>' + res.estudiante.persona.apellidosPersona + '</td>' +
                        '<td>' + res.estudiante.persona.nombresPersona + '</td>' +
                        '<td>' +
                        '<button onclick="AddAsistencia(' + res.idAsistencia + ')" id="btnAsist' + res.idAsistencia + '" class="btn" >A</button>' +
                        '<button onclick="DeleteAsistencia(' + res.idAsistencia + ')" id="btnFalta' + res.idAsistencia + '" class="btn">F</button>' +
                        '</td>' +
                        '</tr>');
                    if (res.asistenciaEstudiante == 1) {
                        pintarAsist(res.idAsistencia);
                    } else {
                        pintarFalta(res.idAsistencia);
                    }
                });
            }
        }
    });
}



/*
 * AGREGAR ASISTENCIAS AL ARRAY ASISTIERON
 */
function AddAsistencia(idAsistencia) {
    if (!asistieron.includes(idAsistencia)) {
        asistieron.push(idAsistencia);
        pintarAsist(idAsistencia);

    }
    console.log("ELEMENTO AGREGADO" + idAsistencia);
    console.log(asistieron);
}



/*
 * ELIMINAR ASISTENCIAS DEL ARRAY ASISTIERON
 */
function DeleteAsistencia(idAsistencia) {
    let i = 0;
    asistieron.forEach(element => {
        if (element == idAsistencia) asistieron.splice(i, 1);
        i++;
        pintarFalta(idAsistencia);
    })
    console.log("ELEMENTO ELIMINADO" + idAsistencia);
    console.log(asistieron);
        
}




/*
 * GUARDAR ASISTENCIAS
 */
function GuardarAsistencias() {
    $.ajax({
        type: "post",
        url: "/Asistencia/EditarAsistencias",
        datatype: 'json',
        data: { asistieron: asistieron},
        success: function (response) {
            msgExito(response);
        }
    });
        
}






/*
 * PINTAR ASISTENCIA 
 */
function pintarAsist(idAsistencia) {

    let btnA = "#btnAsist" + idAsistencia;
    let btnF = "#btnFalta" + idAsistencia;
    $(btnA).addClass("btn-success");
    $(btnA).removeClass("btn-outline-success");
    $(btnF).removeClass("btn-danger");
    $(btnF).addClass("btn-outline-danger");
}




/*
 * PINTAR FALTA 
 */
function pintarFalta(idAsistencia) {

    let btnA = "#btnAsist" + idAsistencia;
    let btnF = "#btnFalta" + idAsistencia;
    $(btnA).removeClass("btn-success");
    $(btnA).addClass("btn-outline-success");
    $(btnF).addClass("btn-danger");
    $(btnF).removeClass("btn-outline-danger");
}


