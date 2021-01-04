using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renova.B64Converter.Activities.Controllers
{
    public class B64Controller
    {


        public string PDFToBase64(string pdfFullPath)
        {
            bool isFileExist = File.Exists(pdfFullPath);
            if (!isFileExist)
            {
                throw new FileNotFoundException("Dönüşüm işlemi yapılacak dosya bulunamadı.");
            }

            Byte[] bytes = File.ReadAllBytes(pdfFullPath);
            string base64Text = Convert.ToBase64String(bytes);

            return base64Text;

        }

        public void Base64ToPDF(string base64Text,string fullPathToExport)
        {
            Byte[] bytes = Convert.FromBase64String(base64Text);
            File.WriteAllBytes(fullPathToExport, bytes);

        }
    }

  
}
