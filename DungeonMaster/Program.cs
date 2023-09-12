using DungeonMaster;
using DungeonMaster.equipments;
using DungeonMaster.Hero;

//
// // Create the Weapon instance first
// Weapon? weapon = new Weapon("BigWeapon", 1, EquipmentSlot.Weapon, WeaponsType.Staff, 10);
//
// // Create the armor 
// Armor? armor = new Armor("BigChestPlate", 1, EquipmentSlot.Body, ArmorType.Cloth, new HeroAttributes(0, 0, 2));
// // Then create the Hero
// IHero player = new HeroFactory().CreateWizard("Sjur");
//
// Console.WriteLine("Hello, World!");
//
// player.EquipWeapon(weapon);
// player.EquipArmor(armor);
// player.PrintHeroDetails();
// Console.WriteLine($"{player.CalculateDamage()}");
// player.LevelUp();
// player.PrintHeroDetails();
// Console.WriteLine($"{player.CalculateDamage()}");
GameController gameController = new GameController();
gameController.StartGame();