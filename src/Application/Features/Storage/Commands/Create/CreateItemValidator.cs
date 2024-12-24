using FluentValidation;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Create;

public class CreateItemValidator : AbstractValidator<CreateItem>
{
    public CreateItemValidator()
    {
        RuleFor(createItem => createItem.Name)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(createItem => createItem.Quantity)
            .GreaterThanOrEqualTo(0);
    }
}