using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.PipelineBehaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IBaseRequest
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!validators.Any())
            return await next();

        var context = new ValidationContext<TRequest>(request);
        List<ValidationFailure> errors = validators
            .Select(validator => validator.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(failure => failure is not null)
            .ToList();

        if (errors.Count != 0)
            throw new ValidationException(errors);

        return await next();
    }
}