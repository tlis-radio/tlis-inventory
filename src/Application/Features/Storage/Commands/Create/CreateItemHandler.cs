using Tlis.Inventory.Application.Features.Storage.Entities;
using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Create;

public class CreateItemHandler(StorageUnitOfWork unitOfWork) : ICommandHandler<CreateItem, int>
{
    public async Task<int> Handle(CreateItem request, CancellationToken cancellationToken)
    {
        (string name, int categoryId, int quantity) = request;
        
        var item = new Item
        {
            Name = name,
            CategoryId = categoryId,
            Quantity = quantity
        };

        await unitOfWork.Items.Create(item, cancellationToken);

        return item.Id;
    }
}