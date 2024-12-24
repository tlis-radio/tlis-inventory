using FluentValidation;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Create;

public class CreateItemToTagValidator : AbstractValidator<CreateItemToTag>
{
    public CreateItemToTagValidator()
    {
        RuleFor(createItemToTag => createItemToTag.TagName)
            .NotEmpty()
            .MaximumLength(50);
    }
}