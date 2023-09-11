using DungeonMaster.equipments;

namespace DungeonMaster.Hero;
/// <summary>
/// The Barbarian class represents the barbarian hero class.
/// </summary>
public class Barbarian : IHero
{
    public string Name { get; set; }
    public int Level { get; set; }
    public Dictionary<EquipmentSlot, IEquipment?> Equipments { get; set; }
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
        Equipments = new Dictionary<EquipmentSlot, IEquipment?>();
        this.EquipNullEquipment();
    }

    public double CalculateDamage()
    {
        int dmgAttribute = this.GetStrengthFromEquippedArmor(); 
        int dmgWeapon = this.GetDamageOfEquippedWeapon();
       double damage =  dmgWeapon * (1+ dmgAttribute/100.00);
        return Math.Round (damage,2);

    }

    public void LevelUp()
    {
        Level++;
        Attributes.AddToDex(2);
        Attributes.AddToInt(1);
        Attributes.AddToStrength(3);
    }
}
