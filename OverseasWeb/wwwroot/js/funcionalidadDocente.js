

/*ELEMENTOS*/

var tableDocentes = $("#dataTableDocente").DataTable(dataTableConfig);
var tablaListaEspecialidad = $("#tablaListaEspecialidad").DataTable(dataTableConfig);

/* DOCENTE*/


var dniDoc = $('#txtDniDoc');
var nombresDoc = $('#txtNombresDoc');
var apellidosDoc = $('#txtApellidosDoc');
var correoDoc = $('#txtCorreoDoc');
var fechaNacDoc = $('#txtFechaNacDoc');
var telefonoDoc = $('#txtTelefonoDoc');
var direccionDoc = $('#txtDireccionDoc');



var txtMesAño = $('#txtMesAño');
var txtHorasDocentePorMes = $('#txtHorasDocentePorMes');
var idDocenteHoras;






if ($("#viewListarDocentes").is(':visible')) {
    cambiarTitulo("Docentes");
}

/**
 *
 * INICIALIZA LISTA ESPECIALIDADES
 */

if ($("#viewRegistrarDocente").is(':visible')) {
    cambiarTitulo("Docentes");
    console.log('ESTOY EN EL MODAL ESPECIALIDAD--');
    var especialidadesSeleccionadas=[];
}



/*LISTAR ESPECIALIDADES EN MODAL FormModalEspecialidad - DOCENTE*/

function ListarEspecialidadDocente() {

    $.ajax({
        type: "get",
        url: "/Especialidad/ListarEspecialidad",
        datatype: 'json',
        success: function (res) {
            $("#datosTablaListaEspecialidad").html("");
            tablaListaEspecialidad.clear().destroy();
            if (res != "") {
                $.each(res, function (i, res) {
                    $('#datosTablaListaEspecialidad').append(
                        '<tr>' +
                        '<td>' + res.descripcionEspecialidad + '</td>' +
                        '<td>' +
                        '<button onclick="AgregarEspecialidadDeDocente(' + res.idEspecialidad + ')" class="btn btn-outline-info"  data-dismiss="modal"><span class="fa fa-plus"></button>' +
                        '</td>' +
                        '</tr>');
                });
                tablaListaEspecialidad = $("#tablaListaEspecialidad").DataTable(dataTableConfig);
            } else {
                msgError(`No hay idiomas registrados`);
            }
        }
    });
}


/*REGISTRO DE DOCENTE */

function RegistrarDocentes() {

    let datosDocente = {
        Persona: {
            DniPersona: dniDoc.val(),
            NombresPersona: nombresDoc.val(),
            ApellidosPersona: apellidosDoc.val(),
            CorreoPersona: correoDoc.val(),
            FechaNacimientoPersona: fechaNacDoc.val(),
            TelefonoPersona: telefonoDoc.val(),
            DireccionPersona: direccionDoc.val()
        }
    };
    console.log("docente----------");
    console.log(datosDocente);

    if (VerificarCamposVaciosDocente() == 0) {

        $.ajax({
            type: "post",
            url: "/Docente/RegistrarDocente",
            datatype: 'json',
            data: { docente: datosDocente, especialidades: especialidadesSeleccionadas },
            success: function (res) {
                if (res == "Registro Completado") {
                    msgExito(res);
                } else {
                    msgError(res);
                }
            }
        });
    }

}


/* MOSTRAR DATOS EN TABLA- ESPECIALIDADES SELECCIONADAS
 */

function ListarSeleccionados() {
    $("#datostablaEspecialidadesDelDocente").html("");
    $.each(especialidadesSeleccionadas, function (i, especialidadesSeleccionadas) {
        $('#datostablaEspecialidadesDelDocente').append(
            '<tr>' +
            '<td>' + especialidadesSeleccionadas.descripcionEspecialidad + '</td>' +
            '<td>' +
            '<button onclick="EliminarEspecialidadDeDocente(' + i + ')" class="btn btn-outline-danger"><span class="fa fa-remove"></button>' +
            '</td>' +
            '</tr>');
    });
}

/*AGREGAR IDIOMA*/

function AgregarEspecialidadDeDocente(id) {
    $.ajax({
        type: "get",
        url: "/Especialidad/BuscarEspecialidadPorID",
        datatype: 'json',
        data: { id },
        success: function (res) {
            let arrayID = especialidadesSeleccionadas.map((x) => x.idEspecialidad);
            let existe = arrayID.includes(res.idEspecialidad);
            if (!existe) {
                especialidadesSeleccionadas.push(res);
                ListarSeleccionados();
            }
        }
    });

}


/*ELIMINAR IDIOMA DEL ARRAY*/

function EliminarEspecialidadDeDocente(id) {
    especialidadesSeleccionadas.splice(id, 1);
    ListarSeleccionados();

    console.log("FUNC ELIMINAR ESP DOC");
    console.log(especialidadesSeleccionadas);
}



/**
 * 
 * RELLENA DATOS DOCENTE
 */

if ($("#viewEditarDocente").is(':visible')) {
    cambiarTitulo("Docentes");
    var formDisabledDoc = true;
    bloquearFormDoc(formDisabledDoc);
    var idDocente = $("#txtIdDocente").val();
    var idPersonaDocente;
    console.log('ESTOY EN EL EVENTO EDITAR DOCENTE--');
    console.log('ID DOCENTE--', idDocente);
    buscarDocente(idDocente);
    buscarEspecialidadesDocente(idDocente);
}


/*BUSCAR DATOS DE DOCENTE*/


function buscarDocente(idDocente) {
    console.log("BUSCAR DOCENTE");
    $.ajax({
        type: "get",
        url: "/Docente/BuscarDocente",
        datatype: 'json',
        data: { id: idDocente },
        success: function (response) {
            console.log("RESPUESTA");
            console.log(response);
            if (response != null) {
                idPersonaDocente = response.idPersona;
                dniDoc.val(response.persona.dniPersona);
                correoDoc.val(response.persona.correoPersona);
                nombresDoc.val(response.persona.nombresPersona);
                apellidosDoc.val(response.persona.apellidosPersona);
                fechaNacDoc.val(response.persona.fechaNacimientoPersona.substr(0, 10));
                telefonoDoc.val(response.persona.telefonoPersona);
                direccionDoc.val(response.persona.direccionPersona);
            } else {
                console.log("NO HAY REPUESTA");
            }
        }
    });
}

function buscarEspecialidadesDocente(idDocente) {
    $.ajax({
        type: "get",
        url: "/Docente/BuscarEspecialidadesDelDocente",
        datatype: 'json',
        data: { id: idDocente },
        success: function (response) {
            especialidadesSeleccionadas = response;
            ListarSeleccionados();
            console.log("LISTA SELECCIONADOS");
            console.log(response);
        }
    });
}


/*EDITAR DOCENTE*/


function EditarDocente() {

    let datosDocente = {
        Persona: {
            IdPersona: idPersonaDocente,
            DniPersona: dniDoc.val(),
            NombresPersona: nombresDoc.val(),
            ApellidosPersona: apellidosDoc.val(),
            CorreoPersona: correoDoc.val(),
            FechaNacimientoPersona: fechaNacDoc.val(),
            TelefonoPersona: telefonoDoc.val(),
            DireccionPersona: direccionDoc.val()
        },
        IdPersona: idPersonaDocente,
        IdDocente: idDocente,
        Estado: 1
    };

    if (VerificarCamposVaciosDocente()==0) {
        $.ajax({
            type: "post",
            url: "/Docente/EditarDocente",
            datatype: 'json',
            data: { docente: datosDocente, especialidades: especialidadesSeleccionadas },
            success: function (res) {
                console.log("docente----------");
                console.log(datosDocente);
                if (res == "Datos actualizados") {
                    buscarDocente(idDocente);
                    buscarEspecialidadesDocente(idDocente);
                    msgExito(res);
                } else {
                    msgError(res);
                }
            }
        });
    }

}

/*
 *CONTAR HORAS DOCENTE POR MES 
 */

function ContarHorasDocentePorMes() {
    let mes = txtMesAño.val().substr(5,2);
    let año = txtMesAño.val().substr(0,4);
    $.ajax({
        type: "get",
        url: "/Docente/HorasAcumuladasDelMesDocente",
        datatype: 'json',
        data: { mes: mes, año: año, idDocente: idDocenteHoras },
        success: function (response) {
            txtHorasDocentePorMes.html("");
            txtHorasDocentePorMes.append(response);
        }
    });
}

function SeleccionarDocente(idDocente) {
    idDocenteHoras = idDocente;
}




/* HABILITAR o DESHABILITAR BOTON DE EDICION*/
$("#btnEdicionDocente").on('click', function () {
    if (formDisabledDoc == true) {
        formDisabledDoc = false;
        bloquearFormDoc(formDisabledDoc);
    } else {
        formDisabledDoc = true;
        bloquearFormDoc(formDisabledDoc);
    }
});

/*BLOQUEAR FORMULARIOS*/
function bloquearFormDoc(disabled) {

    //DATOS ESTUDIANTE

    dniDoc.prop('disabled', disabled);
    correoDoc.prop('disabled', disabled);
    nombresDoc.prop('disabled', disabled);
    apellidosDoc.prop('disabled', disabled);
    fechaNacDoc.prop('disabled', disabled);
    telefonoDoc.prop('disabled', disabled);
    direccionDoc.prop('disabled', disabled);
}











/* VERIFICAR CAMPOS VACIOS */

function VerificarCamposVaciosDocente() {
    let valido = VerificarCampoVacio("DniDoc") +
        VerificarCampoVacio("NombresDoc") +
        VerificarCampoVacio("ApellidosDoc") +
        VerificarCampoVacio("CorreoDoc") +
        VerificarCampoVacio("FechaNacDoc") +
        VerificarCampoVacio("DireccionDoc") +
        VerificarCampoVacio("TelefonoDoc");
    return valido;
}




