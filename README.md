# DungeonMaster - A simple text-based RPG

This project/assignment is a part of the Fullstack course by Noroff. The given challenge was to build a console application in .NET. following these requirements:

- Various hero classes having attributes which increase at different rates as the character gains levels.
- Equipment, such as armor and weapons, that characters can equip. The equipped items will alter the power of the hero, causing it to deal more damage and be able to survive longer. Certain heroes can equip certain item types.
- Custom exceptions. There are two custom exceptions you are required to write, as detailed in Appendix B.
- Testing of the main functionality
- CI pipeline to show that all tests are passed.

## Functionality

The version of th application in the main branch has no functionality for user interaction yet. The user can only run the application and see the output in the console.

In the `gameplay` branch there is a simple console based game loop that the user can interact with. It wil ask the user to create a character by selecting a class and giving the charter a name. Then the application will send the user into combat facing a "random" generated enemy. The combat is automatic and will run until the enemy is dead. Then the program will drop 3 random weapons for the user to pick up. Then the loop will start over.

## Project structure

The project is structured in the following way:

- `DungeonMaster` - The main project folder
  - `Equipment` - Contains the classes for the different types of equipment
  - `Exceptions` - Contains the custom exceptions
  - `Hero` - Contains the classes for the different types of heroes
  - `Program.cs` - The main program file`
- `Tests` - Contains all the tests
