namespace DungeonMaster.Exceptions;

public class InvalidArmorTypeException : Exception
{
    public InvalidArmorTypeException()
    {
    }

    public InvalidArmorTypeException(string message) : base(message)
    {
    }
}