using Tlis.Inventory.Application.Features.Storage.Entities;
using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Create;

public class CreateItemToTagHandler(StorageUnitOfWork unitOfWork) : ICommandHandler<CreateItemToTag, (int, string)>
{
    public async Task<(int, string)> Handle(CreateItemToTag request, CancellationToken cancellationToken)
    {
        (int itemId, string tagName) = request;

        var itemToTag = new ItemToTag
        {
            ItemId = itemId,
            TagName = tagName
        };

        await unitOfWork.ItemsToTags.CreateOrUpdate(itemToTag, cancellationToken);

        return (itemToTag.ItemId, itemToTag.TagName);
    }
}