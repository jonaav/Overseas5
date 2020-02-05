/**
 * ELEMENTOS
 */

 let txtDireccionAmbiente = $('#txtDireccionAmbiente');
 let txtAula = $('#txtAula');
 let txtNombreEmpresa = $('#txtNombreEmpresa');
 let selectorAmbiente = $('#selectorAmbiente');
 let divNombreEmpresa = $('#divNombreEmpresa');


    if($('#tablaAmbiente').is(':visible')){
        ListarAmbientes();
        CargarDireccionOverseas();
        divNombreEmpresa.hide();   
        cambiarTitulo("AMBIENTES");     
    }

    if(selectorAmbiente.on('change',function(){
        let ambiente = selectorAmbiente.val();
        (ambiente == 'Overseas') ? CargarDireccionOverseas() : LimpiarDireccion();   
        (ambiente == 'Domicilio') ? EstadoSeleccionAula(true) : EstadoSeleccionAula(false);
        (ambiente == 'Empresa') ? divNombreEmpresa.show() : divNombreEmpresa.hide();
    }));

    function CargarDireccionOverseas(){
        txtDireccionAmbiente.val("Av. Larco 383 B - Segundo Piso");
    }

    function LimpiarDireccion(){
        txtDireccionAmbiente.val("");
    }

    function EstadoSeleccionAula(decision){
        txtAula.val("");
        txtAula.prop('disabled',decision);
    }

    function LimpiarCamposAmbiente(){            
        txtAula.val("");
        txtNombreEmpresa.val("");
        (selectorAmbiente.val() == 'Overseas') ? CargarDireccionOverseas() : $('#txtDireccionAmbiente').val("");
    }       

    function ValidarCamposAmbiente(descripcion){
        let resultado = VerificarCampoVacio("DireccionAmbiente");
        if(descripcion=="Overseas"){
            resultado += VerificarCampoVacio("Aula");
            if(descripcion == "Empresa")
                resultado += VerificarCampoVacio("NombreEmpresa");
        }

        return (resultado > 0) ? "Incorrecto" : "Correcto";

    }

    function RegistrarAmbiente(){            
        let descAmbiente =  selectorAmbiente.val();                
        let aula = "Sin Aula";                       
        if(ValidarCamposAmbiente(descAmbiente) == "Correcto"){              
            if(txtAula.val() != "")                                                    
                aula = "Aula " + txtAula.val();       
            if(descAmbiente == "Empresa")
                descAmbiente += " " + txtNombreEmpresa.val();                                             
                $.ajax({
                    type: 'POST',
                    url: "/Ambiente/Registrar",
                    data: {
                        Aula: aula,
                        DescripcionAmbiente : descAmbiente,
                        Direccion : txtDireccionAmbiente.val(),
                        Estado : 1
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
        let table = $('#tablaAmbiente').DataTable();    
        let campoAula, id = 0;                 
        $.ajax({
            type: 'GET',
            url: "/Ambiente/Listar",                                             
            dataType: 'json',  
            success: function (ambientes) {
                $("#contenidoTablaAmbiente").html("");
                table.clear().destroy();
                if(ambientes!=""){                    
                    $.each(ambientes, function (i, ambiente){                                                    
                        id++;
                        (ambiente.aula == 'Sin Aula') ? campoAula = '<td style = "color:red">' + ambiente.aula + '</td>'                        
                                                      : campoAula = '<td>' + ambiente.aula.substr(4,ambiente.aula.length)+ '</td>';                            
                        $('#contenidoTablaAmbiente').append('<tr>' +
                        '<td>'+ id +'</td>' +
                        '<td>' + ambiente.descripcionAmbiente + '</td>' +
                        '<td>' + ambiente.direccion + '</td>' +
                        campoAula+
                        '<td> <button onclick="EliminarAmbiente('+ambiente.idAmbiente+')" class="btn btn-outline-danger"><span class="fa fa-trash" style="color:black"></button></td>'+
                        '</tr>');    
                    });
                    table = CrearDatatable("tablaAmbiente");                     
                }                                
            }            
        });
    }    