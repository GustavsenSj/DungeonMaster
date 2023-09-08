namespace DungeonMaster;
/// <summary>
/// EquipmentSlot represents all the different slots a piece of equipment can be equipped.
/// </summary>
public enum EquipmentSlot
{
    Weapon,
    Head,
    Body,
    Legs
}

/// <summary>
/// The Equipment interface represents a piece of equipment
/// </summary>
public interface IEquipment
{
    string Name { get; set; }
    int RequiredLevel { get; set; }
    EquipmentSlot Slot { get; set; }
}