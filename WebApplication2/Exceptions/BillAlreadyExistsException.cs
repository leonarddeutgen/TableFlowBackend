namespace WebApplication2.Exceptions;

public class BillAlreadyExistsException : Exception
{
    public BillAlreadyExistsException(string message) : base(message) { }
}
