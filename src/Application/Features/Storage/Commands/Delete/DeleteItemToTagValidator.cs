using FluentValidation;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Delete;

public class DeleteItemToTagValidator : AbstractValidator<DeleteItemToTag>
{
    public DeleteItemToTagValidator() 
    { 
        RuleFor(deleteItemToTag => deleteItemToTag.TagName)
            .NotEmpty()
            .MaximumLength(50); 
    } 
}