let cont = 0;
//let filaHorario = 0;
/**
 * Datos Utilizar
 */
let idCursoHorario;
let idHorarioSel = 0;
let fechaInicioCursoHorario;
let fechaFinCursoHorario;
let idAmbienteSelecHorario = 0;
let programaCursoHorario;
//let horarioPermitido = '';
//let estadoHorario = 1;


/**
* Elementos Horario
* REGULAR
*/
let dias = ["Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"];
let cabeceraTablaHorarios = $('#cabeceraTablaHorarios');
let contenidoTablaHorarios = $('#contenidoTablaHorarios');
let containerFormHorario = $('#containerFormHorario');
let btnGuardarHorario = $("#btnGuardarHorario");
let btnAgregarHorario = $('#btnAgregarHorario');
let selectorDia = $('#selectorHorarioDia');
let txtHoraInicio = $('#txtHoraInicio');
let txtHoraFin = $('#txtHoraFin');
let txtAmbienteHorario = $('#txtHorarioNombreAmbiente');
let tituloCursoHorario = $('#tituloCursoHorario');
let txtDecisionHorario = $('#txtDecisionHorario');

/**
 * Privado
 */

let txtNumeroSesion = $('#txtNumeroSesion');
let txtFechaSesion = $('#txtFechaSesion');
let divDatosHorarioPrivado = $('#divDatosHorarioPrivado');
let divDiaHorario = $('#divDiaHorario');



function DeshabilitarEdicionHorarios(decision) {
    btnGuardarHorario.prop('disabled', decision);
    btnAgregarHorario.prop('disabled', decision);
}

function MostrarFormHorario() {
    containerListaCursos.hide();
    containerFormHorario.show();
    LimpiarFormHorario();
}


/*
 * Boton ver horarios 
 */ 
function CargarFormHorario(idCurso, estadoCursoHorario, programa, fechaInicio, fechaFin, tituloCurso) {
    idCursoHorario = idCurso;
    programaCursoHorario = programa;
    fechaInicioCursoHorario = fechaInicio;
    fechaFinCursoHorario = fechaFin;
    MostrarFormHorario();
    AddTituloCursoAlFormHorario(tituloCurso);
    if (programa == "Privado") {
        divDatosHorarioPrivado.show();
        divDiaHorario.hide();
    } else {
        divDiaHorario.show();
        divDatosHorarioPrivado.hide();
    }
    AgregarCabeceraTablaHorario();
    BuscarHorariosCurso();
}



function AgregarCabeceraTablaHorario() {
    let columnasHorario = "";
    cabeceraTablaHorarios.html("");
    (programaCursoHorario == "Privado") ? columnasHorario = ' <th> N° Sesión </th> <th> Fecha Sesión </th>' : columnasHorario = '<th> Dia </th>';
    cabeceraTablaHorarios.append('<tr> <th hidden></th>' + columnasHorario + '<th>Hora Inicio</th>' + '<th>Hora Fin</th>' + '<th>Ambiente</th>' + '<th hidden></th>' + '<th></th>' + '</tr>');
}

/*
 *  LISTAR HORARIOS
 */
function BuscarHorariosCurso() {
    contenidoTablaHorarios.html("");
    $.ajax({
        type: 'GET',
        url: "/Horario/BuscarHorariosCurso",
        dataType: "json",
        data: {
            idCurso: idCursoHorario
        },
        success: function (res) {
            console.log("horarios: ");
            console.log(res);
            if (res != "") {
                $.each(res, function (i, res) {
                    contenidoTablaHorarios.append(
                        '<tr>' +
                        '<td>' + res.dia + '</td>' +
                        '<td>' + res.horaInicio + '</td>' +
                        '<td>' + res.horaFin + '</td>' +
                        '<td>' + res.ambiente.descripcionAmbiente + ' ' + res.ambiente.aula + '</td>' +
                        '<td> <button onclick="BuscarHorario(' + res.idHorario + ')" rel="tooltip" title="Seleccionar"' +
                        '      type="" class="btn btn-warning btn-link btn-sm"><span class="fa fa-edit" style="color:black"></button>' +
                        '     <button onclick="EliminarHorario(' + res.idHorario + ')" rel="tooltip" title="Eliminar"' +
                        '      class="btn btn-danger btn-link btn-sm"><span class="fa fa-trash" style="color:black"></button></td>' +
                        '</tr>');
                });
            }
        }
    });
}

/*
 * Boton cancelar
 */
function SalirFormHorario() {
    LimpiarFormHorario();
    ListarCursos();
}


function LimpiarFormHorario() {
    //$('#txtNumeroSesion').val($('#txtNumeroActualSesion').val());
    //txtFechaSesion.val("");
    selectorDia.val(0);
    txtHoraInicio.val("");
    txtHoraFin.val("");
    idAmbienteSelecHorario = 0;
    txtAmbienteHorario.val("");
    idHorarioSel = 0;
}

function MostrarAmbientesParaHorario() {
    var table = $('#tablaAmbienteModal').DataTable();
    $.ajax({
        type: 'GET',
        url: "/Ambiente/Listar",
        dataType: 'json',
        success: function (data) {
            $("#contenidoTablaAmbiente").html("");
            table.clear().destroy();
            if (data != "") {
                obj = data;
                $.each(obj, function (i, obj) {
                    $('#contenidoTablaAmbiente').append('<tr>' +
                        '<td>' + obj.idAmbiente + '</td>' +
                        '<td>' + obj.descripcionAmbiente + '</td>' +
                        '<td>' + obj.aula + '</td>' +
                        '<td> <button type="button" onclick="AsignarAmbienteAlFormHorario(' + obj.idAmbiente + ',' + "'" + obj.descripcionAmbiente +
                        " " + obj.aula + "'" + ')" class="btn btn-outline-info btn-sm">Asignar</button></td>' +
                        '</tr>');
                });
                table = CrearDatatable("tablaAmbienteModal");
            }
        }
    });
}

function CargarModalAmbienteParaHorario() {
    $('#modalBuscarAmbiente').modal("show");
    MostrarAmbientesParaHorario();
}

function AsignarAmbienteAlFormHorario(idAmbiente, descripcion) {
    $('#modalBuscarAmbiente').modal("hide");
    idAmbienteSelecHorario = idAmbiente;
    txtAmbienteHorario.val(descripcion);
}

/*
 *  CREAR HORARIO 
 * */

function CrearHorario() {
    console.log("IDCURSO: " + idCursoHorario + "- IDAMBIENTE: " + idAmbienteSelecHorario);
    $.ajax({
        type: 'POST',
        url: "/Horario/CrearHorario",
        data: {
            dia: selectorDia.val(),
            horaInicio: txtHoraInicio.val(),
            horaFin: txtHoraFin.val(),
            idCurso: idCursoHorario,
            idAmbiente: idAmbienteSelecHorario,
        },
        datatype: 'json',
        success: function (res) {
            switch (res) {
                case 'Registrado': {
                    msgExitoCurso(res);
                    break;
                }
                default: {
                    msgError(res);
                }
            }
        }
    });
}

/*
 *  BUSCAR HORARIO
 * */


function BuscarHorario(idHorario) {
    $.ajax({
        type: 'POST',
        url: "/Horario/BuscarHorario",
        data: {
            idHorario: idHorario,
        },
        datatype: 'json',
        success: function (res) {
            console.log("RESS: ");
            console.log(res);
            selectorDia.val(res.dia);
            txtHoraInicio.val(res.horaInicio);
            txtHoraFin.val(res.horaFin);
            idCursoHorario = res.idCurso;
            idHorarioSel = idHorario;
            idAmbienteSelecHorario = res.ambiente.idAmbiente;
            txtAmbienteHorario.val(res.ambiente.descripcionAmbiente+ ' ' + res.ambiente.aula);
        }
    });
}

/*
 *  EDITAR HORARIO
 * */

function EditarHorario(idHorario) {
    $.ajax({
        type: 'POST',
        url: "/Horario/EditarHorario",
        data: {
            idHorario: idHorario,
            dia: selectorDia.val(),
            horaInicio: txtHoraInicio.val(),
            horaFin: txtHoraFin.val(),
            idCurso: idCursoHorario,
            idAmbiente: idAmbienteSelecHorario,
            estadoHorario: 1
        },
        datatype: 'json',
        success: function (res) {
            switch (res) {
                case 'Datos actualizados': {
                    msgExitoCurso(res);
                    break;
                }
                default: {
                    msgError(res);
                }
            }
        }
    });
}


/*
 *  GUARDAR
 */

function GuardarHorario() {
    if (idHorarioSel == 0) {
        CrearHorario();
    } else {
        EditarHorario(idHorarioSel);
    }
    LimpiarFormHorario();
}

/*
 *  ELIMINAR HORARIO
 * */


function EliminarHorario(idHorario) {
    $.ajax({
        type: 'POST',
        url: "/Horario/AnularHorario",
        data: {
            idHorario: idHorario,
        },
        datatype: 'json',
        success: function (res) {
            switch (res) {
                case 'Horario Anulado': {
                    msgExito(res);
                    break;
                }
                case 'Error':{
                    msgError(res);
                    break;
                }
            }
            BuscarHorariosCurso();
            LimpiarFormHorario();
        }
    });
}



function ValidarCamposHorario() {
    var resultado = VerificarCampoVacio("HoraInicio") + VerificarCampoVacio("HoraFin") + VerificarCampoVacio("HorarioNombreAmbiente");
    (programaCursoHorario == "Privado") ? resultado += VerificarCampoVacio("FechaSesion") : resultado += VerificarSelectorVacio("HorarioDia");
    if (resultado > 0)
        return "Incorrecto"
    else
        return "Correcto";
}


function AgregarHorario() {
    if (filaHorario == 0)
        cont++;
    AgregarFilaTablaHorario(0, txtNumeroSesion.val(), txtFechaSesion.val(), selectorDia.val(),
        txtHoraInicio.val(), txtHoraFin.val(), txtAmbienteHorario.val(), idAmbienteSelecHorario, filaHorario);

}


function AddTituloCursoAlFormHorario(titulo) {
    tituloCursoHorario.html("");
    tituloCursoHorario.html(titulo);
}
