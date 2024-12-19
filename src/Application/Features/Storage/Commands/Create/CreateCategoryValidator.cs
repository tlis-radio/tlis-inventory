using FluentValidation;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Create;

public class CreateCategoryValidator : AbstractValidator<CreateCategory>
{
    public CreateCategoryValidator()
    {
        RuleFor(category => category.Name)
            .NotEmpty()
            .Length(1, 100);
    }
}