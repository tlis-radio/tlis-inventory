using FluentValidation;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Update;

public class UpdateItemValidator : AbstractValidator<UpdateItem>
{
    public UpdateItemValidator()
    {
        RuleFor(updateItem => updateItem.Name)
            .Custom((s, context) =>
            {
                if (s is null) return;

                if (string.IsNullOrWhiteSpace(s))
                    context.AddFailure(nameof(UpdateItem.Name),
                        "Name may not be empty or whitespaces. Though, it may be null");
            })
            .MaximumLength(100);
        RuleFor(updateItem => updateItem.Quantity)
            .GreaterThanOrEqualTo(0);
    }
}