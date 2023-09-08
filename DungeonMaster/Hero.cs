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
    Dictionary<EquipmentSlot, IEquipment> Equipments { get; set; }
    WeaponsType[] ValidWeaponsTypes { get; set; }
    ArmorType[] ValidArmorTypes { get; set; }
    HeroAttributes Attributes { get; set; }

    public void EquipWeapon(Weapon weapon)
    {
        
        if (ValidWeaponsTypes.Contains(weapon.GetType()) && Level >= weapon.RequiredLevel)
        {
            Equipments[weapon.Slot] = weapon;
        }
    }

    public void EquipArmor(Armor armor)
    {
        if (ValidArmorTypes.Contains(armor.GetArmorType()) && Level >= armor.RequiredLevel)
        {
            Equipments[armor.Slot] = armor;
        }
    }

    int CalculateDamage();
    private int CalculateStrength()
    {
        int fromArmor = 0;
        foreach (Armor armor in Equipments.OfType<Armor>())
        {
            fromArmor += armor.ArmorAttribute.Strength;
        }

        return fromArmor + Attributes.Strength;
    }

    private int CalculateDex()
    {
        int fromArmor = 0;
        foreach (Armor armor in Equipments.OfType<Armor>())
        {
            fromArmor += armor.ArmorAttribute.Dexterity;
        }

        return fromArmor + Attributes.Dexterity;
    }

    private int CalculateInt()
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
        return CalculateStrength() + CalculateInt() + CalculateDex();
    }

    public void PrintHeroDetails()
    {
        Console.WriteLine("Hero Details:");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine("Equipments:");
        foreach (KeyValuePair<EquipmentSlot, IEquipment> equipment in Equipments)
        {
            Console.WriteLine($"- {equipment.Value.Name}");
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