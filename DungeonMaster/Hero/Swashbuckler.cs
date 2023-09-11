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

    public int CalculateDamage()
    {
        int dmgAttribute = Attributes.Dexterity;
        int dmgWeapon = this.GetDamageOfEquippedWeapon();
        return dmgWeapon + dmgAttribute;
    }

    public void LevelUp()
    {
        Level++;
        Attributes.AddToDex(4);
        Attributes.AddToInt(1);
        Attributes.AddToStrength(1);
    }
}
