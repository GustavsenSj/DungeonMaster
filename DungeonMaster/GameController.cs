using DungeonMaster.Enemy;
using DungeonMaster.equipments;
using DungeonMaster.Hero;

namespace DungeonMaster;

public class GameController
{
    private static readonly Random Random = new Random();
    private IHero _character = null!;
    private int _room = 1;
    private bool _playing = false;

    public void StartGame()
    {
        Console.WriteLine("Welcome to the Text-Based RPG!");
        Console.Write("Enter your character name: ");
        string? characterName = Console.ReadLine();


        if (characterName != null)
        {
            _character = SelectCharacterClass(characterName);

            Console.WriteLine(
                $"Welcome, {characterName}! You have selected the {_character.ClassName} class.");
            EnterToContinue();
            _playing = true;


            // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
            while (_playing)
            {
                EnemyEncounter();
                WeaponDropHandler();
            }
        }
    }

    private void EnemyEncounter()
    {
        Console.Clear();
        Enemy.Enemy enemy = CreateRandomEnemy();

        Console.WriteLine($"As you walk into the room nr {_room}. A {enemy.Name} spots you and combat begins!");
        EnterToContinue();
        CombatHandler(enemy);
    }

    private void CombatHandler(Enemy.Enemy enemy)
    {
        int turn = 1;
        bool playerTurn = (Random.Next(0, 2) == 0);
        while (enemy.Hp > 0)
        {
            Console.WriteLine($"Turn {turn}.");
            if (playerTurn)
            {
                Console.WriteLine($"You attack the {enemy.Name} for {_character.CalculateDamage()}");
                enemy.Hp -= _character.CalculateDamage();
                if (enemy.Hp <= 0)
                {
                    Console.WriteLine($"{enemy.Name} has died! \n You have won this time!");
                    _character.LevelUp();
                    Console.WriteLine($"Your combat knowledge has increased you level. {_character.Name} is now lvl {_character.Level}");
                    EnterToContinue();
                }
            }
            else
            {
                Console.WriteLine($"The {enemy.Name} attacks you for {enemy.Attack()} damage");
            }

            playerTurn = !playerTurn;

            turn++;
        }

        _room++;
    }

    private void EnterToContinue()
    {
        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine();
        Console.Clear();
    }

    private static Enemy.Enemy CreateRandomEnemy()
    {
        int randomHp = Random.Next(1, 30);
        string name = EnemyNameGenerator.GenerateRandomEnemyName();
        int damage = Random.Next(1, 10);

        return new Enemy.Enemy(name, damage, randomHp);
    }

    private void WeaponDropHandler()
    {
        Console.Clear();
        List<IEquipment> randomWeapons = GenerateRandomWeapons(3);
        Console.WriteLine("Three weapons have dropped:");
        Console.Write("(You are proficient with: ");
        foreach (WeaponsType item in _character.ValidWeaponsTypes)
        {
            Console.Write(item);
            Console.Write(item == _character.ValidWeaponsTypes.Last() ? ")\n" : ", ");
        }

        for (int i = 0; i < randomWeapons.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {randomWeapons[i].Name} (lvl requirement: {randomWeapons[i].RequiredLevel})");
        }

        Console.WriteLine($"{randomWeapons.Count + 1}. None");

        int chosenWeaponIndex = GetEquipmentChoice(randomWeapons.Count + 1);
        if (chosenWeaponIndex == randomWeapons.Count)
        {
            Console.WriteLine("No weapons selected");
        }
        else
        {
            IEquipment chosenEquipment = randomWeapons[chosenWeaponIndex];
            Console.WriteLine($"You've chosen the {chosenEquipment.Name} as your weapon.");
            if (chosenEquipment is Weapon weapon)
            {
                try
                {
                    _character.EquipWeapon(weapon);
                    Console.WriteLine($"Equipped weapon {weapon.Name}");
                }
                catch (Exception e)
                {
                    Console.WriteLine("You are not proficient");
                }
            }
        }

        EnterToContinue();
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
            int randomDamage = Random.Next(1, 21);
            int randomLevel = Random.Next(1, 5);

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