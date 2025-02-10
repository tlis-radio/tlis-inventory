using Tlis.Inventory.Application.Features.Storage.Entities;
using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Create;

public class CreateTagHandler(StorageUnitOfWork unitOfWork) : ICommandHandler<CreateTag, string>
{
    public async Task<string> Handle(CreateTag request, CancellationToken cancellationToken)
    {
        var tag = new Tag { Name = request.Name };

        await unitOfWork.Tags.Create(tag, cancellationToken);

        return tag.Name;
    }
}