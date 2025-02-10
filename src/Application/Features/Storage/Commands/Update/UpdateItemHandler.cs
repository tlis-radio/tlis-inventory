using Tlis.Inventory.Application.Exceptions;
using Tlis.Inventory.Application.Features.Storage.Entities;
using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Update;

public class UpdateItemHandler(StorageUnitOfWork unitOfWork) : ICommandHandler<UpdateItem>
{
    public async Task Handle(UpdateItem request, CancellationToken cancellationToken)
    {
        (int itemId, string? name, int? quantity) = request;

        Item? item = await unitOfWork.Items.Read(itemId, cancellationToken);

        if (item is null)
            throw new EntityNotFoundException(itemId);

        if (name is not null)
            item.Name = name;
        if (quantity is int value)
            item.Quantity = value;

        await unitOfWork.Items.Update(item, cancellationToken);
    }
}