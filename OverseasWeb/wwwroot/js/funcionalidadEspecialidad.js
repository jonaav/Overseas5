

/*ELEMENTOS*/
var tablaEspecialidad = $("#tablaEspecialidad").DataTable(dataTableConfig);

var descripcion = $('#txtDescripcionEsp');


if ($("#viewEspecialidad").is(':visible')) {
    ListarEspecialidad();
    cambiarTitulo("Idiomas");
}


/*LISTAR ESPECIALIDADES */

function ListarEspecialidad() {
    let btnEliminar = "";
    $.ajax({
        type: "get",
        url: "/Especialidad/ListarEspecialidad",
        datatype: 'json',
        success: function (res) {
            $("#contenidoTablaEspecialidad").html("");
            tablaEspecialidad.clear().destroy();
            if (res!= "") {
                $.each(res, function (i, res){
                    (res.descripcionEspecialidad == 'Inglés') ? btnEliminar = '<button disabled onclick class="btn btn-outline-danger"><span class="fa fa-remove"></button>'
                        : btnEliminar = '<button onclick = "EliminarEspecialidad(' + res.idEspecialidad + ')" class="btn btn-outline-danger"><span class="fa fa-remove"></button>'
                    $('#contenidoTablaEspecialidad').append('<tr>' +
                        '<td>' + res.descripcionEspecialidad + '</td>' +
                        '<td>' + btnEliminar + ' </td>' +
                        '</tr>');                    
                });
                tablaEspecialidad = $("#tablaEspecialidad").DataTable(dataTableConfig);
            } else {
                msgError("No se encontraron datos");
            }
            console.log(res);
        }
    });
}


/*REGISTRO DE ESPECIALIDAD */

function RegistrarEspecialidad() {


    let datosEspecialidad = {
        DescripcionEspecialidad: descripcion.val()
    };

    if (VerificarCamposVaciosEspecialidad() == 0) {
        $.ajax({
            type: "post",
            url: "/Especialidad/RegistrarEspecialidad",
            datatype: 'json',
            data: datosEspecialidad,
            success: function (res) {
                if (res == "Exito") {
                    msgExito(`Idioma ${datosEspecialidad.DescripcionEspecialidad} registrado correctamente`);
                    ListarEspecialidad();
                } else {
                    msgError(`Idioma ${datosEspecialidad.DescripcionEspecialidad} no pudo ser registrado`);
                }
            }
        });
        LimpiarFormEspecialidad();
    }

}

/* VERIFICAR CAMPOS VACIOS */ 

function VerificarCamposVaciosEspecialidad() {
    let valido = VerificarCampoVacio("DescripcionEsp");
    return valido;
}

/*ELIMINAR ESPECIALIDAD*/

function EliminarEspecialidad(id) {

    console.log(id);

    swal({
        title: "Advertencia",
        text: "¿Desea eliminar este Idioma?, tambien se eliminara de los datos de los docentes",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((eliminar) => {

        if (eliminar) {
            $.ajax({
                type: "post",
                url: "/Especialidad/EliminarEspecialidad",
                datatype: 'json',
                data: { id },
                success: function (res) {
                    if (res == "Exito") {
                        msgExito(`Idioma  eliminado correctamente`);
                        ListarEspecialidad();
                    } else {
                        msgError(`Idioma no pudo ser eliminado`);
                    }
                }
            });
        } else {
            msgCancelado("No se eliminara el idioma");
        }
    });

}



/* LIMPIAR FORM REGISTRO*/
function LimpiarFormEspecialidad() {
    $('#txtDescripcionEsp').val("");
}