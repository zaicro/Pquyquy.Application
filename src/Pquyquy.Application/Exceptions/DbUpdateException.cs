namespace Pquyquy.Application.Exceptions;

public class DbUpdateException : Exception
{
    public DbUpdateException(string? message, Exception? innerException)
        : base(message, innerException) { }
}
