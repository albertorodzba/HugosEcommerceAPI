using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hugosEcommerce_api.Helpers.FilesValidator;

    public interface IFileValidator
    {
        Boolean IsValid(IFormFile formFile);
    }
