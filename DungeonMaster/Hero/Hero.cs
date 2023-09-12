using DungeonMaster.equipments;
using DungeonMaster.Exceptions;

namespace DungeonMaster.Hero;

/// <summary>
/// Contains the different attributes a hero/player can have  
/// </summary>
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

/// <summary>
/// Hero interface represents the core values needed to create a hero/player
/// </summary>
public interface IHero
{
    string Name { get; set; }
    int Level { get; set; }
    string ClassName { get; set; }
    Dictionary<EquipmentSlot, IEquipment?> Equipments { get; set; }
    WeaponsType[] ValidWeaponsTypes { get; set; }
    ArmorType[] ValidArmorTypes { get; set; }
    HeroAttributes Attributes { get; set; }


    /// <summary>
    /// Equip a weapon to the hero if the hero can use the weapon
    /// </summary>
    /// <param name="weapon"> The weapon to equipped </param>
    public void EquipWeapon(Weapon? weapon)
    {
        if (weapon != null && !ValidWeaponsTypes.Contains(weapon.GetType()))
        {
            throw new InvalidEquipmentTypeException("Invalid armor type");
        }

        if (weapon!= null && Level < weapon.RequiredLevel)
        {
            throw new InsufficientLevelException("Insufficient level to equip the armor");
        }

        if (weapon != null )
        {
            Equipments[weapon.Slot] = weapon;
        }
    }

    /// <summary>
    /// Equip a armor to that armors slot if the hero can use the armor
    /// </summary>
    /// <param name="armor"> armor to be equipped </param>
    public void EquipArmor(Armor? armor)
    {
        if (armor != null && !ValidArmorTypes.Contains(armor.GetArmorType()))
        {
            throw new InvalidEquipmentTypeException("Invalid armor type");
        }

        if (armor != null && Level < armor.RequiredLevel)
        {
            throw new InsufficientLevelException("Insufficient level to equip the armor");
        }

        if (armor != null) Equipments[armor.Slot] = armor;
    }

    /// <summary>
    /// Calculate the Hero's attack damage 
    /// </summary>
    /// <returns> The damage as an int</returns>
    double CalculateDamage();

    /// <summary>
    /// Calculate the hero's total strength with modifiers 
    /// </summary>
    /// <returns>the strength as an int</returns>
    public int CalculateStrength()
    {
        int fromArmor = 0;
        foreach (IEquipment? equipment in Equipments.Values)
        {
            if (equipment is Armor armor)
            {
                fromArmor += armor.ArmorAttribute.Strength;
            }
        }

        return fromArmor + Attributes.Strength;
    }

    /// <summary>
    /// Calculate the hero's total dexterity with modifiers
    /// </summary>
    /// <returns>The dexterity as an int</returns>
    public int CalculateDex()
    {
        int fromArmor = 0;
        foreach (IEquipment? equipment in Equipments.Values)
        {
            if (equipment is Armor armor)
            {
                fromArmor += armor.ArmorAttribute.Dexterity;
            }
        }

        return fromArmor + Attributes.Dexterity;
    }

    /// <summary>
    /// Calculate the hero's total intelligence with modifiers
    /// </summary>
    /// <returns> The Intelligence as an int </returns>
    public int CalculateInt()
    {
        int fromArmor = 0;
        foreach (IEquipment? equipment in Equipments.Values)
        {
            if (equipment is Armor armor)
            {
                fromArmor += armor.ArmorAttribute.Intelligence;
            }
        }

        return fromArmor + Attributes.Intelligence;
    }

    /// <summary>
    ///  Calculate the hero's total attribute score with modifier
    /// </summary>
    /// <returns>total attribute score as an int</returns>
    public int CalculateAttributes()
    {
        return CalculateStrength() + CalculateInt() + CalculateDex();
    }

    /// <summary>
    /// increase the level of a hero by 1 and adjust the stat as so
    /// </summary>
    public void LevelUp();

    /// <summary>
    /// Temp function to print all the stats of th hero.
    /// </summary>
    public void PrintHeroDetails()
    {
        Console.WriteLine("Hero Details:");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Class: {ClassName}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine("Equipments:");
        foreach (KeyValuePair<EquipmentSlot, IEquipment?> equipment in Equipments)
        {
            Console.WriteLine($"- {equipment.Value?.Name}");
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
        Console.WriteLine($"Damage: {CalculateDamage()}");
    }
}