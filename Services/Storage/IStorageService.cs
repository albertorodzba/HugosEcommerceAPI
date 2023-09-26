using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hugosEcommerce_api.Services.Storage;

    public interface IStorageService
    {
        void Authenticate();
        void CreateService();
        void ListFiles();
        string UploadFile(IFormFile file, string customIdObject);
        string GetDownloadURL();
    }
