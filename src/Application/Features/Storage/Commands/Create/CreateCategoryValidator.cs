using FluentValidation;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Create;

public class CreateCategoryValidator : AbstractValidator<CreateCategory>
{
    public CreateCategoryValidator()
    {
        RuleFor(createCategory => createCategory.Name)
            .NotEmpty()
            .MaximumLength(100);
    }
}