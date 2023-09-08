using DungeonMaster;

// Create the Weapon instance first
Weapon weapon = new Weapon("BigWeapon", 1, EquipmentSlot.Weapon, WeaponsType.Staff, 10);

// Then create the Hero
Hero player = new HeroFactory().CreateWizard("Sjur");

Console.WriteLine("Hello, World!");

// Print the weapon's name
Console.WriteLine($"{weapon.Name}");

player.EquipWeapon(weapon);
player.PrintHeroDetails();
Console.WriteLine($"{player.CalculateDamage()}");
