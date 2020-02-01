

/*
 * ELEMENTOS 
 */

let btnInglesNiños = $("#btnInglesNiños");
let btnInglesGeneral = $("#btnInglesGeneral");
let btnExamInter = $("#btnExamInter");
let btnOtrosIdiomas = $("#btnOtrosIdiomas");

let tablaCursosRegular = $("#tablaCursosRegular").DataTable(dataTableConfig);
let contenidoTablaCursosRegular = $("#contenidoTablaCursosRegular");
let tablaDocenteCurso = $("#tablaDocenteCurso").DataTable(dataTableConfig);
let contenidoTablaDocenteCurso = $("#contenidoTablaDocenteCurso");

let programaCurso;
let tipoCurso = {};
let idDocenteSelec;

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
    //Por defecto lista un tipo de curso
    SelecInglesGeneral();
    //form
    txtProgramaCurso.val(programaCurso);
    txtDocenteCurso.prop('disabled', true);
    txtModalidadCurso.prop('disabled', true);
    txtModalidadCurso.val('Grupal');
}

if ($("#ViewCursosPrivados").is(":visible")) {
    programaCurso = 'Privado';
    //Por defecto lista un tipo de curso
    SelecInglesGeneral();
    //form
    txtProgramaCurso.val(programaCurso);
    txtDocenteCurso.prop('disabled', true);
    txtModalidadCurso.prop('disabled', false);
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
        txtIdiomaCurso.val('Ingles');
        txtIdiomaCurso.prop('disabled', true);
    } else {
        labelIdiomaCurso.show();
        txtIdiomaCurso.show();
        txtIdiomaCurso.val('');
        txtIdiomaCurso.prop('disabled', false);
    }
}



/*
 * LISTAR CURSOS
 */

function ListarCursos() {
    let nombreCurso = tipoCurso.nombreCurso;
    let estadoCurso;
    let detalle;
    $.ajax({
        type: "get",
        url: "/Curso/ListarCursos",
        datatype: 'json',
        data: { nombreCurso: nombreCurso, programa: programaCurso },
        success: function (res) {
            console.log(res);
            contenidoTablaCursosRegular.html("");
            if (res != "") {
                tablaCursosRegular.clear().destroy();
                $.each(res, function (i, res) {
                    if (res.estado == 1) { estadoCurso = "Activo"; }
                    if (res.estado == 0) { estadoCurso = "Desactivado"; }
                    if (res.detalle == 0) { detalle = res.detalle; } else { detalle = '-'; }
                    //Botones
                    btnHorario = '<button onclick = "CargarFormHorario(' + res.idCurso + ')" class="btn btn-outline-info"><span class="fa fa-calendar"></button>';
                    btnEditar = '<button onclick = "EditarCurso(' + res.idCurso + ')" class="btn btn-outline-success"><span class="fa fa-pencil"></button>';
                    btnEliminar = '<button onclick = "EliminarCurso(' + res.idCurso + ')" class="btn btn-outline-danger"><span class="fa fa-trash"></button>';
                    //Rellena datos
                    contenidoTablaCursosRegular.append(
                        '<tr>' +
                        '<td>' + res.tipoCurso.nombreCurso + '</td>' +
                        '<td>' + res.idioma + '</td>' +
                        '<td>' + res.nivel + '</td>' +
                        '<td>' + res.ciclo + '</td>' +
                        '<td>' + detalle + '</td>' +
                        '<td>' + res.docente.persona.nombresPersona + ' ' + res.docente.persona.apellidosPersona + '</td>' +
                        '<td>' + res.fechaInicio.substr(0, 10) + ' - ' + res.fechaInicio.substr(0, 10) + '</td>' +
                        '<td>' + estadoCurso + '</td>' +
                        '<td> <div class="form-check-inline">' + btnHorario + btnEditar + btnEliminar + '</div> </td>' +
                        '</tr>');
                });
                tablaCursosRegular = $("#tablaCursosRegular").DataTable(dataTableConfig);
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
                txtDocenteCurso.val(res.persona.nombresPersona + ' ' + res.persona.apellidosPersona);
                idDocenteSelec = id;
                console.log("ID::"+idDocenteSelec);
            }
        }
    });
}



/*
 * REGISTRAR CURSOS
 */


function GuardarCurso() {

    let nuevoCurso = {
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
        url: "/Curso/RegistrarCurso",
        datatype: 'json',
        data: {curso: nuevoCurso},
        success: function (res) {
            if (res == "Registrado") {
                msgExito(res);
            } else {
                msgError(res);
            }
            console.log(res);
        }
    });
}



/*
 * EDITAR CURSOS
 */



/*
 * ELIMINAR CURSOS
 */


























