using DungeonMaster.Hero;

namespace DungeonMaster.equipments;
/// <summary>
/// Represents all th different type of armor that exist in the program
/// </summary>
public enum ArmorType
{
    Cloth,
    Leather,
    Mail,
    Plate
}
/// <summary>
/// Armor class represents a piece of armor. 
/// </summary>
public class Armor: IEquipment
{
    public ArmorType Type;
    public HeroAttributes ArmorAttribute;
    
    public Armor(string name, int requiredLevel, EquipmentSlot slot, ArmorType type, HeroAttributes armorAttribute )
    {
        Name = name;
        RequiredLevel = requiredLevel;
        Slot = slot;
        Type = type;
        ArmorAttribute = armorAttribute;
    }

    public ArmorType GetArmorType()
    {
        return Type;
    } 
    public string Name { get; set; }
    public int RequiredLevel { get; set; }
    public EquipmentSlot Slot { get; set; }
}