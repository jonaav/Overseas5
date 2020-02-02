

/*
 * ELEMENTOS 
 */
let btnRegresarRegular = $("#btnRegresarRegular");
let btnRegresarPrivado = $("#btnRegresarPrivado");

let containerCursos;
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

    containerCursos = $("#containerCursosRegulares");
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

    containerCursos = $("#containerCursosPrivados");
    //tabla
    cabeceraDetalleCurso = $("#cabeceraDetalleCursoPrivado");
    tablaCursos = $("#tablaCursosPrivado").DataTable(dataTableConfig);
    contenidoTablaCursos = $("#contenidoTablaCursosPrivado");
    //Por defecto lista un tipo de curso
    SelecInglesGeneral();
}

/*
 * SELECCIONAR CURSOS
 */

function SelecInglesGeneral() {
    BuscarTipoCurso('Inglés General');
    OcultarIdioma(true);
    OcultarDetalle(true);
}


function SelecInglesNiños() {
    BuscarTipoCurso('Inglés Niños');
    OcultarIdioma(true);
    OcultarDetalle(true);
}


function SelecExamInter() {
    BuscarTipoCurso('P. Exam. Internacional');
    OcultarIdioma(false);
    OcultarDetalle(false);
    labelDetalleCurso.html('Tipo de Examen Internacional');
}


function SelecOtrosIdiomas() {
    BuscarTipoCurso('Otros Idiomas');
    OcultarIdioma(false);
    OcultarDetalle(true);
}


//Solo privados
function SelecDomicilio() {
    BuscarTipoCurso('Domicilio');
    OcultarIdioma(false);
    OcultarDetalle(true);
}


function SelecCorporativo() {
    BuscarTipoCurso('Corporativo');
    OcultarIdioma(false);
    OcultarDetalle(false);
    labelDetalleCurso.html('Empresa');
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
    containerCursos.hide();
};


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
                    //Botones
                    btnHorario = '<button onclick = "CargarFormHorario(' + res.idCurso + ')" class="btn btn-outline-info"><span class="fa fa-calendar"></button>';
                    btnEditar = '<button onclick = "EditarCurso(' + res.idCurso + ')" class="btn btn-outline-success btnFormCurso"><span class="fa fa-pencil"></button>';
                    btnEliminar = '<button onclick = "EliminarCurso(' + res.idCurso + ')" class="btn btn-outline-danger"><span class="fa fa-trash"></button>';
                    //Rellena datos
                    contenidoTablaCursos.append(
                        '<tr>' +
                        '<td>' + res.tipoCurso.nombreCurso + '</td>' +
                        '<td>' + res.idioma + '</td>' +
                        '<td>' + res.nivel + '</td>' +
                        '<td>' + res.ciclo + '</td>' +
                        '<td class="contenidoDetalleCurso">' + detalle + '</td>'+
                        '<td>' + res.docente.persona.nombresPersona + ' ' + res.docente.persona.apellidosPersona + '</td>' +
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

    $.ajax({
        type: "post",
        url: "/Curso/"+action,
        datatype: 'json',
        data: {curso: nuevoCurso},
        success: function (res) {
            if (res == "Registrado") {
            } else {
                msgError(res);
            }
            switch (res) {
                case 'Registrado': {
                    msgExito(res);
                    ListarCursos();
                    break;
                }
                case 'Exito': {
                    msgExito(res);
                    ListarCursos();
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
                        msgExito(res);
                        ListarCursos();
                    } else {
                        msgError(res);
                    }
                }
            });
        } else {
            msgCancelado("No se eliminara el idioma");
        }
    });

    
}

























