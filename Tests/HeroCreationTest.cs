using DungeonMaster;
using DungeonMaster.Hero;

namespace Tests;

using Xunit;

public class HeroCreationTests
{
    [Fact]
    public void CreateWizard()
    {
        // Arrange

        var wizard = new HeroFactory().CreateWizard("Merlin");

        // Assert
        Assert.Equal("Merlin", wizard.Name);
        Assert.Equal(1, wizard.Level);
        Assert.NotNull(wizard.Equipments);
        Assert.Collection(wizard.Equipments,
            kvp =>
            {
                Assert.Equal(EquipmentSlot.Body, kvp.Key);
                Assert.Null(kvp.Value);
            },
            kvp =>
            {
                Assert.Equal(EquipmentSlot.Head, kvp.Key);
                Assert.Null(kvp.Value);
            },
            kvp =>
            {
                Assert.Equal(EquipmentSlot.Legs, kvp.Key);
                Assert.Null(kvp.Value);
            },
            kvp =>
            {
                Assert.Equal(EquipmentSlot.Weapon, kvp.Key);
                Assert.Null(kvp.Value);
            }
        );
        Assert.NotNull(wizard.ValidWeaponsTypes);
        Assert.NotNull(wizard.ValidArmorTypes);
        Assert.NotNull(wizard.Attributes);
        Assert.Equal(1, wizard.Attributes.Strength);
        Assert.Equal(1, wizard.Attributes.Dexterity);
        Assert.Equal(8, wizard.Attributes.Intelligence);
    }

    [Fact]
    public void LevelUpWizard()
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

    [Fact]
    public void CreateArcher()
    {
        // Arrange

        var hero = new HeroFactory().CreateArcher("Robin");

        // Assert
        Assert.Equal("Robin", hero.Name);
        Assert.Equal(1, hero.Level);
        Assert.NotNull(hero.Equipments);
        Assert.Collection(hero.Equipments,
            kvp =>
            {
                Assert.Equal(EquipmentSlot.Body, kvp.Key);
                Assert.Null(kvp.Value);
            },
            kvp =>
            {
                Assert.Equal(EquipmentSlot.Head, kvp.Key);
                Assert.Null(kvp.Value);
            },
            kvp =>
            {
                Assert.Equal(EquipmentSlot.Legs, kvp.Key);
                Assert.Null(kvp.Value);
            },
            kvp =>
            {
                Assert.Equal(EquipmentSlot.Weapon, kvp.Key);
                Assert.Null(kvp.Value);
            }
        );
        Assert.NotNull(hero.ValidWeaponsTypes);
        Assert.NotNull(hero.ValidArmorTypes);
        Assert.NotNull(hero.Attributes);
        Assert.Equal(1, hero.Attributes.Strength);
        Assert.Equal(7, hero.Attributes.Dexterity);
        Assert.Equal(1, hero.Attributes.Intelligence);
    }

    [Fact]
    public void LevelUpArcher()
    {
        // Arrange
        var hero = new Archer("Robin");

        // Act
        hero.LevelUp();

        // Assert
        Assert.Equal(2, hero.Level);
        Assert.Equal(12, hero.Attributes.Dexterity);
        Assert.Equal(2, hero.Attributes.Intelligence);
        Assert.Equal(2, hero.Attributes.Strength);
    }

    [Fact]
    public void CreateBarbarian()
    {
        // Arrange
        var hero = new HeroFactory().CreateBarbarian("Conan");

        // Assert
        Assert.Equal("Conan", hero.Name);
        Assert.Equal(1, hero.Level);
        Assert.NotNull(hero.Equipments);
        Assert.Collection(hero.Equipments,
            kvp =>
            {
                Assert.Equal(EquipmentSlot.Body, kvp.Key);
                Assert.Null(kvp.Value);
            },
            kvp =>
            {
                Assert.Equal(EquipmentSlot.Head, kvp.Key);
                Assert.Null(kvp.Value);
            },
            kvp =>
            {
                Assert.Equal(EquipmentSlot.Legs, kvp.Key);
                Assert.Null(kvp.Value);
            },
            kvp =>
            {
                Assert.Equal(EquipmentSlot.Weapon, kvp.Key);
                Assert.Null(kvp.Value);
            }
        );
        Assert.NotNull(hero.ValidWeaponsTypes);
        Assert.NotNull(hero.ValidArmorTypes);
        Assert.NotNull(hero.Attributes);
        Assert.Equal(5, hero.Attributes.Strength);
        Assert.Equal(2, hero.Attributes.Dexterity);
        Assert.Equal(1, hero.Attributes.Intelligence);
    }

    [Fact]
    public void LevelUpBarbarian()
    {
        // Arrange
        var hero = new Barbarian("Conan");

        // Act
        hero.LevelUp();

        // Assert
        Assert.Equal(2, hero.Level);
        Assert.Equal(4, hero.Attributes.Dexterity);
        Assert.Equal(2, hero.Attributes.Intelligence);
        Assert.Equal(8, hero.Attributes.Strength);
    }

    [Fact]
    public void CreateSwashbuckler()
    {
        // Arrange
        var hero = new HeroFactory().CreateSwashbuckler("Sabeltan");

        // Assert
        Assert.Equal("Sabeltan", hero.Name);
        Assert.Equal(1, hero.Level);
        Assert.NotNull(hero.Equipments);
        Assert.Collection(hero.Equipments,
            kvp =>
            {
                Assert.Equal(EquipmentSlot.Body, kvp.Key);
                Assert.Null(kvp.Value);
            },
            kvp =>
            {
                Assert.Equal(EquipmentSlot.Head, kvp.Key);
                Assert.Null(kvp.Value);
            },
            kvp =>
            {
                Assert.Equal(EquipmentSlot.Legs, kvp.Key);
                Assert.Null(kvp.Value);
            },
            kvp =>
            {
                Assert.Equal(EquipmentSlot.Weapon, kvp.Key);
                Assert.Null(kvp.Value);
            }
        );
        Assert.NotNull(hero.ValidWeaponsTypes);
        Assert.NotNull(hero.ValidArmorTypes);
        Assert.NotNull(hero.Attributes);
        Assert.Equal(2, hero.Attributes.Strength);
        Assert.Equal(6, hero.Attributes.Dexterity);
        Assert.Equal(1, hero.Attributes.Intelligence);
    }

    [Fact]
    public void LevelUpSwashbuckler()
    {
        // Arrange
        var hero = new Swashbuckler("Sabeltan");

        // Act
        hero.LevelUp();

        // Assert
        Assert.Equal(2, hero.Level);
        Assert.Equal(10, hero.Attributes.Dexterity);
        Assert.Equal(2, hero.Attributes.Intelligence);
        Assert.Equal(3, hero.Attributes.Strength);
    }
    
}