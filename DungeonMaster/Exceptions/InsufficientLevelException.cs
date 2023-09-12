namespace DungeonMaster.Exceptions;

public class InsufficientLevelException : Exception
{

    public InsufficientLevelException(string message) : base(message)
    {
    }
}