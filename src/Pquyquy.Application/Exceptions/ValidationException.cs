namespace Pquyquy.Application.Exceptions;

public class ValidationException : Exception
{
    public List<string> Errors { get; }

    public ValidationException() : base("One or more validation errors occurred.")
    {
        Errors = [];
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        foreach (var failure in failures)
        {
            Errors.Add(failure.ErrorMessage);
        }
    }

    public ValidationException(IEnumerable<string> failures) : this()
    {
        foreach (var failure in failures)
        {
            Errors.Add(failure);
        }
    }

    public ValidationException(string failure) : this()
    {
        Errors.Add(failure);
    }
}
