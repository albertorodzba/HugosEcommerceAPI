using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf;

namespace hugosEcommerce_api.Helpers.FilesValidator;

public class FileValidator : IFileValidator
{
    public bool IsValid(IFormFile formFile)
    {   
        string documentType = formFile.ContentType;
        Console.WriteLine(Convert.ToDouble(Convert.ToDouble(formFile.Length)/Convert.ToDouble(1024*1024)));
        double fileSize = Convert.ToDouble(Convert.ToDouble(formFile.Length)/Convert.ToDouble(1024*1024));

        if(fileSize > 10){
            return false;
        }

        if(documentType.Equals("image/jpeg") || 
            documentType.Equals("image/jpeg") ||
            documentType.Equals("image/png") ||
            documentType.Equals("image/tiff") ||
            documentType.Equals("application/pdf") ||
            documentType.Equals("application/vnd.openxmlformats-officedocument.wordprocessingml.document") || 
            documentType.Equals("application/vnd.openxmlformats-officedocument.presentationml.presentation")

        )
        {
            return true;
        }

        return false;
    }
}
