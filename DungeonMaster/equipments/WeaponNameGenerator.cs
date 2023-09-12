namespace DungeonMaster.equipments;

public static class WeaponNameGenerator
{
    private static readonly string[] Adjectives =
        { "Common", "Big", "Rare", "Small", "Purple", "Fiery", "Mystical", "Legendary", "Ancient", "Frosty" };

    private static readonly string[] WeaponNames =
   {
        "Bow", "Dagger", "Hatchet", "Mace", "Staff", "Sword", "Wand"
    };

    private static readonly Random Random = new Random();

    public static string GenerateRandomWeaponName()
    {
        int adjectiveIndex = Random.Next(Adjectives.Length);
        int weaponIndex = Random.Next(WeaponNames.Length);

        string adjective = Adjectives[adjectiveIndex];
        string weaponName = WeaponNames[weaponIndex];

        return $"{adjective} {weaponName}";
    }
}