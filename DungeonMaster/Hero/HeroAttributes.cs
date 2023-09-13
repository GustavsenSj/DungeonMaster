namespace DungeonMaster.Hero;

/// <summary>
/// Contains the different attributes a hero/player can have  
/// </summary>
public class HeroAttributes
{
    public int Strength;
    public int Dexterity;
    public int Intelligence;

    public HeroAttributes(int strength, int dexterity, int intelligence)
    {
        Strength = strength;
        Dexterity = dexterity;
        Intelligence = intelligence;
    }

    public void AddToStrength(int toAdd)
    {
        Strength += toAdd;
    }

    public void AddToDex(int toAdd)
    {
        Dexterity += toAdd;
    }

    public void AddToInt(int toAdd)
    {
        Intelligence += toAdd;
    }
}