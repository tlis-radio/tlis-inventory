using Tlis.Inventory.Application.Exceptions;
using Tlis.Inventory.Application.Features.Storage.Entities;
using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Update;

public class UpdateCategoryHandler(StorageUnitOfWork unitOfWork) : ICommandHandler<UpdateCategory>
{
    public async Task Handle(UpdateCategory request, CancellationToken cancellationToken)
    {
        (int categoryId, string? name) = request;

        Category? category = await unitOfWork.Categories.Read(categoryId, cancellationToken);

        if (category is null)
            throw new EntityNotFoundException(categoryId);

        if (name is not null)
            category.Name = name;

        await unitOfWork.Categories.Update(category, cancellationToken);
    }
}