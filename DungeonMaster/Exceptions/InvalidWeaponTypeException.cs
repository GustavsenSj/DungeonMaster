namespace DungeonMaster.Exceptions;

public class InvalidWeaponTypeException : Exception
{
    public InvalidWeaponTypeException(string message) : base(message)
    {
    }
}