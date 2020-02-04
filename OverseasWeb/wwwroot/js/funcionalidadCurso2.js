
/*
 * ELEMENTOS 
 */
let btnRegresarRegular = $("#btnRegresarRegular");
let btnRegresarPrivado = $("#btnRegresarPrivado");

let containerListaCursos = $("#containerListadoCurso");
let containerFormCurso = $("#containerFormCurso");

let tablaCursos;
let contenidoTablaCursos;
let tablaDocenteCurso = $("#tablaDocenteCurso").DataTable(dataTableConfig);
let contenidoTablaDocenteCurso = $("#contenidoTablaDocenteCurso");

let programaCurso;
let tipoCurso = {};
let idDocenteSelec;
let idCursoEdit = 0;

var cabeceraDetalleCurso;

// FORM

let cursoFormHeader = $("#cursoFormHeader");

let txtProgramaCurso = $("#txtProgramaCurso"); 
let txtIdiomaCurso = $("#txtIdiomaCurso"); 
let txtNivelCurso = $("#txtNivelCurso"); 
let txtCicloCurso = $("#txtCicloCurso"); 
let txtDetalleCurso = $("#txtDetalleCurso"); 
let txtFechaInicioCurso = $("#txtFechaInicioDeCurso"); 
let txtFechaFinCurso = $("#txtFechaFinDeCurso");
let txtModalidadCurso = $("#txtModalidadCurso"); 
let txtDocenteCurso = $("#txtDocenteCurso");

let labelIdiomaCurso = $("#labelIdiomaCurso");
let labelDetalleCurso = $("#labelDetalleCurso");



function LimpiarCamposFormCurso(){
    txtDetalleCurso.val("");
    txtNivelCurso.val("");
    txtCicloCurso.val("");
    txtFechaInicioCurso.val("");
    txtFechaFinCurso.val("");
    txtDocenteCurso.val("");
    idCursoEdit = 0;
    idDocenteSelec = null;
}


/*
 * SELECCIONAR CURSOS
 */

function BuscarTipoCurso(nombreCurso) {
    $.ajax({
        type: "get",
        url: "/Curso/BuscarTipoCurso",
        datatype: 'json',
        data: { nombreCurso },
        success: function (res) {
            console.log(res);
            tipoCurso = res;            
            ListarCursos();
            cursoFormHeader.html(tipoCurso.nombreCurso);
        }
    });
}


/*
 * SELECCIONAR PROGRAMA
 */

if ($("#ViewCursosRegulares").is(":visible")) {
    programaCurso = 'Regular';
    //form
    containerFormCurso.hide();
    btnRegresarPrivado.hide();
    txtProgramaCurso.val(programaCurso);
    txtDocenteCurso.prop('disabled', true);
    txtModalidadCurso.prop('disabled', true);
    txtModalidadCurso.val('Grupal');    
    //tabla
    cabeceraDetalleCurso = $("#cabeceraDetalleCursoRegular");
    tablaCursos = $("#tablaCursosRegular").DataTable(dataTableConfig);
    contenidoTablaCursos = $("#contenidoTablaCursosRegular");
    //Por defecto lista un tipo de curso
    SelecInglesGeneral();
}



if ($("#ViewCursosPrivados").is(":visible")) {
    programaCurso = 'Privado';
    //form
    containerFormCurso.hide();
    btnRegresarRegular.hide();
    txtProgramaCurso.val(programaCurso);
    txtDocenteCurso.prop('disabled', true);
    txtModalidadCurso.prop('disabled', false);    
    //tabla
    cabeceraDetalleCurso = $("#cabeceraDetalleCursoPrivado");
    tablaCursos = $("#tablaCursosPrivado").DataTable(dataTableConfig);
    contenidoTablaCursos = $("#contenidoTablaCursosPrivado");
    //Por defecto lista un tipo de curso
    SelecInglesGeneral();
}

/*
* PINTAR BOTONES DE LOS TIPOS DE CURSOS
*/

function ActivarColorBoton(boton){
    $('#btn'+boton).removeClass('btn-outline-info');
    $('#btn'+boton).addClass('btn-info');                        
}


function DesactivarColorBoton(boton){
    $('#btn'+boton).removeClass('btn-info');
    $('#btn'+boton).addClass('btn-outline-info');
    
}


function PintarBotonTipoCurso(nombreCurso){
    let tipoCursos = ['InglesGeneral', 'InglesNiños', 'ExamInter', 'OtrosIdiomas', 'Domicilio', 'Corporativo'];    
    ActivarColorBoton(nombreCurso);
    for(let i=0; i<tipoCursos.length; i++){        
        if(nombreCurso != tipoCursos[i])                    
            DesactivarColorBoton(tipoCursos[i]);                
    }
}

/*
 * SELECCIONAR CURSOS
 */

function SelecInglesGeneral() {
    BuscarTipoCurso('Inglés General');
    OcultarIdioma(true);
    OcultarDetalle(true);
    PintarBotonTipoCurso('InglesGeneral');    
}


function SelecInglesNiños() {
    BuscarTipoCurso('Inglés Niños');
    OcultarIdioma(true);
    OcultarDetalle(true);
    PintarBotonTipoCurso('InglesNiños');
    
}


function SelecExamInter() {
    BuscarTipoCurso('P. Exam. Internacional');
    OcultarIdioma(false);
    OcultarDetalle(false);
    labelDetalleCurso.html('Tipo de Examen Internacional');
    PintarBotonTipoCurso('ExamInter');
}


function SelecOtrosIdiomas() {
    BuscarTipoCurso('Otros Idiomas');
    OcultarIdioma(false);
    OcultarDetalle(true);
    PintarBotonTipoCurso('OtrosIdiomas');
}


//Solo privados
function SelecDomicilio() {
    BuscarTipoCurso('Domicilio');
    OcultarIdioma(false);
    OcultarDetalle(true);
    PintarBotonTipoCurso('Domicilio');
}


function SelecCorporativo() {
    BuscarTipoCurso('Corporativo');
    OcultarIdioma(false);
    OcultarDetalle(false);
    labelDetalleCurso.html('Empresa');
    PintarBotonTipoCurso('Corporativo');
}

/*
 * OCULTAR O MOSTRAR DETALLE
 */

function OcultarDetalle(oculto) {
    //Se muestra cuando el curso es Exm Internacional o Corporativo
    if (oculto) {
        labelDetalleCurso.hide();
        txtDetalleCurso.hide();
        txtDetalleCurso.prop('disabled', true);
    } else {
        labelDetalleCurso.show();
        txtDetalleCurso.show();
        txtDetalleCurso.prop('disabled', false);
    }
}


/*
 * OCULTAR O MOSTRAR IDIOMA
 */

function OcultarIdioma(oculto) {
    //Se oculta cuando el nombre de curso es Ingles Niños o Ingles General
    if (oculto) {
        labelIdiomaCurso.hide();
        txtIdiomaCurso.hide();
        ListarIdiomasCurso();
        txtIdiomaCurso.prop('disabled', true);
    } else {
        labelIdiomaCurso.show();
        txtIdiomaCurso.show();
        ListarIdiomasCurso();
        txtIdiomaCurso.prop('disabled', false);
    }
}

/*
 * OCULTAR O MOSTRAR FORM CURSO
 */

function MostrarFormCurso() {
    containerFormCurso.show();
    containerListaCursos.hide();    
};

function MostrarTablaListaCursos(){
    containerFormCurso.hide();
    containerListaCursos.show();
    LimpiarCamposFormCurso();                        
}

function ModificarCabeceraDetalle() {
    cabeceraDetalleCurso.hide();
    $('.contenidoDetalleCurso').hide();
    if (tipoCurso.nombreCurso == "P. Exam. Internacional") {
        cabeceraDetalleCurso.html('Tipo de Examen');
        cabeceraDetalleCurso.show();
        $('.contenidoDetalleCurso').show();
    }
    if (tipoCurso.nombreCurso == "Corporativo") {
        cabeceraDetalleCurso.html('Empresa');
        cabeceraDetalleCurso.show();
        $('.contenidoDetalleCurso').show();
    }
}

/*
 * LISTAR CURSOS
 */

function ListarCursos() {    
    let nombreCurso = tipoCurso.nombreCurso;
    let estadoCurso;
    let detalle = '-';
    let nombreDocente = '<td class="sinAsignar">-Sin asignar-</td>';
    MostrarTablaListaCursos();
    $.ajax({
        type: "get",
        url: "/Curso/ListarCursos",
        datatype: 'json',
        data: { nombreCurso: nombreCurso, programa: programaCurso },
        success: function (res) {
            console.log(res);
            contenidoTablaCursos.html("");
            if (res != "") {
                tablaCursos.clear().destroy();
                $.each(res, function (i, res) {
                    if (res.estado == 1) { estadoCurso = "Activo"; }
                    if (res.estado == 0) { estadoCurso = "Desactivado"; }
                    if (res.detalle != null) { detalle = res.detalle; }
                    if (res.docente != null) { nombreDocente = '<td>' + res.docente.persona.nombresPersona + ' ' + res.docente.persona.apellidosPersona + '</td>' }
                    else { nombreDocente = '<td class="sinAsignar">-Sin asignar-</td>'; }
                    //Botones
                    btnHorario = '<button rel="tooltip" title="Ver Horario" onclick = "CargarFormHorario(' + res.idCurso + ')" class="btn btn-outline-info"><span class="fa fa-calendar"></button>';
                    btnEditar = '<button rel="tooltip" title="Editar" onclick = "EditarCurso(' + res.idCurso + ')" class="btn btn-outline-success btnFormCurso"><span class="fa fa-pencil"></button>';
                    btnEliminar = '<button rel="tooltip" title="Eliminar" onclick = "EliminarCurso(' + res.idCurso + ')" class="btn btn-outline-danger"><span class="fa fa-trash"></button>';
                    //Rellena datos
                    contenidoTablaCursos.append(
                        '<tr>' +   
                        '<td>' + res.idioma + '</td>' +
                        '<td>' + res.nivel + '</td>' +
                        '<td>' + res.ciclo + '</td>' +
                        '<td class="contenidoDetalleCurso">' + detalle + '</td>'+
                        nombreDocente+
                        '<td>' + res.fechaInicio.substr(0, 10) + ' / ' + res.fechaFin.substr(0, 10) + '</td>' +
                        '<td>' + estadoCurso + '</td>' +
                        '<td> <div class="form-check-inline">' + btnHorario + btnEditar + btnEliminar + '</div> </td>' +
                        '</tr>');
                });
                ModificarCabeceraDetalle();
                if (programaCurso == 'Regular')
                    tablaCursos = $("#tablaCursosRegular").DataTable(dataTableConfig);
                else
                    tablaCursos = $("#tablaCursosPrivado").DataTable(dataTableConfig);

            } 
        }
    });
}

/*
 * RELLENAR SELECT IDIOMAS
 */

function ListarIdiomasCurso() {
    $.ajax({
        type: "get",
        url: "/Especialidad/ListarEspecialidad",
        datatype: 'json',
        success: function (res) {
            console.log("IDIOMAS--");
            console.log(res);
            if (res != "") {
                txtIdiomaCurso.html("");
                $.each(res, function (i, res) {
                    //Rellena datos
                    if (res.descripcionEspecialidad == 'Inglés') {
                        txtIdiomaCurso.append(
                            '<option selected value="' + res.descripcionEspecialidad + '">' + res.descripcionEspecialidad + '</option>');
                    } else {
                        txtIdiomaCurso.append(
                            '<option value="' + res.descripcionEspecialidad + '">' + res.descripcionEspecialidad + '</option>');
                    }
                    console.log(txtIdiomaCurso.val());
                });
            }
        }
    });
}

/*
 * BUSCAR DOCENTES
 */

function ListarDocentesActivos() {
    let btnAgregar = "";
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
                    //Botones
                    btnAgregar = '<button onclick = "AgregarDocenteCurso(' + res.idDocente + ')" class="btn btn-outline-info" data-dismiss="modal"><span class="fa fa-plus"></button>';
                    //Rellena datos
                    contenidoTablaDocenteCurso.append(
                        '<tr>' +
                        '<td>' + res.persona.dniPersona + '</td>' +
                        '<td>' + res.persona.nombresPersona + ' ' + res.persona.apellidosPersona  + '</td>' +
                        '<td> <div class="form-check-inline">' + btnAgregar + '</div> </td>' +
                        '</tr>');
                });
                tablaDocenteCurso = $("#tablaDocenteCurso").DataTable(dataTableConfig);
            }
        }
    });
}


/*
 * SELECCIONAR DOCENTE
 */

function AgregarDocenteCurso(id) {
    $.ajax({
        type: "get",
        url: "/Curso/BuscarDocentePorID",
        datatype: 'json',
        data: { idDocente: id },
        success: function (res) {
            console.log(res);
            if (res != "") {
                //Rellena campo docente
                txtDocenteCurso.val(res.persona.nombresPersona + ' ' + res.persona.apellidosPersona);
                idDocenteSelec = id;
                console.log("ID::"+idDocenteSelec);
            }
        }
    });
}
/*
 * BUSCAR CURSO
 */

function BuscarCurso(id) {
    $.ajax({
        type: "get",
        url: "/Curso/BuscarCursoPorID",
        datatype: 'json',
        data: { idCurso: idCursoEdit },
        success: function (res) {
            console.log(res);
            if (res != "") {
                txtProgramaCurso.val(res.programa);
                txtIdiomaCurso.val(res.idioma);
                txtNivelCurso.val(res.nivel);
                txtCicloCurso.val(res.ciclo);
                txtFechaInicioCurso.val(res.fechaInicio.substr(0,10));
                txtFechaFinCurso.val(res.fechaFin.substr(0,10));
                txtModalidadCurso.val(res.modalidadEstudiantes);
                txtDetalleCurso.val(res.detalle);
                txtDocenteCurso.val(res.docente.persona.nombresPersona + ' ' + res.docente.persona.apellidosPersona);
                idDocenteSelec = res.idDocente;
            }
        }
    });
}



/*
 * GUARDAR CURSOS
 */

function EditarCurso(id) {
    idCursoEdit = id;
    BuscarCurso(id);
    MostrarFormCurso();
}

function GuardarCurso() {
    let action;
    //Seleccionar Action
    (idCursoEdit == 0) ? action = "RegistrarCurso" : action = "EditarCurso";

    let nuevoCurso = {
        IdCurso: idCursoEdit,
        Programa: programaCurso,
        Idioma: txtIdiomaCurso.val(),
        Nivel: txtNivelCurso.val(),
        Ciclo: txtCicloCurso.val(),
        FechaInicio: txtFechaInicioCurso.val(),
        FechaFin: txtFechaFinCurso.val(),
        ModalidadEstudiantes: txtModalidadCurso.val(),
        Detalle: txtDetalleCurso.val(),
        Estado: 1,
        IdTipoCurso: tipoCurso.idTipoCurso,
        IdDocente: idDocenteSelec
    };
    console.log('nuevoCurso');
    console.log(nuevoCurso);

    if (VerificarCamposVaciosCurso() == 0) {
        $.ajax({
            type: "post",
            url: "/Curso/" + action,
            datatype: 'json',
            data: { curso: nuevoCurso },
            success: function (res) {
                switch (res) {
                    case 'Registrado': {
                        msgExitoCurso(res);                        
                        break;
                    }
                    case 'Exito': {
                        msgExitoCurso(res);                        
                        break;
                    }
                    default: {
                        msgError(res);
                    }
                }
                console.log(res);
            }
        });
    }
    
}




/*
 * ELIMINAR CURSOS
 */


function EliminarCurso(id) {
    swal({
        title: "Advertencia",
        text: "¿Desea eliminar este Curso?",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((eliminar) => {

        if (eliminar) {
            $.ajax({
                type: "post",
                url: "/Curso/EliminarCurso",
                datatype: 'json',
                data: { idCurso: id },
                success: function (res) {
                    console.log(res);
                    if (res == 'Eliminado') {
                        msgExitoCurso(res);                        
                    } else {
                        msgError(res);
                    }
                }
            });
        } else {
            msgCancelado("No se eliminara el Curso");
        }
    });

    
}



/* 
 * VERIFICAR CAMPOS VACIOS 
 */

function VerificarCamposVaciosCurso() {
    let valido = 
        VerificarCampoVacio("IdiomaCurso") +
        VerificarCampoVacio("NivelCurso") +
        VerificarCampoVacio("CicloCurso") +
        VerificarCampoVacio("FechaInicioDeCurso") +
        VerificarCampoVacio("FechaFinDeCurso") +
        VerificarCampoVacio("ModalidadCurso");
    let detalleValido = 0;
    if (tipoCurso.nombreCurso == 'P. Exam. Internacional' || tipoCurso.nombreCurso == 'Corporativo') {
        detalleValido = VerificarCampoVacio("DetalleCurso");
    }

    console.log("RETURN");
    console.log(valido);
    return valido + detalleValido;
}


























