using DungeonMaster;
using DungeonMaster.equipments;
using DungeonMaster.Hero;

namespace Tests;

public class EquipmentTest
{
    [Fact]
    public void CreateWeapon()
    {
        var weapon = new Weapon("Magical Stick", 2, EquipmentSlot.Weapon, WeaponsType.Staff, 3);
        Assert.Equal("Magical Stick", weapon.Name);
        Assert.Equal(2, weapon.RequiredLevel);
        Assert.Equal((EquipmentSlot.Weapon), weapon.Slot);
        Assert.Equal(WeaponsType.Staff, weapon.GetType());
        Assert.Equal(3, weapon.GetDamage());
    }

    [Fact]
    public void CreateArmor()
    {
        var armor = new Armor("Comfy Pants", 1, EquipmentSlot.Legs, ArmorType.Cloth, new HeroAttributes(0, 2, -1));

        Assert.Equal("Comfy Pants", armor.Name);
        Assert.Equal(1, armor.RequiredLevel);
        Assert.Equal(EquipmentSlot.Legs, armor.Slot);
        Assert.Equal(ArmorType.Cloth, armor.Type);
        Assert.Equal(-1, armor.ArmorAttribute.Intelligence);

        Assert.Equal(0, armor.ArmorAttribute.Strength);
        Assert.Equal(2, armor.ArmorAttribute.Dexterity);
    }

    [Fact]
    public void EquipValidArmor()
    {
        // Arrange
        var wizard = new HeroFactory().CreateWizard("Merlin");
        var staff = new Weapon("MagicStaff", 1, EquipmentSlot.Weapon, WeaponsType.Staff, 10);
        wizard.EquipWeapon(staff);

        // Assert
        Assert.Equal("MagicStaff",
            wizard.Equipments[EquipmentSlot.Weapon]?.Name);
    }

    [Fact]
    public void EquipNonValidArmor()
    {
        // Arrange
        var wizard = new HeroFactory().CreateWizard("Merlin");
        var sword = new Weapon("Big boy sword", 1, EquipmentSlot.Weapon, WeaponsType.Sword, 10);
        wizard.EquipWeapon(sword);

        //Assert 
        Assert.Null(wizard.Equipments[EquipmentSlot.Weapon]);
    }

    [Fact]
    public void EquipValidChest()
    {
        //Arrange
        var wizard = new HeroFactory().CreateWizard("Merlin");
        var chest = new Armor("Simple robe", 1, EquipmentSlot.Body, ArmorType.Cloth, new HeroAttributes(0, 0, 0));
        wizard.EquipArmor(chest);

        //Assert
        Assert.Equal("Simple robe", wizard.Equipments[EquipmentSlot.Body]?.Name);
    }

    [Fact]
    public void CorrectApplianceOfArmorAttributes()
    {
        var chest = new Armor("Simple robe", 1, EquipmentSlot.Body, ArmorType.Cloth, new HeroAttributes(0, 0, 4));
        var legs = new Armor("Comfy Pants", 1, EquipmentSlot.Legs, ArmorType.Cloth, new HeroAttributes(0, 2, -1));
        var head = new Armor("Cool shades", 1, EquipmentSlot.Head, ArmorType.Cloth, new HeroAttributes(10, 0, 5));
        var wizard = new HeroFactory().CreateWizard("Potter");

        Assert.Equal(1, wizard.CalculateStrength());
        Assert.Equal(1, wizard.CalculateDex());
        Assert.Equal(8, wizard.CalculateInt());

        wizard.EquipArmor(head);
        Assert.Equal(11, wizard.CalculateStrength());
        Assert.Equal(1, wizard.CalculateDex());
        Assert.Equal(13, wizard.CalculateInt());

        wizard.EquipArmor(legs);
        Assert.Equal(11, wizard.CalculateStrength());
        Assert.Equal(3, wizard.CalculateDex());
        Assert.Equal(12, wizard.CalculateInt());

        wizard.EquipArmor(chest);
        Assert.Equal(11, wizard.CalculateStrength());
        Assert.Equal(3, wizard.CalculateDex());
        Assert.Equal(16, wizard.CalculateInt());

        wizard.RemoveBody();
        Assert.Equal(11, wizard.CalculateStrength());
        Assert.Equal(3, wizard.CalculateDex());
        Assert.Equal(12, wizard.CalculateInt());
    }
}