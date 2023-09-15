using System.Data.SqlClient;
using DotNetEnv;
using DungeonMaster.Hero;

namespace DungeonMaster.DB;

public class HeroDataAccessLayer
{
    private readonly DatabaseConnection _dbConnection;

    public HeroDataAccessLayer()
    {
        Env.Load();
        string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? "";

        _dbConnection = new DatabaseConnection(connectionString);
    }


    public void InsertHero(IHero hero)
    {
        try
        {
            using (SqlConnection connection = _dbConnection.GetConnection())
            {
                // Insert hero data
                string heroSql = "INSERT INTO Heroes (Name, Level, ClassName) VALUES (@Name, @Level, @ClassName)";
                using (SqlCommand heroCommand = new SqlCommand(heroSql, connection))
                {
                    heroCommand.Parameters.AddWithValue("@Name", hero.Name);
                    heroCommand.Parameters.AddWithValue("@Level", hero.Level);
                    heroCommand.Parameters.AddWithValue("@ClassName", hero.ClassName);
                    heroCommand.ExecuteNonQuery();
                }

                // Get the ID of the newly inserted hero
                string getIdSql = "SELECT SCOPE_IDENTITY()";
                using (SqlCommand getIdCommand = new SqlCommand(getIdSql, connection))
                {
                    object result = getIdCommand.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        int heroId = Convert.ToInt32(result);
                        Console.WriteLine("Id:" + heroId);

                        // Insert equipment data for the hero
                        foreach (var equipment in hero.Equipments.Values.Where(e => e != null))
                        {
                            Console.WriteLine(equipment);
                            string equipmentSql =
                                "INSERT INTO Equipment (Name, RequiredLevel, Slot, HeroId) VALUES (@Name, @RequiredLevel, @Slot, @HeroId)";
                            using (SqlCommand equipmentCommand = new SqlCommand(equipmentSql, connection))
                            {
                                equipmentCommand.Parameters.AddWithValue("@Name", equipment.Name);
                                equipmentCommand.Parameters.AddWithValue("@RequiredLevel", equipment.RequiredLevel);
                                equipmentCommand.Parameters.AddWithValue("@Slot", (int)equipment.Slot);
                                equipmentCommand.Parameters.AddWithValue("@HeroId", heroId);
                                equipmentCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        // Handle the case where SCOPE_IDENTITY() returns null (no hero was inserted)
                        Console.WriteLine("No hero ID retrieved.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            // Handle the exception as needed
        }
    }
}