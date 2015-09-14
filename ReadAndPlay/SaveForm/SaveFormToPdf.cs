using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace LookAndPlayForm.SaveForm
{
    public static class SaveFormToPdf
    {
        public static void saveForm1(System.Windows.Forms.Form form2Save)
        {
            using (var bmp = new System.Drawing.Bitmap(form2Save.Width, form2Save.Height))
            {
                form2Save.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(@"C:\Users\Alejandro\Desktop\Images.png");
                Document doc = new Document(PageSize.A4);
                try
                {
                    //doc.Add(new Paragraph("PNG"));
                    iTextSharp.text.Image imageForm = iTextSharp.text.Image.GetInstance(bmp, System.Drawing.Imaging.ImageFormat.Jpeg);
                    PdfWriter.GetInstance(doc, new System.IO.FileStream(@"C:\Users\Alejandro\Desktop\Images.pdf", System.IO.FileMode.Create));
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
