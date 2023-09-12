namespace DungeonMaster.Enemy;

public abstract class EnemyNameGenerator
{
    
private static readonly string[] Adjectives =
        { "Big", "Small", "Fiery", "Angry", "Humble", "Tiered", "Normal" };

    private static readonly string[] WeaponNames =
   {
        "Troll", "Gnome", "Dragon", "Woolf", "Bandit"
    };

    private static readonly Random Random = new Random();

    public static string GenerateRandomEnemyName()
    {
        int adjectiveIndex = Random.Next(Adjectives.Length);
        int weaponIndex = Random.Next(WeaponNames.Length);

        string adjective = Adjectives[adjectiveIndex];
        string weaponName = WeaponNames[weaponIndex];

        return $"{adjective} {weaponName}";
    }}