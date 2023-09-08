namespace DungeonMaster;

public enum WeaponsType
{
    Hatchet,
    Bow,
    Dagger,
    Mace,
    Staff,
    Sword,
    Wand,
}
public class Weapons : IEquipment
{
    private WeaponsType Type;
    private int Damage;
    
    public Weapons(string name, int requiredLevel, EquipmentSlot equipmentSlot, WeaponsType type, int damage)
    {
        Name = name;
        RequiredLevel = requiredLevel;
        Slot = equipmentSlot;
        Type = type;
        Damage = damage;
    }
    
    public string Name { get; set; }
    public int RequiredLevel { get; set;}
    public EquipmentSlot Slot { get; set; }
    
}