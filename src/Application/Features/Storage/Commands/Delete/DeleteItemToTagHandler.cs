using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Delete;

public class DeleteItemToTagHandler(StorageUnitOfWork unitOfWork) : ICommandHandler<DeleteItemToTag>
{
    public async Task Handle(DeleteItemToTag request, CancellationToken cancellationToken)
    {
        (int itemId, string tagName) = request;

        await unitOfWork.ItemsToTags.Delete([itemId, tagName], cancellationToken);
    }
}