/**
 * ELEMENTOS
 */

 let idDocenteTradSelec = null;
 let datatableTraduccion;
 let tablaTraduccion = $('#tablaTraduccion');
 let btnGuardarTraduccion = $('#btnGuardarTraduccion');
 let containerListadoTraduccion = $('#containerListadoTraduccion');
 let containerFormTraduccion = $('#containerRegistroTraduccion'); 
 let txtClienteTraduccion = $('#txtClienteTraduccion');
 let txtDetalleTraduccion = $('#txtDetalleTraduccion');
 let selectorIdiomaOrigen = $('#selectorIdiomaOrigen');
 let selectorIdiomaDestino =  $('#selectorIdiomaDestino');
 let txtFechaTraduccion = $('#txtFechaTraduccion');
 let txtTipoTraduccion = $('#txtTipoTraduccion');
 let txtDocenteTraduccion = $('#txtDocenteTraduccion');

 let idTraduccionEdit = 0;
 let estadoTraduccion = 1;


if(tablaTraduccion.is(':visible')){    
    cambiarTitulo("TRADUCCIONES");
    datatableTraduccion = tablaTraduccion.DataTable(dataTableConfig); 
    MostrarTraduccionesPendientes();
    ListarIdiomasTraduccion();
}


function LimpiarFormTraduccion(){    
    txtClienteTraduccion.val("");
    txtDetalleTraduccion.val("");
    selectorIdiomaOrigen.val("");
    selectorIdiomaDestino.val(""); 
    txtFechaTraduccion.val("");
    txtTipoTraduccion.val("");
    idTraduccionEdit = 0;
    txtDocenteTraduccion.val("");
    idDocenteTradSelec = null;    
    $('#checkBoxDocente').prop('checked',false);
    $('#btnBuscarDocenteCurso').prop('disabled',false);    
}

$('#checkBoxDocente').on('change',function(){
    if($(this).is(':checked')){
        txtDocenteTraduccion.val("");
        idDocenteTradSelec = null; 
        $('#btnBuscarDocenteCurso').prop('disabled',true);
    }else{
        $('#btnBuscarDocenteCurso').prop('disabled',false);
    }
})

function EditarTraduccion(id){
    idTraduccionEdit = id;
    BuscarTraduccion(id);
    CargarFormTraduccion("Editar");
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
                txtClienteTraduccion.val(traduccion.clienteTraduccion);
                txtDetalleTraduccion.val(traduccion.detalleTraduccion);
                selectorIdiomaOrigen.val(traduccion.idiomaOrigenTraduccion);
                selectorIdiomaDestino.val(traduccion.idiomaDestinoTraduccion);
                txtFechaTraduccion.val(traduccion.fechaTraduccion.substr(0, 10));  
                txtTipoTraduccion.val(traduccion.tipoTraduccion); 
                idDocenteTradSelec = traduccion.idDocente;
                $('#txtIdDocente').val(traduccion.idDocente);                             
                if(traduccion.docente.persona.nombresPersona == "Prueba"){
                    $('#checkBoxDocente').prop('checked', true);
                    $('#btnBuscarDocenteCurso').prop('disabled',true);
                    establecerCampoSinDocente();
                }                        
                else{
                    txtDocenteTraduccion.val(traduccion.docente.persona.nombresPersona + " "+ traduccion.docente.persona.apellidosPersona);
                }                              
                console.log(traduccion);                
            }
            else{
                alert("Campos vacios");
            }                
        }
    });
}

function CargarFormTraduccion(metodo){        
    containerListadoTraduccion.hide();    
    containerFormTraduccion.show(); 
    ModificarBotonGuardar(metodo, btnGuardarTraduccion);
}

function CargarTablaListadoTraduccion(){    
    containerListadoTraduccion.show();
    containerFormTraduccion.hide();
    LimpiarFormTraduccion();    
    
}

$('#btnAgregarTraduccion').click(function(){            
    //SE CARGA EL FORM Y OCULTA LA LISTA
    CargarFormTraduccion('Guardar');
    //SE ESTABLECE DATOS POR DEFECTO EN EL FORM                                            
});

function MostrarTraduccionesPendientes(){
    ActivarColorBotonEstado('TraduccionesPendientes', 'warning');
    DesactivarColorBotonEstado('TraduccionesEntregadas', 'success');
    estadoTraduccion = 1;
    ListarTraducciones();
}

function MostrarTraduccionesEntregadas(){
    ActivarColorBotonEstado('TraduccionesEntregadas', 'success');
    DesactivarColorBotonEstado('TraduccionesPendientes', 'warning');
    estadoTraduccion = 2;
    ListarTraducciones();
}


/*
 * RELLENAR SELECT IDIOMAS
 */

function ListarIdiomasTraduccion() {
    $.ajax({
        type: "get",
        url: "/Especialidad/ListarEspecialidad",
        datatype: 'json',
        success: function (res) {            
            if (res != "") {
                selectorIdiomaOrigen.html("");
                selectorIdiomaDestino.html("");
                selectorIdiomaOrigen.append('<option selected value="0"> </option>');
                selectorIdiomaDestino.append('<option selected value="0"> </option>');
                $.each(res, function (i, res) {                    
                    selectorIdiomaOrigen.append('<option value="' + res.descripcionEspecialidad + '">' + res.descripcionEspecialidad + '</option>');
                    selectorIdiomaDestino.append('<option value="' + res.descripcionEspecialidad + '">' + res.descripcionEspecialidad + '</option>');
                });
            }
        }
    });
}



function ListarTraducciones(){
    let nombreDocente = "";           
    let id = 0;
    let btnEditarTrad, btnEliminarTrad, btnProcesarTrad = '';
    CargarTablaListadoTraduccion();
    $.ajax({
        type: 'GET',
        url: "/Traduccion/Listar",                                             
        dataType: 'json',  
        data : { estado : estadoTraduccion},
        success: function (traducciones) {
            $("#contenidoTablaTraduccion").html("");                        
            if(traducciones!=""){ 
                console.log(traducciones);                              
                datatableTraduccion.clear().destroy(); 
                $.each(traducciones, function (i, traduccion){ 
                    id++;                    
                    (traduccion.docente != null) ? nombreDocente = '<td>' + traduccion.docente.persona.nombresPersona + ' ' + traduccion.docente.persona.apellidosPersona + '</td>' 
                    : nombreDocente = '<td class="sinAsignar">-Sin asignar-</td>'; 
                    if(estadoTraduccion == 1)
                        btnProcesarTrad = '<button onclick="EntregarTraduccion('+traduccion.idTraduccion+')" class="btn btn-outline-success spaceButton" rel="tooltip" title="Entregar"><span class="fa fa-check" style="color:black"></button>'; 
                    btnEditarTrad = '<button onclick="EditarTraduccion('+traduccion.idTraduccion+')" class="btn btn-outline-warning spaceButton" rel="tooltip" title="Editar"><span class="fa fa-edit" style="color:black"></button>';
                    btnEliminarTrad = '<button onclick="EliminarTraduccion('+traduccion.idTraduccion+')" class="btn btn-outline-danger spaceButton" rel="tooltip" title="Eliminar"><span class="fa fa-trash" style="color:black"></button>';
                    $('#contenidoTablaTraduccion').append('<tr>' +
                    '<td>' + id + '</td>' +
                    '<td>' + traduccion.tipoTraduccion + '</td>' +
                    '<td>' + traduccion.clienteTraduccion + '</td>' +
                    '<td>' + traduccion.detalleTraduccion + '</td>' +
                    nombreDocente +
                    '<td>' + traduccion.fechaTraduccion.substr(0,10) + '</td>' +
                    '<td>' + traduccion.idiomaOrigenTraduccion + '</td>' +
                    '<td>' + traduccion.idiomaDestinoTraduccion + '</td>' +                    
                    '<td>  <div class="form-check-inline">' + btnProcesarTrad + btnEditarTrad + btnEliminarTrad + ' </div> </td>' +
                    '</tr>');
                });
                datatableTraduccion = tablaTraduccion.DataTable(dataTableConfig);                                                                               
            }                        
        }      
    });
}

function ValidarCamposTraduccion(){
    let resultado = VerificarCampoVacio("ClienteTraduccion") + VerificarCampoVacio("DetalleTraduccion") + VerificarSelectorVacio("IdiomaOrigen") +
    VerificarSelectorVacio("IdiomaDestino") + VerificarCampoVacio("FechaTraduccion") + VerificarCampoVacio("TipoTraduccion");    

    return (resultado > 0) ? 'Incorrecto' : 'Correcto';            
}


function GuardarEditarTraduccion(metodo){          
    let action = "";
    (idTraduccionEdit == 0) ? action = "RegistrarTraduccion" : action = "EditarTraduccion";
    console.log(metodo);         
    if(ValidarCamposTraduccion() == "Correcto"){
        $.ajax({
            type: 'POST',
            url: "/Traduccion/"+ action,
            data: {
                IdTraduccion : idTraduccionEdit,
                ClienteTraduccion : txtClienteTraduccion.val(),
                TipoTraduccion : txtTipoTraduccion.val(),
                DetalleTraduccion : txtDetalleTraduccion.val(),
                IdiomaOrigenTraduccion : selectorIdiomaOrigen.val(),
                IdiomaDestinoTraduccion : selectorIdiomaDestino.val(),
                FechaTraduccion : txtFechaTraduccion.val(),
                EstadoTraduccion : 1,            
                IdDocente : idDocenteTradSelec
            },
            datatype: 'json',
            success: function (resultado) {
                if(resultado == "Correcto"){
                    msgExitoTraduccion('Realizado exitosamente.');                    
                }
            }
        });    
    }         
}

function EliminarTraduccion(id){
    estadoTraduccion = 0;
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
                    url: "/Traduccion/ModificarEstadoTraduccion",
                    data: {
                        idTraduccion : id,   
                        estado : estadoTraduccion                             
                    },
                    datatype: 'json',
                    success: function (response) {
                        msgExitoTraduccion('Traduccion eliminada exitosamente.');                        
                    }
                });
            }
            else
            {
                msgCancelado();
            }            
    });
}

function EntregarTraduccion(id){
    estadoTraduccion = 2;
    $.ajax({
        type: 'POST',
        url: "/Traduccion/ModificarEstadoTraduccion",
        data: {
            idTraduccion : id,   
            estado : estadoTraduccion                             
        },
        datatype: 'json',
        success: function (response) {
            msgExitoTraduccion('Traduccion Entregada exitosamente.');                        
        }
    });

}





function ListarDocentesActivosTraduccion() {
    let btnAgregar = "", nombres, apellidos;
    $.ajax({
        type: "get",
        url: "/Curso/ListarDocentes",
        datatype: 'json',
        success: function (res) {
            console.log(res);
            contenidoTablaDocenteCurso.html("");
            if (res != "") {
                tablaDocenteCurso.clear().destroy();
                $.each(res, function (i, res) {
                    nombres = res.persona.nombresPersona;
                    apellidos = res.persona.apellidosPersona;                    
                    btnAgregar = '<button onclick = "AgregarDocenteTraduccion('+res.idDocente+','+"'"+nombres+
                    " "+apellidos+ "'"+')" class="btn btn-outline-info" data-dismiss="modal"><span class="fa fa-plus"></button>';                    
                    contenidoTablaDocenteCurso.append(
                        '<tr>' +
                        '<td>' + res.persona.dniPersona + '</td>' +
                        '<td>' + nombres + ' ' + apellidos  + '</td>' +
                        '<td> <div class="form-check-inline">' + btnAgregar + '</div> </td>' +
                        '</tr>');
                });
                tablaDocenteCurso = $("#tablaDocenteCurso").DataTable(dataTableConfig);
            }
        }
    });
}

function AgregarDocenteTraduccion(id, docente){
    txtDocenteTraduccion.val(docente);
    idDocenteTradSelec = id;
}