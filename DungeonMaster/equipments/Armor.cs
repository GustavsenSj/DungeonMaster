namespace DungeonMaster;

public enum ArmorType
{
    Cloth,
    Leather,
    Mail,
    Plate
}
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