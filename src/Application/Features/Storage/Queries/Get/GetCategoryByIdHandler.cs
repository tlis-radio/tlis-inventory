using Tlis.Inventory.Application.Features.Storage.Dtos;
using Tlis.Inventory.Application.Features.Storage.Entities;
using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Queries.Get;

public class GetCategoryByIdHandler(StorageUnitOfWork unitOfWork) : IQueryHandler<GetCategoryById, CategoryDto?>
{
    public async Task<CategoryDto?> Handle(GetCategoryById request, CancellationToken cancellationToken)
    {
        Category? category = await unitOfWork.Categories.Read(request.CategoryId, cancellationToken);

        return category is null ? null : new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}