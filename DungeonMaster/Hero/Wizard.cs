using DungeonMaster.equipments;

namespace DungeonMaster.Hero;

/// <summary>
/// Thw Wizard class represents a wizard hero class
/// </summary>
public class Wizard : IHero
{
    public string Name { get; set; }
    public int Level { get; set; }
    public Dictionary<EquipmentSlot, IEquipment?> Equipments { get; set; }
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
        Equipments = new Dictionary<EquipmentSlot, IEquipment?>();
        this.EquipNullEquipment();
    }


    public double CalculateDamage()
    {
        int dmgAttribute =  this.GetIntFromEquippedArmor();
        int dmgWeapon = this.GetDamageOfEquippedWeapon();
        double damage =  dmgWeapon * (1+ dmgAttribute/100.00);
        return Math.Round (damage,2);
    }

    public void LevelUp()
    {
        Level++;
        Attributes.AddToDex(1);
        Attributes.AddToInt(5);
        Attributes.AddToStrength(1);
    }
}
