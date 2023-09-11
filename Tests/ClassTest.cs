using DungeonMaster;
using DungeonMaster.Hero;

namespace Tests;

public class ClassTest
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

    [Fact]
    public void LevelUp_IncreasesLevelAndAttributes()
    {
        // Arrange
        var wizard = new Wizard("Dumbledore");

        // Act
        wizard.LevelUp();

        // Assert
        Assert.Equal(2, wizard.Level);
        Assert.Equal(2, wizard.Attributes.Dexterity);
        Assert.Equal(13, wizard.Attributes.Intelligence); // Assumes +5 on level up
        Assert.Equal(2, wizard.Attributes.Strength);
    }
}