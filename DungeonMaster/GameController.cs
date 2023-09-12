using DungeonMaster.equipments;
using DungeonMaster.Hero;

namespace DungeonMaster;

public class GameController
{
    private static Random random = new Random();

    public void StartGame()
    {
        Console.WriteLine("Welcome to the Text-Based RPG!");
        Console.Write("Enter your character name: ");
        string? characterName = Console.ReadLine();

        Console.WriteLine($"Welcome, {characterName}!");

        if (characterName != null)
        {
            IHero character = SelectCharacterClass(characterName);
            bool playing = true;

            // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
            while (playing)
            {
                Console.Clear();
                List<IEquipment> randomWeapons = GenerateRandomWeapons(3);
                Console.WriteLine("Three weapons have dropped:");
                Console.Write("(You are proficient with: ");
                foreach (WeaponsType item in character.ValidWeaponsTypes)
                {
                    Console.Write(item);
                    Console.Write(item == character.ValidWeaponsTypes.Last() ? ")\n" : ", ");
                }

                for (int i = 0; i < randomWeapons.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {randomWeapons[i].Name}");
                }

                Console.WriteLine($"{randomWeapons.Count + 1}. None");

                int chosenWeaponIndex = GetEquipmentChoice(randomWeapons.Count);
                if (chosenWeaponIndex == randomWeapons.Count)
                {
                    Console.WriteLine("No weapons selected");
                }
                else
                {
                    IEquipment chosenEquipment = randomWeapons[chosenWeaponIndex];
                    Console.WriteLine($"You've chosen the {chosenEquipment.Name} as your weapon.");
                    if (chosenEquipment is not Weapon weapon) continue;
                    try
                    {
                        character.EquipWeapon(weapon);
                        Console.WriteLine($"Equipped weapon {weapon.Name}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("You are not proficient");
                    }
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }

    private IHero SelectCharacterClass(string name)
    {
        Console.WriteLine("Select your character class:");
        Console.WriteLine("1. Barbarian");
        Console.WriteLine("2. Mage");
        Console.WriteLine("3. Archer");
        Console.WriteLine("4. Swashbuckler");

        int choice;
        while (true)
        {
            Console.Write("Enter the number of your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 4)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a valid number.");
            }
        }

        return choice switch
        {
            1 => new HeroFactory().CreateBarbarian(name),
            2 => new HeroFactory().CreateWizard(name),
            3 => new HeroFactory().CreateArcher(name),
            4 => new HeroFactory().CreateSwashbuckler(name),
            _ => throw new InvalidOperationException("Invalid character class.")
        };
    }

    private static List<IEquipment> GenerateRandomWeapons(int count)
    {
        List<IEquipment> weapons = new List<IEquipment>();

        for (int i = 0; i < count; i++)
        {
            string randomWeaponName = WeaponNameGenerator.GenerateRandomWeaponName();
            int randomDamage = random.Next(1, 21);
            int randomLevel = random.Next(1, 5);

            // Split the generated weapon name at spaces and use the last part (noun) to determine the weapon type
            string[] nameParts = randomWeaponName.Split(' ');
            string? weaponNoun = nameParts.LastOrDefault();

            // Map weapon nouns to their corresponding weapon types
            Dictionary<string, WeaponsType> nounToTypeMapping = new Dictionary<string, WeaponsType>
            {
                { "Bow", WeaponsType.Bow },
                { "Dagger", WeaponsType.Dagger },
                { "Hatchet", WeaponsType.Hatchet },
                { "Mace", WeaponsType.Mace },
                { "Staff", WeaponsType.Staff },
                { "Sword", WeaponsType.Sword },
                { "Wand", WeaponsType.Wand },
            };

            WeaponsType randomWeaponType = nounToTypeMapping!.GetValueOrDefault(weaponNoun);

            Weapon weaponToAdd = new Weapon(randomWeaponName, randomLevel, EquipmentSlot.Weapon, randomWeaponType,
                randomDamage);

            weapons.Add(weaponToAdd);
        }

        return weapons;
    }

    private int GetEquipmentChoice(int max)
    {
        int choice;
        while (true)
        {
            Console.Write($"Choose a weapon (1-{max}): ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= max)
            {
                return choice - 1; // Subtract 1 to convert to a valid index.
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a valid number.");
            }
        }
    }
}