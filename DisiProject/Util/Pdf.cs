using System;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace DisiProject.Util
{
    public class Pdf
    {

        public string ReadPdfFile(string filename)
        {
            PdfReader reader2 = new PdfReader(filename);
            string strText = string.Empty;

            for (int page = 1; page <= reader2.NumberOfPages; page++)
            {
                ITextExtractionStrategy its = new SimpleTextExtractionStrategy();
                PdfReader reader = new PdfReader(filename);
                String s = PdfTextExtractor.GetTextFromPage(reader, page, its);

                s = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                strText = strText + s;
                reader.Close();
            }
            return strText;
        }
    }
}