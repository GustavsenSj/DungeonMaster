using System.Data.SqlClient;
using DungeonMaster.Hero;

namespace DungeonMaster.DB;

public class HeroDataAccessLayer
{
    private readonly DatabaseConnection _dbConnection;

    public HeroDataAccessLayer(string connectionString)
    {
        _dbConnection = new DatabaseConnection(connectionString);
    }

    public void InsertHero(IHero hero)
    {
        using (SqlConnection connection = _dbConnection.GetConnection())
        {
             string sql = "INSERT INTO Heroes (Name, Level, ClassName) VALUES (@Name, @Level, @ClassName)";
             using (SqlCommand command = new SqlCommand(sql, connection))
             {
                 command.Parameters.AddWithValue("@Name", hero.Name);
                 command.Parameters.AddWithValue("@Level", hero.Level);
                 command.Parameters.AddWithValue("@ClassName", hero.ClassName);
                 command.ExecuteNonQuery();
             }
        }
    }
}