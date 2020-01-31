function VerificarCampoVacio(campo){
    var vacio = 0;
    if ($('#txt' + campo).val().length == 0){
        $('#error'+campo).fadeIn("slow");
        setTimeout(function(){$('#error'+campo).fadeOut("slow");},3000);
        vacio = 1;
    }
    return vacio;                                           
}

function VerificarSelectorVacio(nombreSelector){
    var vacio = 0;
    if($('#selector'+nombreSelector).val() == "0"){
        $('#error'+nombreSelector).fadeIn("slow");
        setTimeout(function(){$('#error'+nombreSelector).fadeOut("slow");},3000);
        vacio = 1;
        console.log("selector vacio pe");
    }
    return vacio;
}

function CrearDatatable(table){
    
     return $('#'+table).DataTable({
        "language": {
            "sProcessing":     "Procesando...",
                        "sLengthMenu":     "Mostrar _MENU_ registros",
                        "sZeroRecords":    "No se encontraron resultados",
                        "sEmptyTable":     "Ningún dato disponible en esta tabla =(",
                        "sInfo":           "Mostrando del _START_ al _END_ de _TOTAL_ registros",
                        "sInfoEmpty":      "Mostrando registros del 0 al 0 de un total de 0 registros",
                        "sInfoFiltered":   "(filtrado de un total de _MAX_ registros)",
                        "sInfoPostFix":    "",
                        "sSearch":         "Buscar:",
                        "sUrl":            "",
                        "sInfoThousands":  ",",
                        "sLoadingRecords": "Cargando...",
                        "oPaginate": {
                            "sFirst":    "Primero",
                            "sLast":     "Último",
                            "sNext":     "Siguiente",
                            "sPrevious": "Anterior"
                        },
                        "oAria": {
                            "sSortAscending":  ": Activar para ordenar la columna de manera ascendente",
                            "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                        },
                        "buttons": {
                            "copy": "Copiar",
                            "colvis": "Visibilidad"
                        }
    },
    pageLength : 5,
    lengthMenu: [[5, 10, 20, -1], [5, 10, 20, 'Todos']]
});      
}


/*CAMBIAR TITULO*/


function cambiarTitulo(titulo) {
    $("#tituloMenu").append(titulo);
    console.log(titulo);
}


function alertaVacio(error) {
    error.fadeIn("slow");
    setTimeout(function () { error.fadeOut("slow"); }, 3000);
}


/* USERNAME */

if ($(".navbarHeader").is(":visible")) {
    $.ajax({
        type: "get",
        url: "/Usuario/MostrarUsername",
        datatype: 'json',
        success: function (res) {
            $(".usernameNavbar").append(res);
            console.log("usuario = "+res);
        }
    });
}
