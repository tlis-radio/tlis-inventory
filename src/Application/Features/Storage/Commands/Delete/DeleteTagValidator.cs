using FluentValidation;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Delete;

public class DeleteTagValidator : AbstractValidator<DeleteTag>
{
    public DeleteTagValidator()
    {
        RuleFor(deleteTag => deleteTag.TagName)
            .NotEmpty()
            .MaximumLength(50);
    }
}