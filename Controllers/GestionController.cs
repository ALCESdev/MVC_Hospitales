using MVC_Hospitales.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf.parser;

namespace MVC_Hospitales.Controllers
{
    public class GestionController : Controller
    {
        ModeloHospital modelo = new ModeloHospital();

        public ActionResult EliminarDoc(String id)
        {
            modelo.EliminarDoctores(id);

            return RedirectToAction("VistaDetalles");
        }


        public ActionResult InformeDoctor(String docNo)
        {
            DOCTOR doctor = modelo.GetInfoDoctor(docNo);
            Document docpdf = new Document(PageSize.LETTER);

            String ruta = HttpContext.Server.MapPath("/PDF/");

            ruta = ruta + "informe" + docNo.ToString() + ".pdf";

            if (System.IO.File.Exists(ruta))
            {
                return File(ruta, "application/pdf");
            }
            else
            {
                PdfWriter writer = PdfWriter.GetInstance(docpdf, new FileStream(ruta, FileMode.Create));

                docpdf.AddTitle("Informe del empleado: " + doctor.APELLIDO);
                docpdf.AddCreator("ALCES");

                docpdf.Open();

                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                docpdf.Add(new Paragraph("Informe del empleado: " + doctor.APELLIDO));
                docpdf.Add(new Paragraph(DateTime.Now.ToLongDateString()));

                docpdf.Add(Chunk.NEWLINE);

                PdfPTable tabla = new PdfPTable(3);
                tabla.WidthPercentage = 100;

                PdfPCell colapellido = new PdfPCell(new Phrase("APELLIDO", _standardFont));
                colapellido.BorderWidth = 0;
                colapellido.BorderWidthBottom = 0.75f;

                PdfPCell colespecialidad = new PdfPCell(new Phrase("ESPECIALIDAD", _standardFont));
                colespecialidad.BorderWidth = 0;
                colespecialidad.BorderWidthBottom = 0.75f;

                PdfPCell colsalario = new PdfPCell(new Phrase("SALARIO", _standardFont));
                colsalario.BorderWidth = 0;
                colsalario.BorderWidthBottom = 0.75f;

                tabla.AddCell(colapellido);
                tabla.AddCell(colespecialidad);
                tabla.AddCell(colsalario);

                colapellido = new PdfPCell(new Phrase(doctor.APELLIDO, _standardFont));
                colapellido.BorderWidth = 0;

                colespecialidad = new PdfPCell(new Phrase(doctor.ESPECIALIDAD, _standardFont));
                colespecialidad.BorderWidth = 0;

                colsalario = new PdfPCell(new Phrase(doctor.SALARIO.ToString() + "€", _standardFont));
                colsalario.BorderWidth = 0;

                tabla.AddCell(colapellido);
                tabla.AddCell(colespecialidad);
                tabla.AddCell(colsalario);

                docpdf.Add(tabla);

                docpdf.Close();
                writer.Close();

                return File(ruta, "application/pdf");
            }
        }

        public ActionResult InformePersonal(String empNo)
        {
            PLANTILLA plantilla = modelo.GetInfoPlantilla(empNo);
            Document docpdf = new Document(PageSize.LETTER);

            String ruta = HttpContext.Server.MapPath("/PDF/");

            ruta = ruta + "informe" + empNo.ToString() + ".pdf";

            if (System.IO.File.Exists(ruta))
            {
                return File(ruta, "application/pdf");
            }
            else
            {
                PdfWriter writer = PdfWriter.GetInstance(docpdf, new FileStream(ruta, FileMode.Create));

                docpdf.AddTitle("Informe del empleado: " + plantilla.APELLIDO);
                docpdf.AddCreator("Ejemplo MVC");

                docpdf.Open();

                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                docpdf.Add(new Paragraph("Informe del empleado: " + plantilla.APELLIDO));
                docpdf.Add(new Paragraph(DateTime.Now.ToLongDateString()));

                docpdf.Add(Chunk.NEWLINE);

                PdfPTable tabla = new PdfPTable(4);
                tabla.WidthPercentage = 100;

                PdfPCell colapellido = new PdfPCell(new Phrase("APELLIDO", _standardFont));
                colapellido.BorderWidth = 0;
                colapellido.BorderWidthBottom = 0.75f;

                PdfPCell colfuncion = new PdfPCell(new Phrase("FUNCIÓN", _standardFont));
                colfuncion.BorderWidth = 0;
                colfuncion.BorderWidthBottom = 0.75f;

                PdfPCell colturno = new PdfPCell(new Phrase("TURNO", _standardFont));
                colturno.BorderWidth = 0;
                colturno.BorderWidthBottom = 0.75f;

                PdfPCell colsalario = new PdfPCell(new Phrase("SALARIO", _standardFont));
                colsalario.BorderWidth = 0;
                colsalario.BorderWidthBottom = 0.75f;

                tabla.AddCell(colapellido);
                tabla.AddCell(colfuncion);
                tabla.AddCell(colturno);
                tabla.AddCell(colsalario);

                colapellido = new PdfPCell(new Phrase(plantilla.APELLIDO, _standardFont));
                colapellido.BorderWidth = 0;

                colfuncion = new PdfPCell(new Phrase(plantilla.FUNCION, _standardFont));
                colfuncion.BorderWidth = 0;

                colturno = new PdfPCell(new Phrase(plantilla.T, _standardFont));
                colturno.BorderWidth = 0;

                colsalario = new PdfPCell(new Phrase(plantilla.SALARIO.ToString() + "€", _standardFont));
                colsalario.BorderWidth = 0;

                tabla.AddCell(colapellido);
                tabla.AddCell(colfuncion);
                tabla.AddCell(colturno);
                tabla.AddCell(colsalario);

                docpdf.Add(tabla);

                docpdf.Close();
                writer.Close();

                return File(ruta, "application/pdf");
            }
        }
    }
}