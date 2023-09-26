using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hugosEcommerce_api.Database;
using hugosEcommerce_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace hugosEcommerce_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TablesCreator : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IDatabaseConfig _database;

    //Constructor
    public TablesCreator(
        IDatabaseConfig database,
        ILogger<TablesCreator> logger
    )
    {
        this._database = database;
        this._logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult> GetTables(){
        List<Tablesinfo> tablesCreated;
        try{   

            string query = "SELECT * FROM tablesInfo";
            this._database.OpenConnection();
            var reader = this._database.MysqlExecuteQuery(query);

            tablesCreated = new List<Tablesinfo>();

            while(reader.Read()){
                Tablesinfo table = new Tablesinfo();

                table.PkTablesInfo = Convert.ToInt32(reader[0]);
                table.TableName = reader[1].ToString();;
                table.Columns = reader[2].ToString();
                tablesCreated.Append(table);
            }

            if(tablesCreated == null) return BadRequest("Theres no tables created.");

        }catch(Exception ex){
            return BadRequest(ex);
        }
        return Ok(tablesCreated);
    }

    [HttpPost]
    public async Task<ActionResult> CreateTable(Tablesinfo tableInfo){
        Tablesinfo table = new Tablesinfo();
        

        return Ok();
    }

}
