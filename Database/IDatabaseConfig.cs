
using MySql.Data.MySqlClient;

namespace hugosEcommerce_api.Database
{
    public interface IDatabaseConfig
    {
        void OpenConnection();
        
        MySql.Data.MySqlClient.MySqlDataReader  MysqlExecuteQuery(string mysqlQuery, List<MySqlParameter> parameters);
        MySql.Data.MySqlClient.MySqlDataReader  MysqlExecuteQuery(string mysqlQuery);
        void  MysqlExecuteNonQuery(string mysqlQuery, List<MySqlParameter> parameters);

        void CloseAll();
    }
}