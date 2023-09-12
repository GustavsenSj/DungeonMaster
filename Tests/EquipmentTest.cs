using DungeonMaster;
using DungeonMaster.equipments;
using DungeonMaster.Exceptions;
using DungeonMaster.Hero;

namespace Tests;

public class EquipmentTest
{
    [Fact]
    public void Create_CreateWeapon_ShouldReturnWeaponProps()
    {
        var weapon = new Weapon("Magical Stick", 2, EquipmentSlot.Weapon, WeaponsType.Staff, 3);
        Assert.Equal("Magical Stick", weapon.Name);
        Assert.Equal(2, weapon.RequiredLevel);
        Assert.Equal((EquipmentSlot.Weapon), weapon.Slot);
        Assert.Equal(WeaponsType.Staff, weapon.GetType());
        Assert.Equal(3, weapon.GetDamage());
    }

    [Fact]
    public void Create_CreateArmor_ShouldReturnArmorProps()
    {
        //Arrange/Act
        var armor = new Armor("Comfy Pants", 1, EquipmentSlot.Legs, ArmorType.Cloth, new HeroAttributes(0, 2, -1));

        //Assert
        Assert.Equal("Comfy Pants", armor.Name);
        Assert.Equal(1, armor.RequiredLevel);
        Assert.Equal(EquipmentSlot.Legs, armor.Slot);
        Assert.Equal(ArmorType.Cloth, armor.Type);
        Assert.Equal(-1, armor.ArmorAttribute.Intelligence);

        Assert.Equal(0, armor.ArmorAttribute.Strength);
        Assert.Equal(2, armor.ArmorAttribute.Dexterity);
    }

    [Fact]
    public void Equip_EquipValidArmor_ShouldReturnEquippedItemName()
    {
        // Arrange
        var wizard = new HeroFactory().CreateWizard("Merlin");
        var staff = new Weapon("MagicStaff", 1, EquipmentSlot.Weapon, WeaponsType.Staff, 10);

        //Act
        wizard.EquipWeapon(staff);

        // Assert
        Assert.Equal("MagicStaff",
            wizard.Equipments[EquipmentSlot.Weapon]?.Name);
    }


    [Fact]
    public void Equip_EquipValidChest_ShouldReturnEquippedItemName()
    {
        //Arrange
        var wizard = new HeroFactory().CreateWizard("Merlin");
        var chest = new Armor("Simple robe", 1, EquipmentSlot.Body, ArmorType.Cloth, new HeroAttributes(0, 0, 0));

        //Act
        wizard.EquipArmor(chest);

        //Assert
        Assert.Equal("Simple robe", wizard.Equipments[EquipmentSlot.Body]?.Name);
    }

    [Fact]
    public void Calculate_AttributesUnEquipArmor_ShouldReturnAttributes()
    {
        var head = new Armor("Cool shades", 1, EquipmentSlot.Head, ArmorType.Cloth, new HeroAttributes(10, 0, 5));

        var wizard = new HeroFactory().CreateWizard("Potter");

        wizard.EquipArmor(head);

        wizard.RemoveHead();
        Assert.Equal(1, wizard.CalculateStrength());
        Assert.Equal(1, wizard.CalculateDex());
        Assert.Equal(8, wizard.CalculateInt());
    }

    [Fact]
    public void Calculate_AttributesWithOneArmor_ShouldReturnAttributes()
    {
        var head = new Armor("Cool shades", 1, EquipmentSlot.Head, ArmorType.Cloth, new HeroAttributes(10, 0, 5));

        var wizard = new HeroFactory().CreateWizard("Potter");

        wizard.EquipArmor(head);

        Assert.Equal(11, wizard.CalculateStrength());
        Assert.Equal(1, wizard.CalculateDex());
        Assert.Equal(13, wizard.CalculateInt());
    }

    [Fact]
    public void Calculate_AttributesWithTwoArmor_ShouldReturnAttributes()
    {
        var legs = new Armor("Comfy Pants", 1, EquipmentSlot.Legs, ArmorType.Cloth, new HeroAttributes(0, 2, -1));
        var head = new Armor("Cool shades", 1, EquipmentSlot.Head, ArmorType.Cloth, new HeroAttributes(10, 0, 5));

        var wizard = new HeroFactory().CreateWizard("Potter");

        wizard.EquipArmor(head);
        wizard.EquipArmor(legs);

        Assert.Equal(11, wizard.CalculateStrength());
        Assert.Equal(3, wizard.CalculateDex());
        Assert.Equal(12, wizard.CalculateInt());
    }

    [Fact]
    public void Calculate_AttributesWithThreeArmor_ShouldReturnAttributes()
    {
        var legs = new Armor("Comfy Pants", 1, EquipmentSlot.Legs, ArmorType.Cloth, new HeroAttributes(0, 2, -1));
        var head = new Armor("Cool shades", 1, EquipmentSlot.Head, ArmorType.Cloth, new HeroAttributes(10, 0, 5));
        var chest = new Armor("Simple robe", 1, EquipmentSlot.Body, ArmorType.Cloth, new HeroAttributes(0, 0, 4));
        var wizard = new HeroFactory().CreateWizard("Potter");

        wizard.EquipArmor(head);
        wizard.EquipArmor(legs);
        wizard.EquipArmor(chest);

        Assert.Equal(11, wizard.CalculateStrength());
        Assert.Equal(3, wizard.CalculateDex());
        Assert.Equal(16, wizard.CalculateInt());
    }

    [Theory]
    [InlineData(ArmorType.Leather)]
    [InlineData(ArmorType.Plate)]
    [InlineData(ArmorType.Mail)]
    public void ErrorHandling_WhenEquippingInvalidType_ShouldThrowInvalidTypeError(ArmorType type)
    {
        var wizard = new HeroFactory().CreateWizard("Weasley");
        var chest = new Armor("Big platy plate", 1, EquipmentSlot.Body, type, new HeroAttributes(0, 0, 0));

        Assert.Throws<InvalidEquipmentTypeException>(() => wizard.EquipArmor(chest));
    }

    [Theory]
    [InlineData(WeaponsType.Sword)]
    [InlineData(WeaponsType.Hatchet)]
    [InlineData(WeaponsType.Bow)]
    [InlineData(WeaponsType.Dagger)]
    [InlineData(WeaponsType.Mace)]
    public void ErrorHandling_EquipNonValidWeapon_ShouldThrowInvalidTypeError(WeaponsType type)
    {
        // Arrange
        var wizard = new HeroFactory().CreateWizard("Merlin");
        var weapon = new Weapon("Big boy sword", 1, EquipmentSlot.Weapon, type, 10);

        Assert.Throws<InvalidEquipmentTypeException>(() => wizard.EquipWeapon(weapon));
    }

    [Fact]
    public void ErrorHandling_WhenEquippingInvalidLevel_ShouldThroeInsufficientLevelException()
    {
        var wizard = new HeroFactory().CreateWizard("Saruman");
        var chest = new Armor("High Level Item", 10, EquipmentSlot.Body, ArmorType.Cloth, new HeroAttributes(0, 0, 0));


        Assert.Throws<InsufficientLevelException>(() => wizard.EquipArmor(chest));
    }
}