namespace DungeonMaster.Exceptions;

public class InvalidArmorTypeException : Exception
{
    public InvalidArmorTypeException(string message) : base(message)
    {
    }
}