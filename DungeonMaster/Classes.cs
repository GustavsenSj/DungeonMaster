namespace DungeonMaster;

public class Wizard : Hero
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
        int dmgWeapon = Equipments.OfType<Weapon>().FirstOrDefault()!.GetDamage();
        return dmgWeapon + dmgAttribute;
    }
}

public class Archer : Hero
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
        int dmgWeapon = Equipments.OfType<Weapon>().FirstOrDefault()!.GetDamage();
        return dmgWeapon + dmgAttribute;
    }
}

public class Swashbuckler : Hero
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
        int dmgWeapon = Equipments.OfType<Weapon>().FirstOrDefault()!.GetDamage();
        return dmgWeapon + dmgAttribute;
    }
}

public class Barbarian : Hero
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
        int dmgWeapon = Equipments.OfType<Weapon>().FirstOrDefault()!.GetDamage();
        return dmgWeapon + dmgAttribute;
    }
}