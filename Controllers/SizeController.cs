
using hugosEcommerce_api.Database;
using hugosEcommerce_api.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

using hugosEcommerce_api.Helpers;

namespace hugosEcommerce_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SizeController : ControllerBase
{
    private readonly IDatabaseConfig _databaseConfig;
    private readonly ILogger _logger;
    public SizeController(IDatabaseConfig databaseConfig, ILogger<SizeController> logger)
    {
        this._databaseConfig = databaseConfig;
        this._logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetSizes()
    {
        List<Size> sizes;
        try
        {
            this._databaseConfig.OpenConnection();
            var reader = this._databaseConfig.MysqlExecuteQuery("SELECT * FROM size;");
            sizes = new List<Size>();
            while (reader.Read())
            {
                sizes.Add(new Size { PkSize = Convert.ToInt32(reader[0]), SizeName = reader[1].ToString(), Abbreviation = reader[2].ToString()});
            }
            this._databaseConfig.CloseAll();

            if(sizes == null) return BadRequest("There are not sizes created.");
        }
        catch (Exception ex)
        {
            return BadRequest("Error, notify to admin.");
        }

        return Ok(sizes);
    }


    [HttpPost]
    public async Task<IActionResult> AddSize([FromBody] Size sizeObject)
    {
        Size sizeToStore = new Size
        {
            PkSize = 0,
            SizeName = sizeObject.SizeName,
            Abbreviation = sizeObject.Abbreviation
        };
        try
        {
            this._databaseConfig.OpenConnection();
            string storeQuery = "INSERT INTO Size(size_name, abbreviation) VALUES(@size, @abbreviation);";
            List<MySqlParameter> parameters = new List<MySqlParameter>() {
                new MySqlParameter("@size", sizeToStore.SizeName),
                new MySqlParameter("@abbreviation", sizeToStore.Abbreviation),
            };
            this._databaseConfig.MysqlExecuteNonQuery(storeQuery, parameters);
            this._databaseConfig.CloseAll();

        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok(sizeToStore);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateSize(int id, Size sizeObject)
    {
        Size sizeToUpdate = new Size
        {
            SizeName = sizeObject.SizeName,
            Abbreviation = sizeObject.Abbreviation
        };
        try
        {
            // string storeQuery = $"UPDATE Size SET size_name = \"{sizeToUpdate.SizeName}\" WHERE PK_size = {id};";
            string storeQuery = "UPDATE Size SET size_name = @size, abbreviation = @abbreviation WHERE PK_size = @id;";
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                new MySqlParameter("@size", sizeToUpdate.SizeName),
                new MySqlParameter("@abbreviation", sizeToUpdate.Abbreviation),
                new MySqlParameter("@id", id)
            };
            this._databaseConfig.OpenConnection();
            this._databaseConfig.MysqlExecuteNonQuery(storeQuery, parameters);
            this._databaseConfig.CloseAll();

        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
        this._logger.LogInformation($"New Value updated to {sizeToUpdate.SizeName}");
        return Ok( new {success = true, message = $"Value Changed To { sizeToUpdate.SizeName}  Successfully"});
    }
}
