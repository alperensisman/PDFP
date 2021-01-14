using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programlamadillerifinal
{
    class Pdftohtml
    {
       public static string pdfextract(string konum)
        {
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(konum);

            StringBuilder buffer = new StringBuilder();

            foreach (PdfPageBase page in doc.Pages)
            {
                buffer.Append(page.ExtractText());
            }

            doc.Close();
            return buffer.ToString();
        }
    }
}

