namespace DungeonMaster;

/// <summary>
/// Thw Wizard class represents a wizard hero class
/// </summary>
public class Wizard : IHero
{
    public string Name { get; set; }
    public int Level { get; set; }
    public Dictionary<EquipmentSlot, IEquipment> Equipments { get; set; }
    public WeaponsType[] ValidWeaponsTypes { get; set; }
    public ArmorType[] ValidArmorTypes { get; set; }
    public HeroAttributes Attributes { get; set; }

    public Wizard(string name)
    {
        Name = name;
        Attributes = new HeroAttributes(1, 1, 8);
        Level = 1;
        ValidWeaponsTypes = new WeaponsType[] { WeaponsType.Staff, WeaponsType.Wand };
        ValidArmorTypes = new ArmorType[] { ArmorType.Cloth };
        Equipments = new Dictionary<EquipmentSlot, IEquipment>();
    }

    public int CalculateDamage()
    {
        int dmgAttribute = Attributes.Intelligence;
        int dmgWeapon = 0;
        IEquipment equipment = Equipments[EquipmentSlot.Weapon];
        if (equipment is Weapon weapon)
        {
            dmgWeapon = weapon.GetDamage();
        }

        return dmgWeapon + dmgAttribute;
    }
}

public class Archer : IHero
{
    public string Name { get; set; }
    public int Level { get; set; }
    public Dictionary<EquipmentSlot, IEquipment> Equipments { get; set; }
    public WeaponsType[] ValidWeaponsTypes { get; set; }
    public ArmorType[] ValidArmorTypes { get; set; }
    public HeroAttributes Attributes { get; set; }

    public Archer(string name)
    {
        Name = name;
        Attributes = new HeroAttributes(1, 7, 1);
        Level = 1;
        ValidWeaponsTypes = new WeaponsType[] { WeaponsType.Bow };
        ValidArmorTypes = new ArmorType[] { ArmorType.Leather, ArmorType.Mail };
        Equipments = new Dictionary<EquipmentSlot, IEquipment>();
    }

    public int CalculateDamage()
    {
        int dmgAttribute = Attributes.Dexterity;
        int dmgWeapon = 0;
        IEquipment equipment = Equipments[EquipmentSlot.Weapon];
        if (equipment is Weapon weapon)
        {
            dmgWeapon = weapon.GetDamage();
        }

        return dmgWeapon + dmgAttribute;
    }
}

public class Swashbuckler : IHero
{
    public string Name { get; set; }
    public int Level { get; set; }
    public Dictionary<EquipmentSlot, IEquipment> Equipments { get; set; }
    public WeaponsType[] ValidWeaponsTypes { get; set; }
    public ArmorType[] ValidArmorTypes { get; set; }
    public HeroAttributes Attributes { get; set; }

    public Swashbuckler(string name)
    {
        Name = name;
        Attributes = new HeroAttributes(2, 6, 1);
        Level = 1;
        ValidWeaponsTypes = new WeaponsType[] { WeaponsType.Dagger, WeaponsType.Sword };
        ValidArmorTypes = new ArmorType[] { ArmorType.Leather, ArmorType.Mail };
        Equipments = new Dictionary<EquipmentSlot, IEquipment>();
    }

    public int CalculateDamage()
    {
        int dmgAttribute = Attributes.Dexterity;
        int dmgWeapon = 0;
        IEquipment equipment = Equipments[EquipmentSlot.Weapon];
        if (equipment is Weapon weapon)
        {
            dmgWeapon = weapon.GetDamage();
        }

        return dmgWeapon + dmgAttribute;
    }
}

public class Barbarian : IHero
{
    public string Name { get; set; }
    public int Level { get; set; }
    public Dictionary<EquipmentSlot, IEquipment> Equipments { get; set; }
    public WeaponsType[] ValidWeaponsTypes { get; set; }
    public ArmorType[] ValidArmorTypes { get; set; }
    public HeroAttributes Attributes { get; set; }

    public Barbarian(string name)
    {
        Name = name;
        Attributes = new HeroAttributes(5, 2, 1);
        Level = 1;
        ValidWeaponsTypes = new WeaponsType[] { WeaponsType.Hatchet, WeaponsType.Mace, WeaponsType.Sword };
        ValidArmorTypes = new ArmorType[] { ArmorType.Mail, ArmorType.Plate };
        Equipments = new Dictionary<EquipmentSlot, IEquipment>();
    }

    public int CalculateDamage()
    {
        int dmgAttribute = Attributes.Strength;
        int dmgWeapon = 0;
        IEquipment equipment = Equipments[EquipmentSlot.Weapon];
        if (equipment is Weapon weapon)
        {
            dmgWeapon = weapon.GetDamage();
        }

        return dmgWeapon + dmgAttribute;
    }
}