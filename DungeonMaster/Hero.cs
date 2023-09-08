namespace DungeonMaster;

public class HeroAttributes
{
    public int Strength;
    public int Dexterity;
    public int Intelligence;

    public HeroAttributes(int strength, int dexterity, int intelligence)
    {
        Strength = strength;
        Dexterity = dexterity;
        Intelligence = intelligence;
    }

    public void AddToStrength(int toAdd)
    {
        Strength += toAdd;
    }

    public void AddToDex(int toAdd)
    {
        Dexterity += toAdd;
    }

    public void AddToInt(int toAdd)
    {
        Intelligence += toAdd;
    }
}



public interface Hero
{
    string Name { get; set; }
    int Level { get; set; }
    List<IEquipment> Equipments { get; set; }
    WeaponsType[] ValidWeaponsTypes { get; set; }
    ArmorType[] ValidArmorTypes { get; set; }
    HeroAttributes Attributes { get; set; }

    public void EquipWeapon(Weapon weapon)
    {
        if (ValidWeaponsTypes.Contains(weapon.GetType()) && Level >= weapon.RequiredLevel)
        {
            
        }
    }

    private int calculateStrength()
    {
        int fromArmor = 0;
        foreach (Armor armor in Equipments.OfType<Armor>())
        {
            fromArmor += armor.ArmorAttribute.Strength;
        }

        return fromArmor + Attributes.Strength;
    }

    private int calculateDex()
    {
        int fromArmor = 0;
        foreach (Armor armor in Equipments.OfType<Armor>())
        {
            fromArmor += armor.ArmorAttribute.Dexterity;
        }

        return fromArmor + Attributes.Dexterity;
    }

    private int calculateInt()
    {
        int fromArmor = 0;
        foreach (Armor armor in Equipments.OfType<Armor>())
        {
            fromArmor += armor.ArmorAttribute.Intelligence;
        }

        return fromArmor + Attributes.Intelligence;
    }

    public int CalculateAttributes()
    {
        return calculateStrength() + calculateInt() + calculateDex();
    }

    public void PrintHeroDetails()
    {
        Console.WriteLine("Hero Details:");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine("Equipments:");
        foreach (IEquipment equipment in Equipments)
        {
            Console.WriteLine($"- {equipment.Name}");
        }

        Console.WriteLine("Valid Weapons Types:");
        foreach (WeaponsType weaponType in ValidWeaponsTypes)
        {
            Console.WriteLine($"- {weaponType}");
        }

        Console.WriteLine("Valid Armor Types:");
        foreach (ArmorType armorType in ValidArmorTypes)
        {
            Console.WriteLine($"- {armorType}");
        }

        Console.WriteLine("Attributes:");
        Console.WriteLine($"Strength: {Attributes.Strength}");
        Console.WriteLine($"Dexterity: {Attributes.Dexterity}");
        Console.WriteLine($"Intelligence: {Attributes.Intelligence}");
    }
}