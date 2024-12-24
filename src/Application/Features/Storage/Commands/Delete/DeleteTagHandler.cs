using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Delete;

public class DeleteTagHandler(StorageUnitOfWork unitOfWork) : ICommandHandler<DeleteTag>
{
    public async Task Handle(DeleteTag request, CancellationToken cancellationToken)
    {
        request.Deconstruct(out string tagName);

        await unitOfWork.Tags.Delete(tagName, cancellationToken);
    }
}