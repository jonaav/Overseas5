using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entidades;
using Services.InterfazService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace OverseasWeb.Controllers
{
    public class CalificacionController : Controller
    {
        private readonly IEstudianteService _estudianteService;
        private readonly ICursoService _cursoService;
        private readonly ICalificacionesService _calificacionService;
        private readonly IHostingEnvironment _env;

        public CalificacionController(
            IEstudianteService estudianteService,
            ICursoService cursoService,
            ICalificacionesService calificacionService,
            IHostingEnvironment env
        )
        {
            _estudianteService = estudianteService;
            _cursoService = cursoService;
            _calificacionService = calificacionService;
            _env = env;
        }


        // ADMIN

        #region Admin
        [Authorize(Roles = "Admin")]
        public IActionResult CalificacionAdmin()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ListarCursos()
        {
            List<Curso> cursos = _cursoService.ListarCursosHabiles();
            return Json(cursos);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult ReporteDeNotas(int idEstudiante, int idCurso)
        {

            List<Evaluacion> evaluaciones = _calificacionService.VerNotasDelEstudiantePorCurso(idCurso, idEstudiante);
            HistorialEvaluacion historial = _calificacionService.BuscarHistorial(idCurso, idEstudiante);

            //REPORTE-----
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(85f, 85, 85f, 85f);
            MemoryStream ms = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            doc.Open();

            //salto de linea
            var saltaLinea = new Paragraph("\n");

            //Imagen Cabecera

            Image header = Image.GetInstance(Path.Combine(_env.WebRootPath, "assets/images", "cabecera.png"));
            header.SetAbsolutePosition(0, 770);
            header.ScaleAbsoluteWidth(595);
            header.ScaleAbsoluteHeight(70);


            //titulo

            BaseFont fuente = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, true);
            Font fuenteTitulo = new Font(fuente, 28f, Font.BOLD, new BaseColor(53, 120, 180));
            var titulo = new Paragraph("REPORTE DE NOTAS", fuenteTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            var saludo = new Paragraph("Estimado Alumno(a):");
            saludo.Alignment = Element.ALIGN_LEFT;

            //NOMBRE
            string nombre = historial.Estudiante.Persona.NombresPersona + " " + historial.Estudiante.Persona.ApellidosPersona;
            Font fuenteAlumno = new Font(fuente, 20f, Font.BOLD, new BaseColor(0, 0, 0));
            var alumno = new Paragraph(nombre.ToUpper(),fuenteAlumno);
            alumno.Alignment = Element.ALIGN_CENTER;
            var parrafo = new Paragraph("El presente es para saludarle y a la vez hacer de su conocimiento su puntaje obtenido en su ciclo académico:");
            parrafo.Alignment = Element.ALIGN_JUSTIFIED;
            //IDIOMA Y PERIODO
            string curso = historial.Curso.Idioma + " - " + historial.Curso.Nivel + " " + historial.Curso.Ciclo;
            string periodo = historial.Curso.FechaInicio.ToString("MMMM") + " " + historial.Curso.FechaInicio.Year;
            var tIdiomaPeriodo = (new PdfPTable(new float[] { 50f, 50f }) { WidthPercentage = 100 });

            tIdiomaPeriodo.AddCell(new PdfPCell(new Phrase("Idioma: " + curso)) { Border = 0, HorizontalAlignment =  Element.ALIGN_LEFT});
            tIdiomaPeriodo.AddCell(new PdfPCell(new Phrase("Periodo: " + periodo)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

            //Fin



            //Calculo de celdas - NOTAS
            int nExam = evaluaciones.Count;
            int nCeldas = nExam + 1;
            float medida = 100 / (nExam + 1);
            var cabecera = new float[nCeldas];
            for(int i=0; i<nCeldas; i++)
            {
                cabecera[i] = medida;
            }
            var tabla = (new PdfPTable(cabecera) { WidthPercentage = 100 });
            foreach (Evaluacion e in evaluaciones)
            {
                Font fuenteExam = new Font(fuente, 14f, Font.BOLD, new BaseColor(53, 120, 180));
                tabla.AddCell(new Phrase(e.TipoEvaluacion.NombreEvaluacion, fuenteExam));
            }
            Font fuenteProm = new Font(fuente, 14f, Font.BOLD, new BaseColor(255, 10, 10));
            tabla.AddCell(new Phrase("Promedio", fuenteProm));
            //Agrega notas
            string prom = Convert.ToString(100);
            foreach (Evaluacion e in evaluaciones)
            {
                tabla.AddCell(new Phrase(e.CalificacionEvaluacion.ToString()));
            }
            // Agrega promedio
            tabla.AddCell(new Phrase(historial.CalcularPromedio(evaluaciones).ToString()));
            //Fin


            // FEEDBACK
            string feedback = "Feedback: \n\n" + historial.FeedbackHistorialEvaluacion;
            var tablaFeedback = (new PdfPTable(new float[] { 100f }) { WidthPercentage = 100});
            tablaFeedback.AddCell(new Paragraph(feedback));

            //Fin

            Font fuenteRecordatorio = new Font(fuente, 10f, Font.NORMAL, BaseColor.Black);
            var recordatorio = new Paragraph("Nota: Recuerda que para ingresar al siguiente ciclo debes haber alcanzado el puntaje mínimo de 65 puntos sobre 100 puntos en tu promedio final.",fuenteRecordatorio);
            recordatorio.Alignment = Element.ALIGN_JUSTIFIED;
            var despedida = new Paragraph("Sin otro en particular, quedo de usted");
            despedida.Alignment = Element.ALIGN_JUSTIFIED;
            //Fecha
            string dia = Convert.ToString(DateTime.Today.Day);
            string mes = Convert.ToString(DateTime.Today.ToString("MMMM"));
            string año = Convert.ToString(DateTime.Today.Year);
            var fecha = new Paragraph("Trujillo, "+dia+" de "+mes+" de "+año);
            fecha.Alignment = Element.ALIGN_RIGHT;
            //Fin


            //Firma
            Chunk linea = new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1f, 30f, BaseColor.Black, Element.ALIGN_CENTER, 0f));

            var firma = new Paragraph("FIRMA Y SELLO");
            firma.Alignment = Element.ALIGN_CENTER;

            //Pie de pagina
            Image footer = Image.GetInstance(Path.Combine(_env.WebRootPath, "assets/images", "piepag.png"));
            footer.SetAbsolutePosition(0, 0);
            footer.ScaleAbsoluteWidth(595);
            footer.ScaleAbsoluteHeight(70);


            doc.Add(header);
            doc.Add(titulo);

            doc.Add(saltaLinea);
            doc.Add(saltaLinea);
            doc.Add(saludo);
            doc.Add(saltaLinea);
            doc.Add(alumno);

            doc.Add(saltaLinea);
            doc.Add(parrafo);

            doc.Add(saltaLinea);
            doc.Add(saltaLinea);
            doc.Add(tIdiomaPeriodo);
            doc.Add(saltaLinea);
            doc.Add(saltaLinea);
            doc.Add(tabla);
            doc.Add(saltaLinea);
            doc.Add(saltaLinea);
            doc.Add(tablaFeedback);
            doc.Add(saltaLinea);
            doc.Add(saltaLinea);
            doc.Add(recordatorio);

            doc.Add(saltaLinea);
            doc.Add(despedida);

            doc.Add(saltaLinea);
            doc.Add(saltaLinea);
            doc.Add(fecha);
            doc.Add(saltaLinea);
            doc.Add(saltaLinea);
            doc.Add(linea);
            doc.Add(firma);
            doc.Add(footer);

            writer.Close();
            doc.Close();
            //Guarda el archivo en la memoria RAM
            ms.Seek(0, SeekOrigin.Begin);
            return File(ms, "application/pdf");

        }
               



        #endregion Admin



        // DOCENTE


        #region Docente
        [Authorize(Roles = "Docente")]
        public IActionResult CalificacionDocente()
        {
            return View();
        }

        
        [Authorize(Roles = "Docente")]
        public IActionResult ListarCursosHabilesDelDocente()
        {
            var userInfo = HttpContext.User.Identity;
            List<Curso> cursos = _cursoService.ListarCursosHabilesDelDocente(userInfo.Name);
            if (cursos != null)
                return Json(cursos);
            else
                return Json("");
        }

        
        
        [Authorize(Roles = "Docente")]
        public IActionResult BuscarEvaluacion(int idEvaluacion)
        {
            Evaluacion evaluacion = _calificacionService.BuscarEvaluacion(idEvaluacion);
            if (evaluacion != null)
                return Json(evaluacion);
            else
                return Json("");
        }

        
        [HttpPost]
        [Authorize(Roles = "Docente")]
        public IActionResult EditarEvaluacion(int idEvaluacion, int nota )
        {
            String mensaje = _calificacionService.EditarEvaluacion(idEvaluacion, nota);
            return Json(mensaje);
        }


        
        [Authorize(Roles = "Docente")]
        public IActionResult BuscarHistorial(int idCurso, int idEstudiante)
        {
            HistorialEvaluacion historial = _calificacionService.BuscarHistorial(idCurso, idEstudiante);
            return Json(historial);
        }
        
        
        [HttpPost]
        [Authorize(Roles = "Docente")]
        public IActionResult EditarHistorial(int idCurso, int idEstudiante, string feedback)
        {
            HistorialEvaluacion historial = _calificacionService.BuscarHistorial(idCurso, idEstudiante);
            historial.FeedbackHistorialEvaluacion = feedback;
            String mensaje = _calificacionService.EditarHistorial(historial);
            return Json(mensaje);
        }








        #endregion Docente


        [Authorize]
        public IActionResult VerNotasDelEstudiantePorCurso(int idCurso, int idEstudiante)
        {
            List<Evaluacion> evaluaciones = _calificacionService.VerNotasDelEstudiantePorCurso(idCurso, idEstudiante);
            return Json(evaluaciones);
        }



    }
}