using DungeonMaster.equipments;

namespace DungeonMaster.Hero;
/// <summary>
/// The Swashbuckler class represents the swashbuckler character class
/// </summary>
public class Swashbuckler : IHero
{
    public string Name { get; set; }
    public int Level { get; set; }
    public Dictionary<EquipmentSlot, IEquipment?> Equipments { get; set; }
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
        Attributes.AddToDex(4);
        Attributes.AddToInt(1);
        Attributes.AddToStrength(1);
    }
}
