var cont = 0;
var filaHorario = 0;
let idCursoHorario;
let idAmbienteSelec;

/**
 * Elementos Horario
 * REGULAR
 */

 let selectorDia = $('#selectorHorarioDia');
 let txtHoraInicio = $('#txtHoraInicio');
 let txtHoraFin = $('#txtHoraFin');
 let txtAmbienteHorario = $('#txtHorarioNombreAmbiente');
 
 /**
  * Privado
  */

  let txtNumeroSesion = $('#txtNumeroSesion');
  let txtFechaSesion = $('#txtFechaSesion');

  /**
   * FALTA CAMBIAR, pero ya me dio pereza xd
   */


function CancelarIngresoHorario(){
    LimpiarFormHorario();
    SeleccionarCurso(cursoSeleccionado, $('#txtProgramaCursoHorario').val());
}

function LimpiarFormHorario(){
    $('#txtNumeroSesion').val($('#txtNumeroActualSesion').val());
    $('#txtFechaSesion').val("");
    $('#selectorHorarioDia').val(0);
    $('#txtHoraInicio').val("");
    $('#txtHoraFin').val("");
    $('#txtHorarioIdAmbiente').val("");
    $('#txtHorarioNombreAmbiente').val("");
}
    
function MostrarAmbientesParaHorario(){
    var table = $('#tablaAmbienteModal').DataTable(); 
    $.ajax({
        type: 'GET',
        url: "/Ambiente/Listar",                                             
        dataType: 'json',  
        success: function (data) {
            $("#contenidoTablaAmbiente").html("");
            table.clear().destroy();                
            if(data!=""){
                obj = data;
                $.each(obj, function (i, obj){                            
                    $('#contenidoTablaAmbiente').append('<tr>' +
                    '<td>' + obj.idAmbiente + '</td>' +
                    '<td>' + obj.descripcionAmbiente + '</td>' +                        
                    '<td>' + obj.aula + '</td>' +
                    '<td> <button type="button" onclick="AsignarAmbienteAlFormHorario('+obj.idAmbiente+','+"'"+obj.descripcionAmbiente+
                           " "+obj.aula+ "'"+')" class="btn btn-outline-info btn-sm">Asignar</button></td>'+
                    '</tr>');    
                });
                table = CrearDatatable("tablaAmbienteModal");                    
            }            
        },
        error: function () {
        }
    });
}

function CargarModalAmbienteParaHorario(){
    $('#modalBuscarAmbiente').modal("show"); 
    MostrarAmbientesParaHorario();       
}

function AsignarAmbienteAlFormHorario( idAmbiente, descripcion){
    $('#modalBuscarAmbiente').modal("hide");
    $('#txtHorarioIdAmbiente').val(idAmbiente);
    $('#txtHorarioNombreAmbiente').val(descripcion);    
}  

function CargarFormHorario(idCursoHorario, programa, fechaInicioCurso, fechaFinCurso){
    $('#containerListadoCurso').hide();
    $('#containerRegistroHorario').show();
    $('#txtIdCursoHorario').val(idCursoHorario);        
    if(programa == "Privado"){
        $('#divDatosHorarioPrivado').show();
        $('#divDiaHorario').hide();
    }else{
        $('#divDatosHorarioPrivado').hide();
        $('#divDiaHorario').show();
        $('#txtFechaInicioCurso').val(fechaInicioCurso);  
        $('#txtFechaFinCurso').val(fechaFinCurso);    
    }        
    $('#txtProgramaCursoHorario').val(programa);
    AgregarCabeceraTablaHorario(programa);
    BuscarHorariosCurso(idCursoHorario, programa);
}

function EditarfilaHorario(fila){
    var indice = 0;
    if($('#divDatosHorarioPrivado').is(':visible')){
        $('#txtNumeroSesion').val($('#'+fila).find("td").eq(0).html());
        $('#txtFechaSesion').val($('#'+fila).find("td").eq(1).html());
        indice+=2;
    }else{
        $('#selectorHorarioDia').val($('#'+fila).find("td").eq(indice).html());  
        indice+=1;
    }                                    
    $('#txtHoraInicio').val($('#'+fila).find("td").eq(indice).html());    
    $('#txtHoraFin').val($('#'+fila).find("td").eq(indice+1).html());   
    $('#txtHorarioNombreAmbiente').val($('#'+fila).find("td").eq(indice+2).html());  
    $('#txtHorarioIdAmbiente').val($('#'+fila).find("td").eq(indice+3).html());                                 
    filaHorario = fila;
}


function EliminarfilaHorario(fila){
    var numeroActualSesion = $('#txtNumeroActualSesion').val()-1;
    ActualizarNumeroSesionHorario(numeroActualSesion);
    $('#'+fila).remove();
}

function CrearHorariosSesionesCurso(){
    var cantidadHorarios = 0;
    var listaDeHorarios = [];  
    var listaDeSesiones = [];              
    var idCurso = $('#txtIdCursoHorario').val();        
    var fechaInicioCurso = new Date($('#txtFechaInicioCurso').val());
    var fechaFinCurso = new Date($('#txtFechaFinCurso').val()); 
    var activo = true;             
    var dia = "";
    var programa = "Regular";
    var numSesion = "";
    var sesion = 0;
    var fechaSesion = "";
    var horaInicio = "";
    var horaFin = "";
    var idAmbiente = "";         
    var indice = 0;  
    var dias = ["Domingo","Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"];
    
    $('#tablaHorarios tbody tr').each(function(){
        indice = 0;
        if($('#divDatosHorarioPrivado').is(':visible')){
            programa = "Privado";
            numSesion = $(this).find('td').eq(indice).html(); 
            fechaSesion = $(this).find('td').eq(indice+1).html();                 
            let date = new Date(fechaSesion);
            dia = dias[date.getDay()];
            objSesion = {AsistenciaDocente : 0, FechaSesion : fechaSesion, NumeroSesion : numSesion, IdHorario : 0};
            listaDeSesiones.push(objSesion);                                 
            indice+=1;                
        }                
        else{
            dia = $(this).find('td').eq(indice).html();                                        
        }

        horaInicio = $(this).find('td').eq(indice+1).html();
        horaFin = $(this).find('td').eq(indice+2).html();
        idAmbiente = $(this).find('td').eq(indice+4).html();
        objHorario = { Dia : dia, HoraFin : horaFin, HoraInicio : horaInicio, IdCurso : idCurso, IdAmbiente : idAmbiente};
        listaDeHorarios.push(objHorario); 
        cantidadHorarios++;                        
    });
                         
    fechaInicioCurso.setDate(fechaInicioCurso.getDate()+1);             
    fechaFinCurso.setDate(fechaFinCurso.getDate()+1);   
            

    if(cantidadHorarios!=0){               
            $.ajax({
                type: 'POST',
                url: "/Horario/CrearHorariosRegular",
                contentType: 'application/json; charset=utf-8',
                dataType:"json",            
                data: JSON.stringify(listaDeHorarios),
                success: function (horarios) {
                    if(horarios!=""){                            
                        var indice = 0;
                        if(programa == "Privado"){                                
                            $.each(horarios, function (i, horario){                                    
                                listaDeSesiones[indice].IdHorario = horario.idHorario;
                                indice++;                                                                        
                            });     
                        }else{
                            while(activo){                                
                                $.each(horarios, function (i, horario){
                                    if(fechaInicioCurso <= fechaFinCurso){
                                        if(dias[fechaInicioCurso.getDay()] == horario.dia){
                                            sesion++;
                                            fechaSesion = fechaInicioCurso.getFullYear()+'-'+ ("0"+ (fechaInicioCurso.getMonth() + 1)).slice(-2) +'-'+ ("0"+fechaInicioCurso.getDate()).slice(-2);
                                            objSesion = {AsistenciaDocente : 0, FechaSesion : fechaSesion, NumeroSesion : sesion, IdHorario : horario.idHorario};
                                            listaDeSesiones.push(objSesion);                                      
                                        }                        
                                    }else{
                                        activo = false;
                                    }                
                                });                                                                        
                                fechaInicioCurso.setDate(fechaInicioCurso.getDate()+1);
                            }
                        }                                                    
                        $.ajax({
                            type: 'POST',
                            url: "/Horario/CrearSesion",
                            contentType: 'application/json; charset=utf-8',
                            dataType:"json",            
                            data: JSON.stringify(listaDeSesiones),
                            success: function (respuesta) {
                                if(respuesta == "Guardado"){
                                    swal({
                                        title: "Correcto!",
                                        text: "Horario creado exitosamente.",
                                        icon: "success",
                                        button: "Aceptar",
                                        timer: 2000
                                    }).then(
                                        function () {
                                            if (true) {                                        
                                                LimpiarFormHorario();
                                                SeleccionarCurso(cursoSeleccionado, programa);
                                            }
                                        }
                                    )                                    
                                }                                                                              
                            },
                            error: function () {
                            }            
                        });                                  
                    }
                },
                error: function () {
                }            
            });                        
                                                        
    }else{
        alert("Para Guardar, necesita registrar por lo menos 1 Horario.");
    }          
}


function GuardarHorarios(){
    var id = $('#txtIdCursoHorario').val();
    if($("#btnGuardarHorario").html() == "Editar"){
        $.ajax({
            type: 'POST',
            url: "/Horario/EliminarHorariosCurso",
            data: {
                idCurso: id,                                
            },
            datatype: 'json',
            success: function (response) {
                if(response=="Eliminado")
                    CrearHorariosSesionesCurso();                                                      
            }
        });
    }else{
        CrearHorariosSesionesCurso();
    }
}

function ActualizarNumeroSesionHorario(numero){
    $('#txtNumeroSesion').val(numero);
    $('#txtNumeroActualSesion').val(numero);
}

function BuscarHorariosCurso(id,programa){
    var numSesion = "";
    var fechaSesion = "";    
    if(programa == "Privado"){
        $.ajax({
            type: 'GET',
            url: "/Horario/BuscarSesionesCurso",            
            dataType:"json",            
            data: {
                idCurso : id                
            },
            success: function (sesiones) {                            
                if(sesiones!=""){                                                                        
                    ActualizarNumeroSesionHorario(sesiones.length + 1)                                                 
                    $("#btnGuardarHorario").html('Editar'); 
                    $('#btnGuardarHorario').removeClass('btn-outline-primary');
                    $('#btnGuardarHorario').addClass('btn-outline-warning');                                                        
                    $.each(sesiones, function (i, sesiones){    
                        cont++;                                                                                                                                                                             
                        AgregarFilaTablaHorario(programa, sesiones.numeroSesion, sesiones.fechaSesion, sesiones.horario.dia, sesiones.horario.horaInicio, sesiones.horario.horaFin, 
                            sesiones.horario.ambiente.descripcionAmbiente + " "+ sesiones.horario.ambiente.aula, sesiones.horario.ambiente.idAmbiente,0);                                                                                                                                                                                                                                              
                    });                            
                }else{
                    ActualizarNumeroSesionHorario(1);                            
                    $("#btnGuardarHorario").html('Guardar'); 
                    $('#btnGuardarHorario').removeClass('btn-outline-warning');  
                    $('#btnGuardarHorario').addClass('btn-outline-primary');
                    
                }
                    }
                });   
    }else{
        $.ajax({
            type: 'GET',
            url: "/Horario/BuscarHorariosCurso",            
            dataType:"json",            
            data: {
                idCurso : id                
            },
            success: function (horarios) {                            
                        if(horarios!=""){       
                            var indice = 0;                                                                                                                                
                            $("#btnGuardarHorario").html('Editar'); 
                            $('#btnGuardarHorario').removeClass('btn-outline-primary');
                            $('#btnGuardarHorario').addClass('btn-outline-warning');                                                        
                            $.each(horarios, function (i, horario){      
                                cont++;                                                                                                                                                                                                                   
                                AgregarFilaTablaHorario(programa, numSesion, fechaSesion, horario.dia, horario.horaInicio, horario.horaFin, horario.ambiente.descripcionAmbiente + " "+
                                horario.ambiente.aula, horario.ambiente.idAmbiente,0);                                                                                                                                                                                                                                                            
                            });                                                                                                                                                         
                        }else{                                                            
                            $("#btnGuardarHorario").html('Guardar'); 
                            $('#btnGuardarHorario').removeClass('btn-outline-warning');  
                            $('#btnGuardarHorario').addClass('btn-outline-primary');                                
                        }
                    }
                });
    }        
}

function AgregarCabeceraTablaHorario(programa){
    $('#cabeceraTablaHorarios').html("");
    var columnaNumeroSesion = " ";
    var columnaFechaSesion = " ";
    var columnaDia = "";
    if(programa == "Privado"){
        columnaNumeroSesion = '<th> N° Sesión </th>';
        columnaFechaSesion = '<th> Fecha Sesión </th>';
    }else{
        columnaDia = '<th> Dia </th>';
    }
    $('#cabeceraTablaHorarios').append('<tr>'+         
        columnaNumeroSesion +
        columnaFechaSesion +                       
        columnaDia +
        '<th>Hora Inicio</th>'+
        '<th>Hora Fin</th>'+
        '<th>Ambiente</th>'+
        '<th hidden></th>'+
        '<th></th>'+            
        '</tr>');
}
 
function AgregarFilaTablaHorario(programa, numSesion, fechaSesion, dia, hInicio, hFin, ambiente, idAmbiente, fila){    
        var campoNumeroSesion = "";
        var campoFechaSesion = "";
        var campoDia = "";  
        var numeroSesionSiguiente = parseInt(numSesion,numeroSesionSiguiente) + 1;          
        var id=0;
        if(fila==0){      
            if(programa == "Privado"){
                campoNumeroSesion = '<td>'+numSesion+'</td>';
                campoFechaSesion = '<td>'+fechaSesion.substr(0,10)+'</td>';
                ActualizarNumeroSesionHorario(numeroSesionSiguiente);
            }else{
                campoDia = '<td>'+dia+'</td>';
            }
            $('#contenidoTablaHorarios').append('<tr id="'+cont+'">' +                       
                        campoNumeroSesion + 
                        campoFechaSesion +
                        campoDia +                                              
                        '<td>' + hInicio.substr(0,5) +'</td>' +                        
                        '<td>' + hFin.substr(0,5) +'</td>' +                        
                        '<td>' + ambiente +'</td>' + 
                        '<td hidden>' + idAmbiente +'</td>' +                         
                        '<td> <button onclick="EditarfilaHorario('+cont+')" rel="tooltip" title="Editar"'+
                        '      type="" class="btn btn-warning btn-link btn-sm"><span class="fa fa-edit" style="color:black"></button>'+              
                        '     <button onclick="EliminarfilaHorario('+cont+')" rel="tooltip" title="Eliminar"'+
                        '      class="btn btn-danger btn-link btn-sm"><span class="fa fa-trash" style="color:black"></button></td>'+                       
                        '</tr>');            
        }else{
            if(programa == "Privado"){
                $('#'+fila).find("td").eq(id).html(numSesion);
                $('#'+fila).find("td").eq(id+1).html(fechaSesion);    
                id+=2;
            }else{
                $('#'+fila).find("td").eq(id).html(dia);
                id+=1;    
            }                
            $('#'+fila).find("td").eq(id).html(hInicio);
            $('#'+fila).find("td").eq(id+1).html(hFin);
            $('#'+fila).find("td").eq(id+2).html(ambiente);
            $('#'+fila).find("td").eq(id+3).html(idAmbiente);
            filaHorario = 0;
        }        
        LimpiarFormHorario();
    
    
}

function ValidarCamposHorario(programa){
    var resultado = VerificarCampoVacio("HoraInicio") + VerificarCampoVacio("HoraFin") + VerificarCampoVacio("HorarioNombreAmbiente");
    if(programa == "Privado")
        resultado += VerificarCampoVacio("FechaSesion");
    else
        resultado += VerificarSelectorVacio("HorarioDia");      
    if(resultado > 0)                 
        return "Incorrecto";
    else
        return "Correcto";
}

function AgregarHorario(){
    var dia = $('#formHorario option:selected').val();
    var horaInicio = $('#txtHoraInicio').val();
    var horaFin = $('#txtHoraFin').val();
    var ambiente = $('#txtHorarioNombreAmbiente').val();  
    var idAmbiente = $('#txtHorarioIdAmbiente').val();    
    var numeroSesion = $('#txtNumeroSesion').val();
    var fechaSesion = $('#txtFechaSesion').val();    
    var programa = $('#txtProgramaCursoHorario').val();      
    if(ValidarCamposHorario(programa) == "Correcto"){
        if(filaHorario==0)
            cont++;            
        AgregarFilaTablaHorario(programa, numeroSesion, fechaSesion, dia,horaInicio,horaFin,ambiente,idAmbiente,filaHorario);        
    }        
}
