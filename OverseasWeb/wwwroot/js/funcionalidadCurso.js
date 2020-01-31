    
    ///////////////////////////////////////////////////////////////////////////
    /////////////// CURSOS  ///////////////////////////////////////////////////

    var cursoSeleccionado = "";
    var programaSeleccionado = "";
    var bandera = 0;
    
    //PARA INICIALIZAR LA VISTA EN EL CURSO INGLÉS PARA NIÑOS

    if ($('#containerPrincipalCursoRegular').is(':visible')) {
        SeleccionarCurso('Inglés Para Niños', 'Regular'); 
        cambiarTitulo("CURSOS REGULARES");              
    }

    if ($('#containerPrincipalCursoPrivado').is(':visible')) {
        SeleccionarCurso('Inglés Para Niños', 'Privado');
        cambiarTitulo("CURSOS PRIVADOS");                      
    }




    //CARGA LA TABLA Y LISTA LOS CURSOS 

    function SeleccionarCurso(curso, programa){        
        $('#cabeceraTablaHorarios').html("");
        $('#contenidoTablaHorarios').html("");        
        filaHorario = 0;
        CargarTablaListarCursos();
        if(curso == "P. Exam. Internacional")
            ListarTablaCursos(curso, programa, "ListarExamenesInternacionales");
        else if(curso == "Corporativo")   
                ListarTablaCursos(curso, programa, "ListarCursosCorporativo");
             else
                ListarTablaCursos(curso, programa, "ListarCursos");
        
    }

    //CAMBIA EL COLOR DEL CARD DEPENDIENDO EL CURSO

    function ActivarColorBoton(boton){
        $('#'+boton).removeClass('btn-outline-primary');
        $('#'+boton).addClass('btn-primary');                        
    }


    function DesactivarColorBoton(boton){
        $('#'+boton).removeClass('btn-primary');
        $('#'+boton).addClass('btn-outline-primary');
        
    }

    function CambiarColorCard(curso){
        if(curso=="Inglés Para Niños"){
            ActivarColorBoton('btnInglesNiños');
            DesactivarColorBoton('btnInglesGeneral');
            DesactivarColorBoton('btnPreExamInter');
            DesactivarColorBoton('btnOtrosIdiomas');
            DesactivarColorBoton('btnDomicilio');
            DesactivarColorBoton('btnCorporativo');                         
        }else if(curso=="Inglés General"){
            DesactivarColorBoton('btnInglesNiños');
            ActivarColorBoton('btnInglesGeneral');
            DesactivarColorBoton('btnPreExamInter');
            DesactivarColorBoton('btnOtrosIdiomas');   
            DesactivarColorBoton('btnDomicilio');
            DesactivarColorBoton('btnCorporativo');           
        }else if(curso=="P. Exam. Internacional"){
            DesactivarColorBoton('btnInglesNiños');
            DesactivarColorBoton('btnInglesGeneral');
            ActivarColorBoton('btnPreExamInter');
            DesactivarColorBoton('btnOtrosIdiomas'); 
            DesactivarColorBoton('btnDomicilio');
            DesactivarColorBoton('btnCorporativo'); 
        }else if(curso=="Otros Idiomas"){
            DesactivarColorBoton('btnInglesNiños');
            DesactivarColorBoton('btnInglesGeneral');
            DesactivarColorBoton('btnPreExamInter');
            ActivarColorBoton('btnOtrosIdiomas');
            DesactivarColorBoton('btnDomicilio'); 
            DesactivarColorBoton('btnCorporativo');
        }else if(curso=="Domicilio"){
            DesactivarColorBoton('btnInglesNiños');
            DesactivarColorBoton('btnInglesGeneral');
            DesactivarColorBoton('btnPreExamInter');
            DesactivarColorBoton('btnOtrosIdiomas');
            ActivarColorBoton('btnDomicilio');       
            DesactivarColorBoton('btnCorporativo');
        }else{
            DesactivarColorBoton('btnInglesNiños');
            DesactivarColorBoton('btnInglesGeneral');
            DesactivarColorBoton('btnPreExamInter');
            DesactivarColorBoton('btnOtrosIdiomas');
            DesactivarColorBoton('btnDomicilio');       
            ActivarColorBoton('btnCorporativo');
        }  
    }

    function ListarTablaCursos(curso, programaCurso, accion){ 
        var campoDocente = "";
        var columnaIdioma = "";
        var campoIdioma = "";
        var columnaTipo = ""
        var columnaEmpresa = "";
        var campoEmpresa = "";
        var campoTipo = "";
        var columnaModalidadEstudiante = "";
        var campoModalidadEstudiante = "";
        var tablaPrograma = "";
        var indice = 0;
        var table;
        if(programaCurso == "Privado")
            tablaPrograma = "tablaCursosPrivado";
        else
            tablaPrograma = "tablaCursosRegular";  
        table = $('#'+tablaPrograma).DataTable();       

        if(curso == "Otros Idiomas" || curso == "Domicilio" || curso == "Corporativo")
            columnaIdioma = '    <th>Idioma</th>';                       
        if(curso == "P. Exam. Internacional")  
            columnaTipo = '    <th>Tipo</th>';
        if(curso == "Corporativo")
            columnaEmpresa = '    <th>Empresa</th>';
        if(programaCurso == "Privado")
            columnaModalidadEstudiante = '    <th>Modalidad</th>';
        CambiarColorCard(curso);
        $.ajax({
            type: 'GET',
            url: "/Curso/"+ accion,     
            data: {
                nombreCurso: curso,
                programa : programaCurso
            },                                                    
            dataType: 'json',  
            success: function (data) {        
                cursoSeleccionado = curso;    
                table.clear().destroy();                       
                $('#nombreCursoSeleccionado').html(curso);                    
                $("#cabeceraTablaCursosRegular").html("");
                $("#contenidoTablaCursosRegular").html(""); 
                
                $('#cabeceraTablaCursosRegular').append(                        
                    '<tr>'+
                    '    <th>N°</th>'+
                    columnaEmpresa +
                    columnaModalidadEstudiante +   
                    columnaTipo +
                    columnaIdioma +                 
                    '    <th>Nivel</th>'+
                    '    <th>Ciclo</th>'+
                    '    <th>Fecha Inicio</th>'+
                    '    <th>Fecha Fin</th>'+
                    '    <th>Docente</th>'+
                    '    <th></th>'+                                         
                    '</tr>')                
                
                if(data!=""){                                                                                                                           
                    $.each(data, function (i, data){
                        infoCurso = data;                        
                        if(curso == "P. Exam. Internacional"){
                            infoCurso = data.curso;
                            campoTipo = '    <td>'+ data.tipoExamenInternacional +'</td>';
                        } 
                        if(curso == "Corporativo"){
                            infoCurso = data.curso;
                            campoEmpresa = '    <td>'+ data.empresaCursoCorporativo +'</td>';                            
                        }
                        if(curso == "Otros Idiomas" || curso == "Domicilio" || curso == "Corporativo" )
                            campoIdioma = '    <td>'+ infoCurso.idioma +'</td>';
                            
                        if(infoCurso.docente.persona.nombresPersona == "Prueba")
                            campoDocente = '    <td style = "color:red"> - Sin Asignar - </td>';                            
                        else
                            campoDocente = '    <td>'+ infoCurso.docente.persona.nombresPersona+'</td>';
                        
                        if(programaCurso == "Privado")
                            campoModalidadEstudiante = '    <td>'+ infoCurso.modalidadEstudiantes +'</td>';
                        indice++;
                        $('#contenidoTablaCursosRegular').append(                                                
                        '<tr>'+
                        '    <td>'+indice+'</td>'+ 
                        campoEmpresa +  
                        campoModalidadEstudiante +
                        campoTipo +                     
                        campoIdioma +                            
                        '    <td>'+ infoCurso.nivel +'</td>'+
                        '    <td>'+ infoCurso.ciclo +'</td>'+
                        '    <td>'+ infoCurso.fechaInicio.substr(0, 10) +'</td>'+
                        '    <td>'+ infoCurso.fechaFin.substr(0, 10) +'</td>'+
                             campoDocente +          
                        '    <td>   '+
                        '           <button rel="tooltip" title="Editar"'+
                        '               onclick="BuscarCurso('+infoCurso.idCurso+','+"'"+infoCurso.nombreCurso+ "'"+' , '+"'"+programaCurso+ "'"+')" class="btn btn-warning btn-link btn-sm"><span class="fa fa-edit" style="color:black"></span></button> '+              
                        '           <button rel="tooltip" title="Eliminar"'+
                        '               onclick="EliminarCurso('+infoCurso.idCurso+', '+"'"+programaCurso+ "'"+')" class="btn btn-danger btn-link btn-sm"><span class="fa fa-trash" style="color:black"></span></button> '+
                        '           <button rel="tooltip" title="Horario"'+
                        '               onclick="CargarFormHorario('+infoCurso.idCurso+', '+"'"+programaCurso+ "'"+', '+"'"+infoCurso.fechaInicio.substr(0, 10)+ "'"+
                                                                    ', '+"'"+infoCurso.fechaFin.substr(0, 10)+ "'"+
                                                                    ')" class="btn btn-secondary btn-link btn-sm"><span class="fa fa-calendar" style="color:black"></span></button></td>'+                        
                        '</tr>');                                                
                    });                                                                                                                                                                                            
                }                              
                table = CrearDatatable(tablaPrograma);                 
            },
            error: function () {
            }
        });           
    }
    
    function InicializarFormCurso(nombreDelCurso, programaCurso){
        $('#txtNombreCurso').val(nombreDelCurso);
        $('#txtPrograma').val(programaCurso);
        if(programaCurso == "Privado")
            $('#divModalidadCurso').show();        
        else
            $('#divModalidadCurso').hide(); 
        if(nombreDelCurso == "P. Exam. Internacional")
            $('#divTipo').show();
        else 
            $('#divTipo').hide();
        if(nombreDelCurso == "Otros Idiomas" || nombreDelCurso == "Domicilio" || nombreDelCurso == "Corporativo"){
            $('#selectorIdioma').prop('disabled', false);
            $('#selectorIdioma').val('0'); 
            if($('#bandera').html() == "0"){
                CargarIdiomas();           
                $('#bandera').html("1");
            }                  
        }else{
            $('#selectorIdioma').prop('disabled', true);            
            $('#selectorIdioma').val('Inglés'); 
        }
        if(nombreDelCurso == "Corporativo")
            $('#divEmpresa').show();       
        else
            $('#divEmpresa').hide();
        LimpiarFormCurso();        
    }    

    function CargarIdiomas(){
        $.ajax({
            type: "get",
            url: "/Especialidad/ListarEspecialidad",
            datatype: 'json',
            success: function (idiomas) {                
                if(idiomas!=""){
                    console.log(idiomas);
                    $.each(idiomas, function (i, idioma) {
                        if(idioma.descripcionEspecialidad != "Inglés"){
                            $('#selectorIdioma').append('<option value="'+idioma.descripcionEspecialidad+'">'+
                            idioma.descripcionEspecialidad+' </option>  ');   
                        }                                                 
                    });
                }
            }
        });
    }
    
    function CargarFormCurso(curso, metodo, programaCurso){
        $('#containerListadoCurso').hide();
        $('#containerRegistroCurso').show();
        $('#divBotones').html('');
        if(metodo == "Guardar"){
            $('#divBotones').append('<button onclick="CrearEditarCursos('+"'CrearCursoRegular',"+')" rel="tooltip" title="Guardar" type="button" class="btn btn-outline-success"><span class="fa fa-save" style="color:black"></button>');            
        }else{
            $('#divBotones').append('<button onclick="CrearEditarCursos('+"'EditarCursoRegular',"+')" rel="tooltip" title="Editar" type="button" class="btn btn-outline-warning"><span class="fa fa-edit" style="color:black"></button>');    
        }
        $('#divBotones').append('  <button onclick="SeleccionarCurso('+"'"+curso+ "'"+' , '+"'"+programaCurso+ "'"+')" rel="tooltip" title="Cancelar"  type="button" class="btn btn-outline-danger"><span class="fa fa-remove" style="color:black"></button>');               
    }


    function CargarTablaListarCursos(){
        $('#containerRegistroCurso').hide();
        $('#containerRegistroHorario').hide();
        $('#containerListadoCurso').show(); 
    }

    $('#btnAgregarCursoRegular').click(function(){        
        var nombreCurso = $('#nombreCursoSeleccionado').html();
        //SE CARGA EL FORM Y OCULTA LA LISTA
        CargarFormCurso(nombreCurso, 'Guardar','Regular');
        //SE ESTABLECE DATOS POR DEFECTO EN EL FORM        
        InicializarFormCurso(nombreCurso, 'Regular');                                
    });

    
    $('#btnAgregarCursoPrivado').click(function(){        
        var nombreCurso = $('#nombreCursoSeleccionado').html();
        CargarFormCurso(nombreCurso,'Guardar','Privado');       
        InicializarFormCurso(nombreCurso, 'Privado');                                
    });


    function CargarModalDocentesParaCurso(){
        $('#modalDocentesUnCurso').modal("show");
        MostrarDocentesParaCurso();
    }

    function MostrarDocentesParaCurso(){
        var indice = 0;
        var table = $('#tablaDocenteUnCurso').DataTable(); 
        $.ajax({
            type: 'GET',
            url: "/Docente/ListarDocentesParaCurso",                                             
            dataType: 'json',  
            success: function (data){
                $("#contenidoTablaDocenteUnCurso").html("");
                table.clear().destroy();
                if(data!=""){
                    obj = data;
                    $.each(obj, function (i, obj){   
                        indice++;                         
                        $('#contenidoTablaDocenteUnCurso').append('<tr>' +
                        '<td>'+indice+'</td>' +
                        '<td>' + obj.persona.nombresPersona + " "+obj.persona.apellidosPersona+ '</td>' +                        
                        '<td> <button type="button" onclick="AsignarDocenteAlFormCurso('+obj.idDocente+','+"'"+obj.persona.nombresPersona+
                               " "+obj.persona.apellidosPersona+ "'"+')" class="btn btn-outline-info btn-sm">Asignar</button></td>'+
                        '</tr>');    
                    });
                    
                    table = CrearDatatable("tablaDocenteUnCurso");                         
                }                                                                            
            },
            error: function () {
            }
        });                
    }

    function AsignarDocenteAlFormCurso( idDocente, nombresDocente){        
        $('#modalDocentesUnCurso').modal("hide");
        $('#txtIdDocente').val(idDocente);
        $('#txtNombreDocente').val(nombresDocente);    
    }   

    //CHECKBOX PARA DOCENTE SIN ASIGNAR /////////////////////////////////////

    function EstablecerCampoSinDocente(){
        $('#txtNombreDocente').val("");
        $('#txtIdDocente').val("");        
    }

    $('#checkBoxDocente').on('change',function(){
        if($(this).is(':checked')){
            EstablecerCampoSinDocente();
            $('#btnBuscarDocenteCurso').prop('disabled',true);
        }else{
            $('#btnBuscarDocenteCurso').prop('disabled',false);
        }
    })

    function LimpiarFormCurso(){
        $('#txtIdCurso').val(""); 
        $('#txtFechaFin').val("");
        $('#txtFechaInicio').val("");
        $('#txtNivel').val("");
        $('#txtCiclo').val("");
        $('#txtNombreEmpresaCurso').val("");
        $('#checkBoxDocente').prop('checked',false);
        $('#btnBuscarDocenteCurso').prop('disabled',false);
        $('#selectorModalidadCurso').val(0);        
        EstablecerCampoSinDocente();
                      
    }

    function ValidarCamposCurso(nombreDeCurso, programaCurso){
        var resultado = VerificarCampoVacio("Nivel") + VerificarCampoVacio("Ciclo") + VerificarCampoVacio("FechaInicio") + VerificarCampoVacio("FechaFin");
        if(programaCurso == "Privado")
            resultado += VerificarSelectorVacio("ModalidadCurso");
        if(nombreDeCurso == "P. Exam. Internacional")
            resultado += VerificarCampoVacio("TipoExamInter");
        else if(nombreDeCurso == "Otros Idiomas" || nombreDeCurso == "Domicilio" || nombreDeCurso == "Corporativo"){
            if(nombreDeCurso == "Corporativo")
                resultado += VerificarCampoVacio("NombreEmpresaCurso");
            resultado += VerificarSelectorVacio("Idioma");
        }
            
        if(resultado > 0)                 
            return "Incorrecto";
        else
            return "Correcto";
        
        
    }

    function CrearEditarCursos(accion){   
        var idCurso = $('#txtIdCurso').val();           
        var fechaFin = $('#txtFechaFin').val();
        var fechaInicio = $('#txtFechaInicio').val();
        var idioma = $('#selectorIdioma').val();
        var nivel = $('#txtNivel').val();
        var ciclo = $('#txtCiclo').val();
        var nombreCurso = $('#txtNombreCurso').val();
        var idDocente = $('#txtIdDocente').val();                  
        var tipoExamenInter = $('#txtTipoExamInter').val();
        var nombreEmpresaCurso = $('#txtNombreEmpresaCurso').val();
        var programa = $('#txtPrograma').val();
        var modalidadEstudiantes = "Grupal"; 
        if(programa == "Privado")
            modalidadEstudiantes = $('#selectorModalidadCurso').val();        
        var estado = 1;        
        var accionAjaxExamInter = "CrearExamenInternacional";
        var accionAjaxCursoCorporativo = "CrearCursoCorporativo";
        if(idDocente=="")
            idDocente = 1;         
        if(ValidarCamposCurso(nombreCurso, programa) == "Correcto"){
            $.ajax({
                type: 'POST',
                url: "/Curso/"+accion,
                data: {
                    IdCurso : idCurso,
                    FechaFin : fechaFin,
                    FechaInicio : fechaInicio,
                    Idioma : idioma,
                    Nivel : nivel,
                    Programa : programa,
                    Estado : estado,                
                    Ciclo : ciclo,
                    ModalidadEstudiantes : modalidadEstudiantes,
                    NombreCurso : nombreCurso,
                    IdDocente : idDocente
                },
                datatype: 'json',
                success: function (data) {
                    if(data!=""){                    
                        if(nombreCurso == "P. Exam. Internacional"){ 
                            if(idCurso!=""){
                                accionAjaxExamInter = "EditarExamenInternacional";
                            }                     
                            $.ajax({
                                type: 'POST',
                                url: "/Curso/"+ accionAjaxExamInter,
                                data: {
                                    IdExamenInternacional : idCurso,
                                    TipoExamenInternacional : tipoExamenInter
                                },
                                datatype: 'json',
                                success: function (data) {                                
                                }
                            });                                                                                                                                           
                        }   
                        if(nombreCurso == "Corporativo"){ 
                            if(idCurso!=""){
                                accionAjaxCursoCorporativo = "EditarCursoCorporativo";
                            }                     
                            $.ajax({
                                type: 'POST',
                                url: "/Curso/"+ accionAjaxCursoCorporativo,
                                data: {
                                    IdCursoCorporativo : idCurso,
                                    EmpresaCursoCorporativo : nombreEmpresaCurso
                                },
                                datatype: 'json',
                                success: function (data) {                                
                                }
                            });                                                                                                                                           
                        }          
    
                        swal({
                            title: "Correcto!",
                            text: "Realizado exitosamente.",
                            icon: "success",                      
                            button: "Aceptar",
                            timer: 2000
                        }).then(
                            function () {
                                if (true) {        
                                    LimpiarFormCurso();                        
                                    SeleccionarCurso(nombreCurso, programa);                                              
                                }
                            }
                        )                                    
                    }
                    else{
                        alert("Campos vacios");
                    }                
                },
                error: function () {
                }
            });
        }                                      
    }


    function BuscarCurso(id, curso, programaCurso){
        var accion = "";        
        CargarFormCurso(curso, 'Editar', programaCurso);        
        if(curso == "P. Exam. Internacional")  
            accion = "BuscarExamenInternacional";
        else if(curso == "Corporativo")
                accion = "BuscarCursoCorporativo";   
             else
                accion = "BuscarCursoRegular";           
        $.ajax({
            type: 'GET',
            url: "/Curso/"+ accion,
            data: {               
                idCurso : id
            },
            datatype: 'json',
            success: function (data) {
                if(data!=""){                    
                    InicializarFormCurso(infoCurso.nombreCurso, programaCurso);
                    infoCurso = data;
                    if(curso == "P. Exam. Internacional"){                        
                        infoCurso = data.curso;
                        $('#txtTipoExamInter').val(data.tipoExamenInternacional);
                    }
                    if(curso == "Corporativo"){
                        infoCurso = data.curso;
                        $('#txtNombreEmpresaCurso').val(data.empresaCursoCorporativo);
                    }                                                                
                    $('#txtIdCurso').val(infoCurso.idCurso);
                    $('#txtFechaFin').val(infoCurso.fechaFin.substr(0, 10));
                    $('#txtFechaInicio').val(infoCurso.fechaInicio.substr(0, 10));                    
                    $('#txtNivel').val(infoCurso.nivel);
                    $('#txtIdioma').val(infoCurso.idioma);
                    $('#txtCiclo').val(infoCurso.ciclo);        
                    $('#txtIdDocente').val(infoCurso.idDocente);
                    if(programaCurso == "Privado")
                        $('#selectorModalidadCurso').val(infoCurso.modalidadEstudiantes);
                    if(infoCurso.docente.persona.nombresPersona == "Prueba"){
                        $('#checkBoxDocente').prop('checked', true);
                        $('#btnBuscarDocenteCurso').prop('disabled',true);
                        EstablecerCampoSinDocente();
                    }                        
                    else{
                        $('#txtNombreDocente').val(infoCurso.docente.persona.nombresPersona + " "+ infoCurso.docente.persona.apellidosPersona);
                    }                        
                }
                else{
                    alert("Campos vacios");
                }                
            },
            error: function () {
            }
        });
    }

    function EliminarCurso(id, programaCurso){
        swal({
            title: "Mensaje de Confirmacion",
            text: "¿Desea eliminar este Curso?",
            icon: "warning",
            buttons: true,
            dangerMode: true
            })
            .then((willDelete) => {
                if(willDelete){                        
                    $.ajax({
                        type: 'POST',
                        url: "/Curso/EliminarCursoRegular",
                        data: {
                            idCurso: id,                                
                        },
                        datatype: 'json',
                        success: function (response) {
                            swal({
                                title: "Correcto!",
                                text: "Curso eliminado exitosamente.",
                                icon: "success",
                                button: "Aceptar",
                                timer: 2000
                            }).then(
                                function () {
                                    if (true) {
                                        SeleccionarCurso(cursoSeleccionado, programaCurso); 
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

    function refrescarPagina(){
        location.reload();
    }    

   

    
    

    

    


   
   
