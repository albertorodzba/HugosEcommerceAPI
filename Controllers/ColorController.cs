using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hugosEcommerce_api.Database;
using Microsoft.AspNetCore.Mvc;

namespace hugosEcommerce_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ColorController : ControllerBase
{
    private readonly IDatabaseConfig _databaseConfig;
    private readonly ILogger _logger;
    public ColorController(IDatabaseConfig databaseConfig, ILogger<ColorController> logger)
    {
        this._databaseConfig = databaseConfig;
        this._logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetSizes()
    {
        this._databaseConfig.OpenConnection();
        string selectQuery = "SELECT * FROM color;";
        var reader = this._databaseConfig.MysqlExecuteQuery(selectQuery);
        while (reader.Read())
        {
            Console.WriteLine(reader[0] + " = " + reader[1]);
        }
        this._databaseConfig.CloseAll();

        return Ok();
    }


}
