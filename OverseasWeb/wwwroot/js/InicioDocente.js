


/*
 * ELEMENTOS
 */

let dataHorarioDocente = $("#dataHorarioDocente");



if ($("#viewInicioDocente").is(":visible")) {
    console.log("VIEW DOCENTE");
    MostrarHorariosDocente();
}


function MostrarHorariosDocente() {
    console.log("ENTROOOO");
    $.ajax({
        type: "get",
        url: "/Home/BuscarHorariosDelDiaDocente",
        datatype: 'json',
        success: function (response) {
            if (response != "") {
                dataHorarioDocente.html("");
                $.each(response, function (i, res) {
                    let aula = '-Sin Asignar-';
                    console.log(res);
                    if (res.horario.ambiente != null) {
                        aula = res.horario.ambiente.aula;
                    }
                    dataHorarioDocente.append(
                        '<tr>' +
                        '<td>' + res.horario.curso.tipoCurso.nombreCurso + ' - ' + res.horario.curso.programa + '</td>' +
                        '<td>' + res.horario.curso.nivel + ' - ' + res.horario.curso.ciclo + '</td>' +
                        '<td>' + res.horario.horaInicio + ' - ' + res.horario.horaFin + '</td>' +
                        '<td>' + aula + '</td>' +
                        '</tr>'
                    );
                });
            }
        }
    });
}







