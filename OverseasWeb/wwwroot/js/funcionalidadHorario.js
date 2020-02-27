 let cont = 0;
 let filaHorario = 0;
 /**
  * Datos Utilizar
  */
 let idCursoHorario;
 let idHorarioSesionEdit = 0;
 let fechaInicioCursoHorario;
 let fechaFinCursoHorario;
 let idAmbienteSelecHorario = 0;
 let programaCursoHorario;
 let horarioPermitido = '';


/**
 * Elementos Horario
 * REGULAR
 */
 let dias = ["Domingo","Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"];
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
 
  /**
   * FALTA CAMBIAR, pero ya me dio pereza xd
   */

  function DeshabilitarEdicionHorarios(decision){
      btnGuardarHorario.prop('disabled', decision);
      btnAgregarHorario.prop('disabled', decision);
  }

  function MostrarFormHorario(){
      containerListaCursos.hide();
      containerFormHorario.show();
      LimpiarFormHorario();
  }

  function CargarFormHorario(idCurso, estadoCursoHorario, programa, fechaInicio, fechaFin, tituloCurso){ 
    idCursoHorario = idCurso;
    programaCursoHorario = programa;
    fechaInicioCursoHorario = fechaInicio;
    fechaFinCursoHorario = fechaFin;    
    MostrarFormHorario();    
    AddTituloCursoAlFormHorario(tituloCurso);
    (programa == "Privado") ? ( divDatosHorarioPrivado.show(), divDiaHorario.hide()) :     
                              ( divDiaHorario.show(), divDatosHorarioPrivado.hide());   
    (estadoCursoHorario == 1) ? DeshabilitarEdicionHorarios(false) : DeshabilitarEdicionHorarios(true);                                          
    AgregarCabeceraTablaHorario();    
    BuscarHorariosCurso();
  }
  
  function AgregarCabeceraTablaHorario(){
    let columnasHorario = "";
    cabeceraTablaHorarios.html("");
    (programaCursoHorario == "Privado") ? columnasHorario = '<th> N° Sesión </th> <th> Fecha Sesión </th>' : columnasHorario = '<th> Dia </th>';
    cabeceraTablaHorarios.append('<tr>'+ columnasHorario + '<th>Hora Inicio</th>'+'<th>Hora Fin</th>'+'<th>Ambiente</th>'+'<th hidden></th>'+'<th></th>'+'</tr>');
  }

  function ModificarBotonGuardar(accion, boton){
    let removeColor, addColor;    
    (accion == 'Guardar') ? (removeColor = 'warning', addColor = 'primary') : (removeColor = 'primary', addColor = 'warning')
    boton.html(accion);
    boton.removeClass('btn-outline-'+ removeColor);
    boton.addClass('btn-outline-'+ addColor);
  }

  function BuscarHorariosCurso(){ 
    let accionHorario = "", numSesion = "", fechaSesion = "", horario, id = 0;    
    (programaCursoHorario == 'Regular') ? accionHorario = 'BuscarHorariosCurso' : accionHorario = 'BuscarSesionesCurso';    
    contenidoTablaHorarios.html("");
    $.ajax({
        type: 'GET',
        url: "/Horario/" + accionHorario,            
        dataType:"json",            
        data: {
            idCurso : idCursoHorario               
        },
        success: function (res) {      
            console.log("horarios: ");
            console.log(res);  
            if(programaCursoHorario == 'Privado')  ActualizarNumeroSesionHorario(res.length + 1) ;
            if(res!=""){                                       
                ModificarBotonGuardar('Editar', btnGuardarHorario);                                                       
                $.each(res, function (i, res){                          
                    (accionHorario == 'BuscarSesionesCurso') ? (horario = res.horario, numSesion = res.numeroSesion,
                                                                                       id = res.idSesion,
                                                                                       fechaSesion = res.fechaSesion ) 
                                                             : (horario = res, id = res.idHorario);
                    cont++;
                    console.log('el id es : ' + id);                                                                                                                                                                                                                       
                    AgregarFilaTablaHorario(id ,numSesion, fechaSesion, horario.dia, horario.horaInicio, horario.horaFin, horario.ambiente.descripcionAmbiente + " "+
                    horario.ambiente.aula, horario.ambiente.idAmbiente,0);                                                                                                                                                                                                                                                                             
                });                              
            }else{                
                ModificarBotonGuardar('Guardar', btnGuardarHorario);                    
            }
        }
    });
}

function SalirFormHorario(){
    LimpiarFormHorario();
    ListarCursos();
}

function LimpiarFormHorario(){
    $('#txtNumeroSesion').val($('#txtNumeroActualSesion').val());
    txtFechaSesion.val("");
    selectorDia.val(0);
    txtHoraInicio.val("");
    txtHoraFin.val("");
    idAmbienteSelecHorario = 0;
    txtAmbienteHorario.val("");    
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
        }
    });
}

function CargarModalAmbienteParaHorario(){
    $('#modalBuscarAmbiente').modal("show"); 
    MostrarAmbientesParaHorario();       
}

function AsignarAmbienteAlFormHorario( idAmbiente, descripcion){
    $('#modalBuscarAmbiente').modal("hide");
    idAmbienteSelecHorario = idAmbiente;
    txtAmbienteHorario.val(descripcion);        
}  


function EditarfilaHorario(fila, idHorario){
    let indice = 0;
    console.log('El id es '+ idHorario);
    idHorarioSesionEdit = idHorario;
    if(programaCursoHorario == 'Privado'){
        txtNumeroSesion.val($('#'+fila).find("td").eq(0).html());
        txtFechaSesion.val($('#'+fila).find("td").eq(1).html());
        indice+=2;
    }else{
        selectorDia.val($('#'+fila).find("td").eq(indice).html());  
        indice+=1;
    }                                    
    txtHoraInicio.val($('#'+fila).find("td").eq(indice).html());    
    txtHoraFin.val($('#'+fila).find("td").eq(indice+1).html());   
    txtAmbienteHorario.val($('#'+fila).find("td").eq(indice+2).html());  
    idAmbienteSelecHorario = $('#'+fila).find("td").eq(indice+3).html();
    filaHorario = fila;
}

function EliminarfilaHorario(fila){
    var numeroActualSesion = $('#txtNumeroActualSesion').val()-1;
    ActualizarNumeroSesionHorario(numeroActualSesion);
    $('#'+fila).remove();
}

function CrearHorariosSesionesCurso(){
    let cantidadHorarios = 0;
    let listaDeHorarios = [], listaDeSesiones = [];                   
    let fechaInicioCurso = new Date(fechaInicioCursoHorario);
    let fechaFinCurso = new Date(fechaFinCursoHorario); 
    let fecha, activo = true;             
    let dia = "", numSesion = "", sesion = 0, fechaSesion = "", horaInicio = "", horaFin = "", idAmbiente = "";         
    let indice = 0;      
    
    $('#tablaHorarios tbody tr').each(function(){
        indice = 0;
        if(programaCursoHorario == 'Privado'){            
            numSesion = $(this).find('td').eq(indice).html(); 
            fechaSesion = $(this).find('td').eq(indice+1).html();                 
            fecha = new Date(fechaSesion);
            dia = dias[fecha.getDay()];
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
        objHorario = { Dia : dia, HoraFin : horaFin, HoraInicio : horaInicio, IdCurso : idCursoHorario, IdAmbiente : idAmbiente};
        listaDeHorarios.push(objHorario); 
        cantidadHorarios++;                        
    });

    //Al convertir las fechas en formato Date, estas se reducen en 1 dia, aquí se le vuelve a sumar. 
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
                        indice = 0;                        
                        if(programaCursoHorario == "Privado"){                                
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
                                                SalirFormHorario();
                                            }
                                        }
                                    )                                    
                                }                                                                              
                            }        
                        });                         
                    }
                }            
            });                                                                                
    }else{
        alert("Para Guardar, necesita registrar por lo menos 1 Horario.");
    }          
}

function GuardarHorarios(){    
    if(btnGuardarHorario.html() == "Editar"){
        $.ajax({
            type: 'POST',
            url: "/Horario/EliminarHorariosCurso",
            data: {
                idCurso: idCursoHorario,                                
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

function AgregarFilaTablaHorario(idHorarioSesion, numSesion, fechaSesion, dia, hInicio, hFin, ambiente, idAmbiente, fila){    
    let campoSegunTipoHorario = "", id=0 ;
    var numeroSesionSiguiente = parseInt(numSesion,numeroSesionSiguiente) + 1;
    if(fila==0){      
        (programaCursoHorario == 'Privado') ? ( campoSegunTipoHorario = '<td>'+numSesion+'</td> <td>'+fechaSesion.substr(0,10)+'</td>',
                                                ActualizarNumeroSesionHorario(numeroSesionSiguiente)) 
                                            : campoSegunTipoHorario = '<td>'+dia+'</td>';                            
        contenidoTablaHorarios.append('<tr id="'+cont+'">' +                       
                    campoSegunTipoHorario +                                              
                    '<td>' + hInicio.substr(0,5) +'</td>' +                        
                    '<td>' + hFin.substr(0,5) +'</td>' +                        
                    '<td>' + ambiente +'</td>' + 
                    '<td hidden>' + idAmbiente +'</td>' +                         
                    '<td> <button onclick="EditarfilaHorario('+cont+', '+ idHorarioSesion+')" rel="tooltip" title="Editar"'+
                    '      type="" class="btn btn-warning btn-link btn-sm"><span class="fa fa-edit" style="color:black"></button>'+              
                    '     <button onclick="EliminarfilaHorario('+cont+')" rel="tooltip" title="Eliminar"'+
                    '      class="btn btn-danger btn-link btn-sm"><span class="fa fa-trash" style="color:black"></button></td>'+                       
                    '</tr>');            
    }else{
        if(programaCursoHorario == "Privado"){
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

function ValidarCamposHorario(){
    var resultado = VerificarCampoVacio("HoraInicio") + VerificarCampoVacio("HoraFin") + VerificarCampoVacio("HorarioNombreAmbiente");
    if(programaCursoHorario == "Privado")
        resultado += VerificarCampoVacio("FechaSesion");
    else
        resultado += VerificarSelectorVacio("HorarioDia");      
    if(resultado > 0)                 
        return "Incorrecto";
    else
        return "Correcto";
}


function EsHorarioRegularPermitido(){         
    $.ajax({
        type: 'GET',
        url: "/Horario/VerificarHorario",                                             
        dataType: 'json',  
        data : {
            IdHorario : idHorarioSesionEdit,
            Dia : selectorDia.val(), 
            HoraFin : txtHoraFin.val(), 
            HoraInicio : txtHoraInicio.val(), 
            IdCurso : idCursoHorario, 
            IdAmbiente : idAmbienteSelecHorario
        },
        success: function (decision) { 
            if(decision == 'Correcto'){
                console.log('50 papu');
                AgregarHorario();
            }else{
                console.log('nel prro');
                msgError('Horario no disponible :( ');
            }
        }
    });
    idHorarioSesionEdit = 0;
}


function EsSesionPermitida(){
    let datosSesion = { Horario: {
                            IdHorario : 0,
                            HoraFin : txtHoraFin.val(), 
                            HoraInicio : txtHoraInicio.val(), 
                            IdCurso : idCursoHorario, 
                            IdAmbiente : idAmbienteSelecHorario  
                        },
                        IdSesion : idHorarioSesionEdit,
                        FechaSesion : txtFechaSesion.val()
                    };
    $.ajax({
        type: 'post',
        url: "/Horario/VerificarSesion",                                                  
        dataType: 'json',  
        data : datosSesion,
        success: function (decision) { 
            if(decision == 'Correcto'){
                console.log('50 papu');
                AgregarHorario();
            }else{
                console.log('nel prro');
                msgError('Sesion no disponible :( ');
            }
        }
    });
    idHorarioSesionEdit = 0;
}

function VerificarHorario(){
    if(ValidarCamposHorario() == "Correcto"){ 
        if(programaCursoHorario == 'Regular'){
            EsHorarioRegularPermitido();
        }
        else{
            EsSesionPermitida();
        }
    }
}

function AgregarHorario(){                    
    if(filaHorario==0)
        cont++;            
    AgregarFilaTablaHorario(0, txtNumeroSesion.val(), txtFechaSesion.val(), selectorDia.val(),
                            txtHoraInicio.val(), txtHoraFin.val(), txtAmbienteHorario.val(), idAmbienteSelecHorario, filaHorario);        
        
}


function AddTituloCursoAlFormHorario(titulo){  
    tituloCursoHorario.html("");  
    tituloCursoHorario.html(titulo);
}
