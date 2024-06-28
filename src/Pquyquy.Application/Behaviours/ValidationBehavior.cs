﻿namespace Pquyquy.Application.Behaviours;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(_validators.Select(s => s.ValidateAsync(context, cancellationToken)));
            var failures = validationResults.SelectMany(s => s.Errors).Where(w => w != null).ToList();

            if (failures.Count != 0)
                throw new Exceptions.ValidationException(failures);
        }

        return await next();
    }
}
