namespace DungeonMaster;
/// <summary>
/// The WeaponsType represent all the different types of weapons that exist in the program. 
/// </summary>
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
/// <summary>
/// Weapon represents a equitable weapon.
/// </summary>
public class Weapon : IEquipment
{
    private WeaponsType Type;
    private int Damage;
    
    public Weapon(string name, int requiredLevel, EquipmentSlot equipmentSlot, WeaponsType type, int damage)
    {
        Name = name;
        RequiredLevel = requiredLevel;
        Slot = equipmentSlot;
        Type = type;
        Damage = damage;
    }

    public WeaponsType GetType()
    {
        return Type;
    }
    public int GetDamage()
    {
        return Damage;
    }
    
    public string Name { get; set; }
    public int RequiredLevel { get; set;}
    public EquipmentSlot Slot { get; set; }
    
}