using DungeonMaster;
using DungeonMaster.equipments;
using DungeonMaster.Hero;

namespace Tests;

public class DamageTest
{
    [Fact]
    public void CalculateDamage_NoWeapon_ReturnsAttributeDamage()
    {
        // Arrange
        var wizard = new Wizard("Gandalf");

        // Act
        int damage = wizard.CalculateDamage();

        // Assert
        Assert.Equal(8, damage); // Assumes default Intelligence attribute
    }

    [Fact]
    public void CalculateDamage_WithStaff_ReturnsAttributePlusStaffDamage()
    {
        // Arrange
        var wizard = new Wizard("Merlin");
        var staff = new Weapon("MagicStaff", 1, EquipmentSlot.Weapon, WeaponsType.Staff, 10);
        wizard.Equipments[EquipmentSlot.Weapon] = staff;

        // Act
        int damage = wizard.CalculateDamage();

        // Assert
        Assert.Equal(18, damage); // Assumes default Intelligence attribute + 10 staff damage
    }

 
    
}