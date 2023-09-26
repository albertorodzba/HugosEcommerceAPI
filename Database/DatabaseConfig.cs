using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace hugosEcommerce_api.Database;

public class DatabaseConfig : IDatabaseConfig
{

    string stringConnection = "server=localhost;user=root;database=hugosecommerce;port=3306;password=Nem02183330156";
    MySqlConnection connection;


    private readonly ILogger<DatabaseConfig> _logger;
    public DatabaseConfig(ILogger<DatabaseConfig> logger)
    {
        this._logger = logger;
    }

    public void OpenConnection()
    {
        try
        {
            connection = new MySqlConnection(stringConnection);

            connection.Open();
            this._logger.LogInformation("Conexion establecida");
        }
        catch (MySqlException exception)
        {
            this._logger.LogInformation("Error al establecer la conexion");
            this._logger.LogError(exception.Message);
        }
    }

    MySqlDataReader reader;
    public MySqlDataReader MysqlExecuteQuery(string mysqlQuery, List<MySqlParameter> parameters)
    {

        try
        {

            MySqlCommand command = new MySqlCommand(mysqlQuery, connection);
            foreach(var parameter in parameters){
                // Console.WriteLine(parameter.ParameterName);
                // Console.WriteLine(parameter.Value);
                command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
            }
            reader = command.ExecuteReader();

            // while (reader.Read())
            // {
            //     this._logger.LogInformation(reader[0]);
            // }    
        }
        catch (MySqlException exception)
        {
            this._logger.LogInformation("Error al mandar la query");
            this._logger.LogError(exception.Message);
        }

        this._logger.LogInformation("Devolviendo el reader");
        return reader;

    }

    public MySqlDataReader MysqlExecuteQuery(string mysqlQuery)
    {

        try
        {

            MySqlCommand command = new MySqlCommand(mysqlQuery, connection);
            reader = command.ExecuteReader();

            // while (reader.Read())
            // {
            //     this._logger.LogInformation(reader[0]);
            // }    
        }
        catch (MySqlException exception)
        {
            this._logger.LogInformation("Error al mandar la query");
            this._logger.LogError(exception.Message);
        }

        this._logger.LogInformation("Devolviendo el reader");
        return reader;

    }

    public void MysqlExecuteNonQuery(string mysqlQuery, List<MySqlParameter> parameters)
    {

        try
        {
            MySqlCommand command = new MySqlCommand(mysqlQuery, connection);
            foreach(var parameter in parameters){
                command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
            }
            command.ExecuteNonQuery();
        }
        catch (MySqlException exception)
        {
            this._logger.LogInformation("Error al mandar la query");
            this._logger.LogError(exception.Message);
        }

        this._logger.LogInformation("NonQuery Command Executed");

    }

    public void CloseAll()
    {
        try
        {
            if (reader != null && connection != null)
            {
                reader.Close();
                connection.Close();
            }
            this._logger.LogInformation("Conexion cerrada");
        }
        catch (MySqlException exception)
        {
            this._logger.LogInformation("Error al cerrar la conexion");
            this._logger.LogError(exception.Message);
        }
    }

}
