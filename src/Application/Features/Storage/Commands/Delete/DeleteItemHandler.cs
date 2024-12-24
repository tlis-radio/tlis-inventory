using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Delete;

public class DeleteItemHandler(StorageUnitOfWork unitOfWork) : ICommandHandler<DeleteItem>
{
    public async Task Handle(DeleteItem request, CancellationToken cancellationToken)
    {
        request.Deconstruct(out int itemId);

        await unitOfWork.Items.Delete(itemId, cancellationToken);
    }
}