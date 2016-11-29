using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using RecApp_2.Models;
using SysIO = System.IO;
using iTextSharp.text;
using MvcRazorToPdf;
using System.Web.UI;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Xml;
using System.Text;
using iTextSharp.text.pdf.draw;
using System.Net;

namespace RecApp_2.Controllers
{
    public class PdfController : Controller
    {
        private RecordsContext db1 = new RecordsContext();
        public ActionResult Index()
        {

            var model = new TratamientoPaciente
            {
           
            };

            return new PdfActionResult(model);
        }

        [HttpPost]
        public ActionResult SaveTratamientoPacientePdf(TratamientoPaciente tratamientopaciente)
        {
            int idPayment = Convert.ToInt32(TempData["Data1"]);
            //validar el id de pago no sea null
            if (idPayment != 0)
            {
                var _Payment = db1.Payments.ToList().SingleOrDefault(p => p.Id.Equals(idPayment));  //&& p.Estado.Equals(2)
                                                                                                    // Pdf(_Payment);
                _Payment.ListTratamientoXPaciente = (from tpl in db1.TratamientoPaciente.ToList()
                                                     where tpl.IdPayment.Equals(idPayment)
                                                     select tpl).ToList();
                foreach (var item in db1.Tratamiento.ToList())
                {
                    foreach (var item2 in _Payment.ListTratamientoXPaciente)
                    {
                        if (item.id.Equals(item2.IdTratamiento))
                        {
                            item2.Tratamiento = item.Nombre;
                        }

                    }

                }

                var record = db1.Records.ToList().SingleOrDefault(r => r.id.Equals(_Payment.IdRecord));
                _Payment.NombrePaciente = record.Nombre + " " + record.Apellido1 + " " + record.Apellido2;

                return Pdf(_Payment);
            }
            else {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }
        protected string RenderActionResultToString(ActionResult result)
        {
            // Create memory writer.
            var sb = new StringBuilder();
            var memWriter = new SysIO.StringWriter(sb);

            // Create fake http context to render the view.
            var fakeResponse = new HttpResponse(memWriter);
            var fakeContext = new HttpContext(System.Web.HttpContext.Current.Request,
                fakeResponse);
            var fakeControllerContext = new ControllerContext(
                new HttpContextWrapper(fakeContext),
                this.ControllerContext.RouteData,
                this.ControllerContext.Controller);
            var oldContext = System.Web.HttpContext.Current;
            System.Web.HttpContext.Current = fakeContext;

            // Render the view.
            result.ExecuteResult(fakeControllerContext);

            // Restore old context.
            System.Web.HttpContext.Current = oldContext;

            // Flush memory and return output.
            memWriter.Flush();
            return sb.ToString();
        }

        public class BinaryResult : ActionResult
        {
            private byte[] _fileBinary;
            private string _contentType;
            private string _fileName;
            public BinaryResult(byte[] fileBinary, string contentType, string fileName)
            {
                _fileBinary = fileBinary; //gets the binary array to be written  
                _contentType = contentType; //gets the content type of the documet  
                _fileName = fileName; //gets the file name for the document  
            }
            public override void ExecuteResult(ControllerContext context)
            {
                context.HttpContext.Response.Clear(); //clears the buffers  
                context.HttpContext.Response.ContentType = _contentType; // sets the content type for the document  
                context.HttpContext.Response.AddHeader("Content-Disposition", "attachment;filename=" + _fileName); //This allows the file to be downloadable  
                if (_fileBinary != null)
                {
                    context.HttpContext.Response.BinaryWrite(_fileBinary); //returns dynamic made document for download  
                }
            }
        
    }

       
        public ActionResult Pdf(Payment payment)
        {
            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            // Create a new PdfWrite object, writing the output to a MemoryStream  
            var output = new SysIO.MemoryStream();
            var writer = PdfWriter.GetInstance(document, output); //setting an instance of the object to be written  
                                                                  // Open the Document for writing  
            document.Open();
            // First, create our fonts... (For more on working w/fonts in iTextSharp, see: http://www.mikesdotnetting.com/Article/81/iTextSharp-Working-with-Fonts  
            var titleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
            var subTitleFont = FontFactory.GetFont("Arial", 10, Font.BOLD);
            var boldTableFont = FontFactory.GetFont("Arial", 10, Font.BOLD);
            var endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
            var bodyFont = FontFactory.GetFont("Arial", 10, Font.NORMAL);
            //Adding a pragraph to the document  
            document.Add(new Paragraph("Tratamientos Aplicados", titleFont));
            //adding a new ling after the paragraph   
            document.Add(Chunk.NEWLINE);
            //Adding a paragraph to the document  
            document.Add(new Paragraph("Nombre Paciente: "+payment.NombrePaciente, subTitleFont));
            document.Add(Chunk.NEWLINE);
            document.Add(new Paragraph("Detalles", subTitleFont));  
            // Create the transaction details table - see http://www.mikesdotnetting.com/Article/86/iTextSharp-Introducing-Tables for more info  
            var orderInfoTable = new PdfPTable(new float[] { 1.2f, 1.8f, 1.0f});
            orderInfoTable.WidthPercentage = 100; //make the table span the whole document  
            orderInfoTable.HorizontalAlignment = 1; //0 - left aligh, 1 - center, 2 - right align  
            orderInfoTable.SpacingBefore = 5; // spacing before cell  
            orderInfoTable.SpacingAfter = 5; // spaceing after cell  
            orderInfoTable.DefaultCell.Border = 1; // used to add borders to the document  

            //Creating the headers to the that tables  
            orderInfoTable.AddCell(new Phrase("Tratamiento Aplicado", boldTableFont));
            orderInfoTable.AddCell(new Phrase("Observaciones", boldTableFont));
            orderInfoTable.AddCell(new Phrase("Fecha Aplicación", boldTableFont));
            
            //lopping through the list to populate the table with data  
            foreach (var feeItem in payment.ListTratamientoXPaciente)
            {
                orderInfoTable.AddCell(new Phrase(feeItem.Tratamiento.ToString(), bodyFont));
                orderInfoTable.AddCell(new Phrase(feeItem.Observaciones.ToString(), bodyFont));
                orderInfoTable.AddCell(new Phrase(feeItem.FechaTratamiento.ToString(), bodyFont));
            
            }
            //adding all the content to the document object or else nothing will display  
            document.Add(orderInfoTable);

            //Footer    
            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            PdfPCell cell;
            tabFot.TotalWidth = 300F;
            cell = new PdfPCell(new Phrase("Firma paciente:_______________________________ "));
            cell.Border = 0;
            tabFot.AddCell(cell);          
            tabFot.DefaultCell.Border = 1;          
            tabFot.HorizontalAlignment = 0;
            document.Add(Chunk.NEWLINE);
            document.Add(Chunk.NEWLINE);
            document.Add(tabFot);


            // Finally, add an image in the upper right corner  
            var logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Img/logos/Logo_Hilda_Vilchez_300x100.png"));  
            logo.SetAbsolutePosition(300, 730);  
            document.Add(logo);  
            document.Close();           
            //creating the output dynamically  
            return new BinaryResult(output.ToArray(), "application/pdf", "Tratamientos "+payment.NombrePaciente+".pdf");

        }
    }
}
