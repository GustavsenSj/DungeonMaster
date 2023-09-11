using DungeonMaster.equipments;

namespace DungeonMaster.Hero;
/// <summary>
/// The archer class represents a archer hero class 
/// </summary>
public class Archer : IHero
{
    public string Name { get; set; }
    public int Level { get; set; }
    public Dictionary<EquipmentSlot, IEquipment?> Equipments { get; set; }
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
        Equipments = new Dictionary<EquipmentSlot, IEquipment?>();
        this.EquipNullEquipment();
    }

    public double CalculateDamage()
    {
        int dmgAttribute = this.GetDexFromEquippedArmor(); 
        int dmgWeapon = this.GetDamageOfEquippedWeapon();
        double damage =  dmgWeapon * (1+ dmgAttribute/100.00);
        return Math.Round (damage,2);
    }

    public void LevelUp()
    {
        Level++;
        Attributes.AddToDex(5);
        Attributes.AddToInt(1);
        Attributes.AddToStrength(1);
    }
}
