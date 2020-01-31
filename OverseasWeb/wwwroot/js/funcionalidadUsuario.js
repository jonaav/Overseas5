
/* ELEMENTOS*/

var tableUsuarios = $("#dataTableUsuario").DataTable(dataTableConfig);
var datosUsuarios = $("#datosUsuarios");


if ($("#viewListarUsuarios").is(':visible')) {
    console.log("asd");
    cambiarTitulo("Usuarios");
    ListarUsuarios();
}



/*LISTAR USUARIOS*/

function ListarUsuarios() {
    $.ajax({
        type: "get",
        url: "/Usuario/ListaDeUsuarios",
        datatype: 'json',
        success: function (response) {
            console.log(response);
            //datosUsuarios.html("");
            tableUsuarios.clear().destroy();
            if (response != "") {
                $.each(response, function (i, res) {

                    let btnStatus;
                    let estado;
                    if (res.statusUser == 1) {
                        estado = "Habilitado";
                        btnStatus = '<button onclick="DeshabilitarUsuario(' + res.id + ')" class="btn btn-outline-danger m-1" rel="tooltip" title="Deshabilitar"><span class="fa fa-remove"></button>';
                    }
                    else {
                        estado = "Deshabilitado";
                        btnStatus = '<button onclick="HabilitarUsuario(' + res.id + ')" class="btn btn-outline-success m-1" rel="tooltip" title="Habilitar"><span class="fa fa-check"></button>';
                    }
                    datosUsuarios.append(
                        '<tr>' +
                        '<td>' + res.rol + '</td>' +
                        '<td>' + res.username + '</td>' +
                        '<td>' + res.apellidos + '</td>' +
                        '<td>' + res.nombres + '</td>' +
                        '<td>' + estado + '</td>' +
                        '<td><div class="form-check-inline">' + btnStatus + '</div></td>' +
                        '</tr>');
                });
                tableUsuarios = $("#dataTableUsuario").DataTable(dataTableConfig);
            } else {
                msgError(`No se encontraron datos`);
            }
        }
    });
}

/*HABILITAR USUARIO*/

function HabilitarUsuario(idUsuario) {
    console.log(idUsuario);
    $.ajax({
        type: "post",
        url: "/Usuario/HabilitarUsuario",
        datatype: 'json',
        data: { idUsuario: idUsuario },
        success: function (response) {
            if (response == "Exito") {
                msgExito(`Usuario habilitado`);
                ListarUsuarios();
            } else {
                msgError(`No se encontraron datos`);
            }
        }
    });
}

/*DESHABILITAR USUARIO*/

function DeshabilitarUsuario(idUsuario) {
    console.log(idUsuario);
    $.ajax({
        type: "post",
        url: "/Usuario/DeshabilitarUsuario",
        datatype: 'json',
        data: { idUsuario: idUsuario },
        success: function (response) {
            if (response == "Exito") {
                msgExito(`Usuario deshabilitado`);
                ListarUsuarios();
            } else {
                msgError(`No se encontraron datos`);
            }
        }
    });
}
