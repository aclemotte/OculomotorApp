using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using LookAndPlayForm.Utility;

namespace LookAndPlayForm.SaveForm
{
    public static class SaveForm
    {
        /// <summary>
        /// Guarda el form form2Save en el escritorio como PNG.
        /// </summary>
        /// <param name="form2Save"></param>
        public static void toPng(System.Windows.Forms.Form form2Save)
        {
            using (var bmp = new System.Drawing.Bitmap(form2Save.Width, form2Save.Height))
            {
                form2Save.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(CData.ImagesFolder + @"\" + CData.PNGName);                
            }
        }


        /// <summary>
        /// Guarda el form form2Save en el escritorio como PDF. Tiene problemas porque la imagen en el pdf es muy grande
        /// </summary>
        /// <param name="form2Save"></param>
        public static void toPdf(System.Windows.Forms.Form form2Save)
        {
            using (var bmp = new System.Drawing.Bitmap(form2Save.Width, form2Save.Height))
            {
                Document doc = new Document(PageSize.A4);
                try
                {
                    //doc.Add(new Paragraph("PNG"));
                    iTextSharp.text.Image imageForm = iTextSharp.text.Image.GetInstance(bmp, System.Drawing.Imaging.ImageFormat.Jpeg);
                    PdfWriter.GetInstance(doc, new System.IO.FileStream(CData.ImagesFolder + @"\" + CData.PDFName, System.IO.FileMode.Create));
                    doc.Open();
                    doc.Add(imageForm);
                }

                catch (Exception ex)
                {
                    //Log error;
                }
                finally
                {
                    doc.Close();
                }
            }
        }
    }
}
