using Tlis.Inventory.Application.Features.Storage.Dtos;
using Tlis.Inventory.Application.Features.Storage.Entities;
using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Queries.List;

public class ListCategoriesHandler(StorageUnitOfWork unitOfWork) : IQueryHandler<ListCategories, List<CategoryDto>>
{
    public Task<List<CategoryDto>> Handle(ListCategories request, CancellationToken cancellationToken)
    {
        List<CategoryDto> categories = unitOfWork.Categories.Query()
            .Select(category => new CategoryDto{ Id = category.Id, Name = category.Name })
            .ToList();
        
        return Task.FromResult(categories);
    }
}