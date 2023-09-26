using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hugosEcommerce_api.Database;
using hugosEcommerce_api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using hugosEcommerce_api.Services.Storage;
using hugosEcommerce_api.DTOs;
using hugosEcommerce_api.Helpers.FilesValidator;

namespace hugosEcommerce_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactUsController : ControllerBase
{
    private readonly IDatabaseConfig _db;
    private readonly ILogger _logger;
    private readonly IFileValidator _fileValidator;

    public ContactUsController(
        IDatabaseConfig db, 
        ILogger<ContactUsController> logger,
        IFileValidator fileValidator
    )
    {
        this._db = db;
        this._logger = logger;
        this._fileValidator = fileValidator;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitContactInfo([FromForm] ContactInfoDTO contactInfoDTO)
    {   
        IFormFile file = contactInfoDTO.File;
        string nextCustomId = "";

        if(this._fileValidator.IsValid(contactInfoDTO.File) == false){
            return BadRequest("Formato de archivo inválido");
        }

        try
        {
            // Console.WriteLine(contactInfoDTO.File.FileName);

            //Get the next Id On DATABASE
            string countQuery = "SELECT * FROM contact_info ORDER BY PK_contact_info DESC LIMIT 1;";
            _db.OpenConnection();
            MySql.Data.MySqlClient.MySqlDataReader reader = _db.MysqlExecuteQuery(countQuery);
            while (reader.Read())
            {
                nextCustomId = reader[0].ToString();
            }    
            _db.CloseAll();
            nextCustomId = (Convert.ToInt32(nextCustomId)+1).ToString();
            Console.WriteLine(nextCustomId);

            //UPLOAD IMAGE ON GOOGLE CLOUD STORAGE
            GoogleCloudStorageService googleCloudStorageService = new GoogleCloudStorageService();
            string objectUploadedURL = googleCloudStorageService.UploadFile(contactInfoDTO.File, nextCustomId);
            ContactInfoDTO infoToStore = new ContactInfoDTO
            {
                Name = contactInfoDTO.Name,
                BusinessName = contactInfoDTO.BusinessName,
                Email = contactInfoDTO.Email,
                Phone = contactInfoDTO.Phone,
                Message = contactInfoDTO.Message,
                File = contactInfoDTO.File,
                FileURL = objectUploadedURL,
                CustomIdObject = nextCustomId
            };
            string query = $@"INSERT INTO contact_info VALUES(DEFAULT, ""{infoToStore.Name}"", ""{infoToStore.BusinessName}"", 
            ""{infoToStore.Email}"", ""{infoToStore.Phone}"", ""{infoToStore.Message}"", ""{infoToStore.FileURL}"", ""{infoToStore.CustomIdObject}"", DEFAULT, DEFAULT);";

            _db.OpenConnection();
            // _db.MysqlExecuteNonQuery(query);
            // this._logger.LogInformation(query);
            _db.CloseAll();
        }catch(Exception ex){
            this._db.CloseAll();
            Console.WriteLine("Error en controller");
            return BadRequest(ex);
        }
            return Ok("Saved");
    }
}

/*ESTE CONTROLADOR ARROJA UNA EXCEPTCION DOTNET RUN PARA VERLO*/