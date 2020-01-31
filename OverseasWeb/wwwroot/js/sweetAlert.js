﻿/**
 *
 * SWEET ALERT
 */

function msgCancelado(msg) {
    swal({
        title: "Cancelado!",
        text: msg,
        icon: "error",
        button: "Aceptar",
        timer: 2000
    });
}

function msgError(msg) {
    swal({
        title: "Error!",
        text: msg,
        icon: "error",
        button: "Aceptar",
        timer: 2000
    });
}

function msgExito(msg) {
    swal({
        title: "Correcto!",
        text: msg,
        icon: "success",
        button: "Aceptar",
        timer: 2000
    });
}
