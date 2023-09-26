using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Storage.V1;

using Google.Apis.Auth.OAuth2;
using hugosEcommerce_api.Utils.Secrets;
using Google;
using System.Security.Cryptography.Xml;
using System.Reflection.Metadata;

namespace hugosEcommerce_api.Services.Storage;

public class GoogleCloudStorageService : IStorageService
{
    public void Authenticate()
    {
        throw new NotImplementedException();
    }

    public void CreateService()
    {

    }

    public string GetDownloadURL()
    {
        throw new NotImplementedException();
    }

    public void ListFiles()
    {
        try
        {
            string GoogleCredentialPath = EnvironmentVariables.GoogleStorageCredentials;
            var credential = GoogleCredential.FromFile(GoogleCredentialPath);
            var client = StorageClient.Create(credential);
            // Make an authenticated API request.
            var objectsInBucket = client.ListObjects("products_hugos");
            foreach (var objectInBucket in objectsInBucket)
            {
                Console.WriteLine(objectInBucket.MediaLink);
            }
        }
        catch (GoogleApiException exception)
        {
            Console.WriteLine(exception);
        }
    }

    /*
    *customIdObject es el nombre personalizado con la cual se recuperara esta imagen
    */
    public string UploadFile(IFormFile file, string customIdObject)
    {
        string objectURL = "";
        try
        {
            string GoogleCredentialPath = EnvironmentVariables.GoogleStorageCredentials;
            var credential = GoogleCredential.FromFile(GoogleCredentialPath);
            var client = StorageClient.Create(credential);
            var fileReader = file.OpenReadStream();
            var stream = new MemoryStream();
            fileReader.CopyTo(stream);
            
            objectURL = client.UploadObject("products_hugos",
                customIdObject,
                file.ContentType,
                new MemoryStream(stream.ToArray())
            ).Id;


            Console.WriteLine("Entro en servicio");
            Console.WriteLine("url objeto");
            Console.WriteLine(objectURL);
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error en servicio");
            Console.WriteLine(exception);
        }
        return objectURL;
    }


}
