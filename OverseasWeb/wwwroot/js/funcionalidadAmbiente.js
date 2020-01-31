
    if($('#tablaAmbiente').is(':visible')){
        ListarAmbientes();
        CargarDireccionOverseas();
        $('#divNombreEmpresa').hide();   
        cambiarTitulo("AMBIENTES");     
    }

    if($('#selectorAmbiente').on('change',function(){
        var ambiente = $('#selectorAmbiente option:selected').val();            
        if(ambiente == "Overseas")
            CargarDireccionOverseas();
        else
            LimpiarDireccion();   
        if(ambiente == "Domicilio")                                
            EstadoSeleccionAula(true);                        
        else
            EstadoSeleccionAula(false);
        if(ambiente == "Empresa")
            $('#divNombreEmpresa').show();
        else
            $('#divNombreEmpresa').hide();
    }));

    function CargarDireccionOverseas(){
        $('#txtDireccionAmbiente').val("Av. Larco 383 B - Segundo Piso");
    }

    function LimpiarDireccion(){
        $('#txtDireccionAmbiente').val("");
    }

    function EstadoSeleccionAula(decision){
        $('#txtAula').val("");
        $('#txtAula').prop('disabled',decision);
    }

    function LimpiarCamposAmbiente(){            
        $('#txtAula').val("");
        $('#txtNombreEmpresa').val("");
        if($('#selectorAmbiente').val() == "Overseas")
            CargarDireccionOverseas();
        else
            $('#txtDireccionAmbiente').val("");

    }

    
    function ValidarCamposVacios(ambiente){
        var mensaje = "Correcto";
        
        if($('#txtDireccionAmbiente').val()=="")
            mensaje = "Campo Vacío. Por favor, ingrese una Dirección para el Ambiente.";
        if(ambiente == "Overseas" && $('#txtAula').val()=="" )
            mensaje = "Campo Vacío. Por favor, ingrese una Aula para el Ambiente.";                   
        if(ambiente == "Empresa"){
            mensaje = "Campo Vacío. Por favor, ingrese el Nombre de la Empresa.";            
        }
            
        return mensaje;
    }

    function ValidarCamposAmbiente(descripcion){
        var resultado = VerificarCampoVacio("DireccionAmbiente");
        if(descripcion!="Domicilio"){
            resultado += VerificarCampoVacio("Aula");
            if(descripcion == "Empresa")
                resultado += VerificarCampoVacio("NombreEmpresa");
        }
        if(resultado > 0)                 
            return "Incorrecto";
        else
            return "Correcto";

    }

    function RegistrarAmbiente(){            
        var descAmbiente =  $('#selectorAmbiente').val();
        var nombreEmpresa = $('#txtNombreEmpresa').val();
        var direccion = $('#txtDireccionAmbiente').val();
        var aula = "Sin Aula";
        var txtAula = "";
        var estado = 1;
        var mensaje;            
        txtAula = $('#txtAula').val();          
        if(ValidarCamposAmbiente(descAmbiente) == "Correcto"){        
            if(txtAula != "")                                                    
                aula = "Aula " + txtAula;       
            if(descAmbiente == "Empresa" && nombreEmpresa !="")
                descAmbiente += " " + nombreEmpresa;                                             
                $.ajax({
                    type: 'POST',
                    url: "/Ambiente/Registrar",
                    data: {
                        Aula: aula,
                        DescripcionAmbiente : descAmbiente,
                        Direccion : direccion,
                        Estado : estado
                    },
                    datatype: 'json',
                    success: function (data) {
                        if(data!=""){
                            swal({
                                title: "Correcto!",
                                text: "Ambiente creado exitosamente.",
                                icon: "success",
                                button: "Aceptar",
                                timer: 2000
                            }).then(
                                function () {
                                    if (true) {
                                        LimpiarCamposAmbiente();
                                        ListarAmbientes();                                        
                                    }
                                }
                            )
                        }
                        else{
                            alert("Campos vacios RCTMRE");
                        }
                        
                    },
                    error: function () {
                    }
                });
        }              
    }

    function EliminarAmbiente(idAmb){        
        swal({
            title: "Mensaje de Confirmacion",
            text: "¿Desea eliminar este Ambiente?",
            icon: "warning",
            buttons: true,
            dangerMode: true
            })
            .then((willDelete) => {
                if(willDelete){                        
                    $.ajax({
                        type: 'POST',
                        url: "/Ambiente/Eliminar",
                        data: {
                            idAmbiente: idAmb,                                
                        },
                        datatype: 'json',
                        success: function (response) {
                            swal({
                                title: "Correcto!",
                                text: "Ambiente eliminado exitosamente.",
                                icon: "success",
                                button: "Aceptar",
                                timer: 2000
                            }).then(
                                function () {
                                    if (true) {
                                        ListarAmbientes();
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
                        button: "Aceptar",
                        timer: 2000
                    })
                }
                
            });
    }

    function ListarAmbientes(){
        var obj;    
        var campoAula;
        var table = $('#tablaAmbiente').DataTable();    
        var id = 0;
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
                        id++;
                        if(obj.aula == "Sin Aula")
                            campoAula = '<td style = "color:red">' + obj.aula + '</td>';
                        else
                            campoAula = '<td>' + obj.aula.substr(4,obj.aula.length)+ '</td>';                            
                        $('#contenidoTablaAmbiente').append('<tr>' +
                        '<td>'+ id +'</td>' +
                        '<td>' + obj.descripcionAmbiente + '</td>' +
                        '<td>' + obj.direccion + '</td>' +
                        campoAula+
                        '<td> <button onclick="EliminarAmbiente('+obj.idAmbiente+')" class="btn btn-outline-danger"><span class="fa fa-trash" style="color:black"></button></td>'+
                        '</tr>');    
                    });
                    table = CrearDatatable("tablaAmbiente");                     
                }                                
            },
            error: function () {
            }
        });
    }    