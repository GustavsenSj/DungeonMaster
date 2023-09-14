using System.Data;
using System.Data.SqlClient;

namespace DungeonMaster.DB;

public class DatabaseConnection : IDisposable
{
    private SqlConnection _connection;
    private string _connectionString;

    public DatabaseConnection(string connectionString)
    {
        _connectionString = connectionString;
        _connection = new SqlConnection(_connectionString);
    }

    public SqlConnection GetConnection()
    {
        if (_connection.State != ConnectionState.Open)
        {
            _connection.Open();
        }

        return _connection;
    }

    public void Dispose()
    {
        if (_connection != null)
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
            _connection.Dispose();
        }
    }
}