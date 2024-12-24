using FluentValidation;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Update;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategory>
{
    public UpdateCategoryValidator()
    {
        RuleFor(updateCategory => updateCategory.Name)
            .Custom((s, context) =>
            {
                if (s is null) return;

                if (string.IsNullOrWhiteSpace(s))
                    context.AddFailure(nameof(UpdateCategory.Name),
                        "Name may not be empty or whitespaces. Though, it may be null");
            })
            .MaximumLength(100);
    }
}