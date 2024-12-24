using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Delete;

public class DeleteCategoryHandler(StorageUnitOfWork unitOfWork) : ICommandHandler<DeleteCategory>
{
    public async Task Handle(DeleteCategory request, CancellationToken cancellationToken)
    {
        request.Deconstruct(out int categoryId);

        await unitOfWork.Categories.Delete(categoryId, cancellationToken);
    }
}