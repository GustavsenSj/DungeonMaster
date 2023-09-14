using DungeonMaster;
using DungeonMaster.DB;
using DungeonMaster.Hero;
using DotNetEnv;


GameController gameController = new GameController();

Env.Load();
string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? "";

string testValue = Environment.GetEnvironmentVariable("TEST_VARIABLE");
Console.WriteLine($"Test Variable: {testValue}");

Console.WriteLine("Connection string: "+connectionString);
IHero hero = new HeroFactory().CreateWizard("Sjur");

try
{
    var dal = new HeroDataAccessLayer(connectionString);
    dal.InsertHero(hero);
    Console.WriteLine("HeroSaved");
}
catch (Exception ex)
{
    Console.WriteLine($"Error saving hero: {ex.Message}");
}


// using (DatabaseConnection dbConnection = new DatabaseConnection(connectionString))
// {
//     SqlConnection connection = dbConnection.GetConnection();
// }
// gameController.StartGame();