using FluentValidation;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Create;

public class CreateTagValidator : AbstractValidator<CreateTag>
{
    public CreateTagValidator()
    {
        RuleFor(createTag => createTag.Name)
            .NotEmpty()
            .MaximumLength(50);
    }
}