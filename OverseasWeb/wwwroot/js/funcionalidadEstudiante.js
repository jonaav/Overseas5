

/* ELEMENTOS*/

//ESTUDIANTE
var dni = $('#txtDniEst');
var nombres = $('#txtNombresEst');
var apellidos = $('#txtApellidosEst');
var correo = $('#txtCorreoEst');
var fechaNac = $('#txtFechaNacEst');
var telefono = $('#txtTelefonoEst');
var poseeApoderado = $('#txtPoseeApoderado');
var poseeApoderadoEdit = $('#txtPoseeApoderadoEdit');
var direccion = $('#txtDireccionEst');
var referencia = $('#txtReferenciaEst');
//APODERADO
var teniaApoderadoEdit;
var correoAp = $('#txtCorreoAp');
var nombresAp = $('#txtNombresAp');
var apellidosAp = $('#txtApellidosAp');




/*TITULO*/
if ($("#viewListarEstudiantes").is(':visible')) {
    cambiarTitulo("Estudiante");
}

if ($("#viewRegistroEstudiantes").is(':visible')) {
    cambiarTitulo("Estudiante");
}


/*ACTIVACION DE BOTON APODERADO*/

$(document).on('click', $("#txtPoseeApoderado"), function () {
    if ($("#txtPoseeApoderado").val() == 2) {
        $("#btnAgregarApoderado").prop('disabled', false);
    } else {
        $("#btnAgregarApoderado").prop('disabled', true);
    }
    if ($("#txtPoseeApoderadoEdit").val() == 2) {
        $("#btnEditarApoderado").prop('disabled', false);
    } else {
        $("#btnEditarApoderado").prop('disabled', true);
    }
});


/*REGISTRO DE ESTUDIANTE */

function RegistrarEstudiantes() {

    let datosEstudiante = {
        Persona: {
            DniPersona: dni.val(),
            NombresPersona: nombres.val(),
            ApellidosPersona: apellidos.val(),
            CorreoPersona: correo.val(),
            FechaNacimientoPersona: fechaNac.val(),
            TelefonoPersona: telefono.val(),
            DireccionPersona: direccion.val()
        },
        PoseeApoderado: poseeApoderado.val(),
        ReferenciaEstudiante: referencia.val()
    };

    console.log("estudiante----------");
    console.log(datosEstudiante);


    if (VerificarCamposVaciosEstudiante() == 0) {
        console.log("VALIDACION CORRECTA----------");
        console.log(VerificarCamposVaciosEstudiante());
        $.ajax({
            type: "post",
            url: "/Estudiante/RegistrarEstudiante",
            datatype: 'json',
            data: datosEstudiante,
            success: function (res) {
                console.log("res----------");
                console.log(res);
                if (res == "Registro Completado") {
                    if (poseeApoderado.val() == 2) {
                        console.log("Posee apoderado----------");
                        RegistrarApoderado(datosEstudiante);
                    } else {
                        console.log("No posee apoderado----------");
                        msgExito(res);
                    }
                } else {
                    msgError(res);
                }
            }
        });
    } else {
        console.log("Datos no validos");
    }
}

function RegistrarApoderado(datosEstudiante) {

    let datosApoderado = {
        NombresApoderado: nombresAp.val(),
        ApellidosApoderado: apellidosAp.val(),
        CorreoApoderado: correoAp.val()
    }

    console.log("apoderado----------");
    console.log(datosApoderado);
    $.ajax({
        type: "post",
        url: "/Estudiante/RegistrarApoderado",
        datatype: 'json',
        data: { estudiante: datosEstudiante, apoderado: datosApoderado },
        success: function (resp) {
            console.log(resp);
            if (resp == "Registro Completado") {
                msgExito(resp);
            } else {
                msgError(resp);
            }
        }
    });
}


/**
* 
* RELLENA DATOS DEL APODERADO EN MODAL
*/


function buscarApoderado(idEstudiante) {
    $.ajax({
        type: "get",
        url: "/Estudiante/BuscarApoderadoDeUnEstudiante",
        datatype: 'json',
        data: { id: idEstudiante },
        success: function (response) {
            console.log(response);
            idApoderado = response.idApoderado;
            correoAp.val(response.correoApoderado);
            nombresAp.val(response.nombresApoderado);
            apellidosAp.val(response.apellidosApoderado);
        }
    });
}

/**
 * 
 * RELLENA DATOS ESTUDIANTE
 */

if ($("#viewEditarEstudiante").is(':visible')) {
    cambiarTitulo("Estudiantes");
    var formDisabled = true;
    bloquearForm(formDisabled);

    var idEstudiante = $("#txtIdEst").val();
    console.log('ESTOY EN EL EVENTO EDITAR ESTUDIANTE--');
    buscarEstudiante(idEstudiante);
    var idPersonaEstudiante;
    var idApoderado;

    let xd = "";
    console.log('xd longitud--');
    console.log(xd.length);

}

function buscarEstudiante(idEstudiante) {
    $.ajax({
        type: "get",
        url: "/Estudiante/BuscarEstudiante",
        datatype: 'json',
        data: { id: idEstudiante },
        success: function (response) {
            console.log(response);
            idPersonaEstudiante = response.idPersona;
            dni.val(response.persona.dniPersona);
            correo.val(response.persona.correoPersona);
            nombres.val(response.persona.nombresPersona);
            apellidos.val(response.persona.apellidosPersona);
            fechaNac.val(response.persona.fechaNacimientoPersona.substr(0, 10));
            telefono.val(response.persona.telefonoPersona);
            direccion.val(response.persona.direccionPersona);
            referencia.val(response.referenciaEstudiante);
            poseeApoderadoEdit.val(response.poseeApoderado);
            if (response.poseeApoderado == 2) {
                $("#btnEditarApoderado").prop('disabled', false);
                teniaApoderadoEdit = true;
                buscarApoderado(idEstudiante);
            }
            else {
                $("#btnEditarApoderado").prop('disabled', true);
                teniaApoderadoEdit = false;
            }
            console.log("El estudiante TENIA apoderado?");
            console.log(teniaApoderadoEdit);

        }
    });
}



/**
 * 
 * EDITAR APODERADO
 */

function EditarApoderado() {

    var datosApoderado = {
        IdApoderado: idApoderado,
        NombresApoderado: nombresAp.val(),
        ApellidosApoderado: apellidosAp.val(),
        CorreoApoderado: correoAp.val(),
    }

    console.log("Editando apoderado----------");
    console.log(datosApoderado);

    $.ajax({
        type: "post",
        url: "/Estudiante/EditarApoderado",
        datatype: 'json',
        data: datosApoderado,
        success: function (res) {
            console.log(res);
            if (res == "Datos actualizados") {
                msgExito(res);
            } else {
                msgError(res);
            }
        }
    });
}



/**
 *
 * EDITAR ESTUDIANTE
 */


function EditarEstudiantes() {

    let datosEstudiante = {
        Persona: {
            IdPersona: idPersonaEstudiante,
            DniPersona: dni.val(),
            NombresPersona: nombres.val(),
            ApellidosPersona: apellidos.val(),
            CorreoPersona: correo.val(),
            FechaNacimientoPersona: fechaNac.val(),
            TelefonoPersona: telefono.val(),
            DireccionPersona: direccion.val()
        },
        IdEstudiante: idEstudiante,
        IdPersona: idPersonaEstudiante,
        PoseeApoderado: poseeApoderadoEdit.val(),
        ReferenciaEstudiante: referencia.val()
    };

    /*borrar*/
    console.log("Editando estudiante----------");
    console.log(datosEstudiante);

    if (VerificarCamposVaciosEstudiante() == 0) {

        $.ajax({
            type: "post",
            url: "/Estudiante/EditarEstudiante",
            datatype: 'json',
            data: datosEstudiante,
            success: function (res) {
                if (res == "Datos Actualizados") {
                    console.log("poseeApoderado");
                    console.log(poseeApoderado.val());
                    console.log("poseeApoderadoEdit");
                    console.log(poseeApoderadoEdit.val());
                    if (!teniaApoderadoEdit) {
                        if (poseeApoderadoEdit.val() == 2) {
                            console.log("Agregar apoderado-*");
                            console.log(datosEstudiante);
                            RegistrarApoderado(datosEstudiante);
                        } else {
                            msgExito(res)
                        }
                    } else {
                        if (poseeApoderadoEdit.val() == 1) {
                            console.log("Eliminar apoderado-*");
                            console.log(datosEstudiante);
                            EliminarApoderado(datosEstudiante);
                        } else {
                            EditarApoderado();
                        }
                    }
                } else {
                    msgError(res);
                }
                buscarEstudiante(idEstudiante);
            }
        });
    }

}


/**
 * 
 * ELIMINAR APODERADO
 */

function EliminarApoderado(datosEstudiante) {

    //console.log("Eliminando apoderado----------");
    //console.log(datosApoderado);
    console.log("Editando estudiante----------");
    console.log(datosEstudiante);

    $.ajax({
        type: "post",
        url: "/Estudiante/EliminarApoderado",
        datatype: 'json',
        data: datosEstudiante,
        success: function (res) {
            console.log(res);
            if (res == "Apoderado eliminado") {
                console.log(res);
                msgExito(res);
                LimpiarFormApoderado();
            } else {
                console.log(res);
                msgError(res);
            }
        }
    });
}

/* HABILITAR o DESHABILITAR BOTON DE EDICION*/
$("#btnEdicionEstudiante").on('click', function () {
    if (formDisabled == true) {
        formDisabled = false;
        bloquearForm(formDisabled);
    } else {
        formDisabled = true;
        bloquearForm(formDisabled);
    }
});

/*BLOQUEAR FORMULARIOS*/
function bloquearForm(disabled) {

    //DATOS ESTUDIANTE

    dni.prop('disabled', disabled);
    correo.prop('disabled', disabled);
    nombres.prop('disabled', disabled);
    apellidos.prop('disabled', disabled);
    fechaNac.prop('disabled', disabled);
    telefono.prop('disabled', disabled);
    direccion.prop('disabled', disabled);
    referencia.prop('disabled', disabled);
    poseeApoderadoEdit.prop('disabled', disabled);
    $("#btnEditarApoderado").prop('disabled', disabled);

    //DATOS APODERADO

    correoAp.prop('disabled', disabled);
    nombresAp.prop('disabled', disabled);
    apellidosAp.prop('disabled', disabled);

    if (disabled == true) {
        $(".btnFormApoderado").hide();
    } else {
        $(".btnFormApoderado").show();
    }
}





/*
 LIMPIAR DATOS DEL APODERADO
 */

function LimpiarFormApoderado() {
    console.log("DATOS APODERADO PARA LIMPIAR");
    console.log(correoAp.val());
    console.log(nombresAp.val());
    console.log(apellidosAp.val());
    let vacio = "";
    correoAp.val(vacio);
    nombresAp.val(vacio);
    apellidosAp.val(vacio);
}



/*VALIDACION FORMULARIO ESTUDIANTE*/
function validacionDniEstudiante(dni) {
    if (dni.val().length != 8) {
        //alert("El dni debe tener 8 digitos");
    }
}


/* VERIFICAR CAMPOS VACIOS */

function VerificarCamposVaciosEstudiante() {
    let valido = VerificarCampoVacio("DniEst") +
        VerificarCampoVacio("NombresEst") +
        VerificarCampoVacio("ApellidosEst") +
        VerificarCampoVacio("CorreoEst") +
        VerificarCampoVacio("FechaNacEst") +
        VerificarCampoVacio("DireccionEst") +
        VerificarCampoVacio("ReferenciaEst") +
        VerificarCampoVacio("TelefonoEst");


    let validoAp = 0;
    if (poseeApoderado.val() == 2) {
        validoAp = VerificarCampoVacio("NombresAp") + VerificarCampoVacio("ApellidosAp") + VerificarCampoVacio("CorreoAp");
        if (validoAp != 0) {
            $('#errorPoseeApoderado').fadeIn("slow");
            setTimeout(function () { $('#errorPoseeApoderado').fadeOut("slow"); }, 3000);
        }
    }
    if (poseeApoderadoEdit.val() == 2) {
        validoAp = VerificarCampoVacio("NombresAp") + VerificarCampoVacio("ApellidosAp") + VerificarCampoVacio("CorreoAp");
        if (validoAp != 0) {
            $('#errorPoseeApoderadoEdit').fadeIn("slow");
            setTimeout(function () { $('#errorPoseeApoderadoEdit').fadeOut("slow"); }, 3000);
        }
    }
    console.log("RETURN");
    console.log(valido + validoAp);
    return valido + validoAp;
}






/*DATA TABLE IDIOMA ESPAÑOL*/

$("#dataTableEstudiante").DataTable(dataTableConfig);

/*NO VALE------------------------------------------------*/
