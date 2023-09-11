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
        var wizard = new HeroFactory().CreateWizard("Gandalf");

        // Act
        int damage = wizard.CalculateDamage();

        // Assert
        Assert.Equal(8, damage); // Assumes default Intelligence attribute
    }

    [Fact]
    public void CalculateDamage_WithStaff_ReturnsAttributePlusStaffDamage()
    {
        // Arrange
        var wizard = new HeroFactory().CreateWizard("Merlin");
        var staff = new Weapon("MagicStaff", 1, EquipmentSlot.Weapon, WeaponsType.Staff, 10);
        wizard.Equipments[EquipmentSlot.Weapon] = staff;

        // Act
        int damage = wizard.CalculateDamage();

        // Assert
        Assert.Equal(18, damage); // Assumes default Intelligence attribute + 10 staff damage
    }

    [Fact]
    public void CalculateDamage_WithStaffAndEquipment_ReturnsCalculatedAttributesAndStaffDamage()
    {
        // Arrange
        var wizard = new HeroFactory().CreateWizard("Merlin");
        var staff = new Weapon("MagicStaff", 1, EquipmentSlot.Weapon, WeaponsType.Staff, 10);
        wizard.Equipments[EquipmentSlot.Weapon] = staff;
        var head = new Armor("Cool shades", 1, EquipmentSlot.Head, ArmorType.Cloth, new HeroAttributes(0, 0, 2));
        wizard.EquipArmor(head);

        // Act
        int damage = wizard.CalculateDamage();

        // Assert
        Assert.Equal(20, damage);
    }

    [Fact]
    public void CalculateDamage_WhenReplacingArmor_ReturnCalculatedDamage()
    {
        //Arrange
        var wizard = new HeroFactory().CreateWizard("Merlin");
        var staff = new Weapon("MagicStaff", 1, EquipmentSlot.Weapon, WeaponsType.Staff, 10);
        var stick = new Weapon("Bigus Stickus", 1, EquipmentSlot.Weapon, WeaponsType.Staff, 1);
        
        //Act
        wizard.EquipWeapon(staff);
        wizard.EquipWeapon(stick);
        
        //Assert
        Assert.Equal(9, wizard.CalculateDamage());
    }
}