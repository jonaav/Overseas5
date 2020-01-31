if($('#tablaTraduccion').is(':visible')){
    CargarTablaListadoTraduccion();
    cambiarTitulo("TRADUCCIONES");     
}

function BuscarTraduccion(idTrad){
    $.ajax({
        type: 'GET',
        url: "/Traduccion/BuscarTraduccion",
        data: {               
            idTraduccion : idTrad
        },
        datatype: 'json',
        success: function (traduccion) {
            if(traduccion!=""){
                CargarFormTraduccion("Editar");
                $('#txtIdTraduccion').val(traduccion.idTraduccion);
                $('#txtClienteTraduccion').val(traduccion.clienteTraduccion);
                $('#txtDetalleTraduccion').val(traduccion.detalleTraduccion);
                $('#txtIdiomaOrigen').val(traduccion.idiomaOrigenTraduccion);
                $('#txtIdiomaDestino').val(traduccion.idiomaDestinoTraduccion);
                $('#txtFechaTraduccion').val(traduccion.fechaTraduccion.substr(0, 10));  
                $('#txtTipoTraduccion').val(traduccion.tipoTraduccion); 
                $('#txtIdDocente').val(traduccion.idDocente); 
                $('#txtIdCurso').val(traduccion.tipoTraduccion);              
                if(traduccion.docente.persona.nombresPersona == "Prueba"){
                    $('#checkBoxDocente').prop('checked', true);
                    $('#btnBuscarDocenteCurso').prop('disabled',true);
                    establecerCampoSinDocente();
                }                        
                else{
                    $('#txtNombreDocente').val(traduccion.docente.persona.nombresPersona + " "+ traduccion.docente.persona.apellidosPersona);
                }                              

                console.log(traduccion);
                
            }
            else{
                alert("Campos vacios");
            }                
        },
        error: function () {
        }
    });
}

function CargarFormTraduccion(metodo){    
    LimpiarFormTraduccion();
    $('#containerListadoTraduccion').hide();    
    $('#containerRegistroTraduccion').show(); 
    if(metodo=="Guardar"){
        $('#divGuardarTraduccion').show();
        $('#divEditarTraduccion').hide();
    }else{
        $('#divEditarTraduccion').show();
        $('#divGuardarTraduccion').hide();
    }
}

function CargarTablaListadoTraduccion(){    
    $('#containerListadoTraduccion').show();    
    $('#containerRegistroTraduccion').hide();
    ListarTraducciones();

}

$('#btnAgregarTraduccion').click(function(){            
    //SE CARGA EL FORM Y OCULTA LA LISTA
    CargarFormTraduccion("Guardar");
    //SE ESTABLECE DATOS POR DEFECTO EN EL FORM                                            
});

function ListarTraducciones(){
    var campoDocente = "";       
    var table = $('#tablaTraduccion').DataTable(); 
    var id = 0;
    $.ajax({
        type: 'GET',
        url: "/Traduccion/Listar",                                             
        dataType: 'json',  
        success: function (traducciones) {
            $("#contenidoTablaTraduccion").html("");            
            table.clear().destroy();
            if(traducciones!=""){                                
                $.each(traducciones, function (i, traduccion){ 
                    id++;
                    if(traduccion.docente.persona.nombresPersona == "Prueba")
                            campoDocente = '    <td style = "color:red"> - Sin Asignar - </td>';                            
                        else
                            campoDocente = '    <td>'+ traduccion.docente.persona.nombresPersona+'</td>';                 
                    $('#contenidoTablaTraduccion').append('<tr>' +
                    '<td>' + id + '</td>' +
                    '<td>' + traduccion.tipoTraduccion + '</td>' +
                    '<td>' + traduccion.clienteTraduccion + '</td>' +
                    '<td>' + traduccion.detalleTraduccion + '</td>' +
                    campoDocente +
                    '<td>' + traduccion.fechaTraduccion.substr(0,10) + '</td>' +
                    '<td>' + traduccion.idiomaOrigenTraduccion + '</td>' +
                    '<td>' + traduccion.idiomaDestinoTraduccion + '</td>' +                    
                    '<td>  <button  onclick="BuscarTraduccion('+traduccion.idTraduccion+')" class="btn btn-outline-warning"><span class="fa fa-edit" style="color:black"></button> '+
                    '</td>'+
                    '<td>'+
                          '<button  onclick="EliminarTraduccion('+traduccion.idTraduccion+')" class="btn btn-outline-danger"><span class="fa fa-trash" style="color:black"></button>'+ 
                    '</td>'+
                    '</tr>');
                });
                
                table = CrearDatatable("tablaTraduccion");                                                                                 
            }                        
        },
        error: function () {
        }        
    });
}



function LimpiarFormTraduccion(){
    $('#txtIdTraduccion').val("");
    $('#txtClienteTraduccion').val("");
    $('#txtDetalleTraduccion').val("");
    $('#txtIdiomaOrigen').val("");
    $('#txtIdiomaDestino').val(""); 
    $('#txtFechaTraduccion').val("");
    $('#txtTipoTraduccion').val("");
    $('#checkBoxDocente').prop('checked',false);
    $('#btnBuscarDocenteCurso').prop('disabled',false);
    EstablecerCampoSinDocente();
}



function ValidarCamposTraduccion(){
    var resultado =VerificarCampoVacio("ClienteTraduccion") + VerificarCampoVacio("DetalleTraduccion") + VerificarCampoVacio("IdiomaOrigen") +
    VerificarCampoVacio("IdiomaDestino") + VerificarCampoVacio("FechaTraduccion") + VerificarCampoVacio("TipoTraduccion");    
    if(resultado > 0)                 
        return "Incorrecto";
    else
        return "Correcto";
}



function GuardarEditarTraduccion(metodo){
    var idTraduccion = $('#txtIdTraduccion').val(); 
    var cliente = $('#txtClienteTraduccion').val(); 
    var detalle = $('#txtDetalleTraduccion').val(); 
    var idiomaOrigen = $('#txtIdiomaOrigen').val(); 
    var idiomaDestino = $('#txtIdiomaDestino').val(); 
    var fecha = $('#txtFechaTraduccion').val();
    var tipo =  $('#txtTipoTraduccion').val();
    var idDocente = $('#txtIdDocente').val(); 
    var estado = 1;   
    var accion = "";
    console.log(metodo);
    if(metodo=="Guardar")
        accion = "RegistrarTraduccion"; 
    else
        accion = "EditarTraduccion";
    if(idDocente=="")
        idDocente = 1; 
    if(ValidarCamposTraduccion() == "Correcto"){
        $.ajax({
            type: 'POST',
            url: "/Traduccion/"+ accion,
            data: {
                IdTraduccion : idTraduccion,
                ClienteTraduccion : cliente,
                TipoTraduccion : tipo,
                DetalleTraduccion : detalle,
                IdiomaOrigenTraduccion : idiomaOrigen,
                IdiomaDestinoTraduccion : idiomaDestino,
                FechaTraduccion : fecha,
                EstadoTraduccion : estado,            
                IdDocente : idDocente
            },
            datatype: 'json',
            success: function (resultado) {
                if(resultado == "Correcto"){
                    swal({
                        title: "Correcto!",
                        text: "Realizado exitosamente.",
                        icon: "success",                      
                        button: "Aceptar",
                        timer: 2000
                    }).then(
                        function () {
                            if (true) {        
                                limpiarFormCurso();                        
                                CargarTablaListadoTraduccion();                                                                              
                            }
                        }
                    )        
                }
            }
        });    
    }         
}

function EliminarTraduccion(id){
    swal({
        title: "Mensaje de Confirmacion",
        text: "¿Desea eliminar esta traducción?",
        icon: "warning",
        buttons: true,
        dangerMode: true
        })
        .then((willDelete) => {
            if(willDelete){                        
                $.ajax({
                    type: 'POST',
                    url: "/Traduccion/EliminarTraduccion",
                    data: {
                        idTraduccion : id,                                
                    },
                    datatype: 'json',
                    success: function (response) {
                        swal({
                            title: "Correcto!",
                            text: "Traduccion eliminada exitosamente.",
                            icon: "success",
                            button: "Aceptar",
                            timer: 2000
                        }).then(
                            function () {
                                if (true) {
                                    CargarTablaListadoTraduccion(); 
                                }
                            }
                        )
                    },
                    error: function () {                        
                    }
                });
            }
            else
            {
                swal({
                    title: "Cancelado!",
                    icon : "error",                                        
                    button: "Aceptar",
                    timer: 2000
                })
            }            
    });
}