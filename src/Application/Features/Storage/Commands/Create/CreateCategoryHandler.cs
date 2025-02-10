using Tlis.Inventory.Application.Features.Storage.Entities;
using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Create;

public class CreateCategoryHandler(StorageUnitOfWork unitOfWork) : ICommandHandler<CreateCategory, int>
{
    public async Task<int> Handle(CreateCategory request, CancellationToken cancellationToken)
    {
        var category = new Category { Name = request.Name };

        await unitOfWork.Categories.Create(category, cancellationToken);

        return category.Id;
    }
}