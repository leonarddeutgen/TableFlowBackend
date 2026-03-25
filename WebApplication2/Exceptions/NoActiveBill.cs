namespace WebApplication2.Exceptions;

public class NoActiveBill : Exception
{
    public NoActiveBill(string message) : base(message) { }

}