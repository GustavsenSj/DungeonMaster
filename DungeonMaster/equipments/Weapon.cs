namespace DungeonMaster.equipments;
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
    private readonly WeaponsType _type;
    private readonly int _damage;
    
    public Weapon(string name, int requiredLevel, EquipmentSlot equipmentSlot, WeaponsType type, int damage)
    {
        Name = name;
        RequiredLevel = requiredLevel;
        Slot = equipmentSlot;
        _type = type;
        _damage = damage;
    }

    public new WeaponsType GetType()
    {
        return _type;
    }
    public int GetDamage()
    {
        return _damage;
    }
    
    public string Name { get; set; }
    public int RequiredLevel { get; set;}
    public EquipmentSlot Slot { get; set; }
    
}