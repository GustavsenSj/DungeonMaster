namespace DungeonMaster.Exceptions;

public class InvalidEquipmentTypeException : Exception
{
    public InvalidEquipmentTypeException(string message) : base(message)
    {
    }
}