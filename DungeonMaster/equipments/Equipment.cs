namespace DungeonMaster;

public enum EquipmentSlot
{
    Weapon,
    Head,
    Body,
    Legs
}

public interface IEquipment
{
    string Name { get; set; }
    int RequiredLevel { get; set; }
    EquipmentSlot Slot { get; set; }
}