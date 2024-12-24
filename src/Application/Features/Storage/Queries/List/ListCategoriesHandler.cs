using Tlis.Inventory.Application.Features.Storage.Entities;
using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Queries.List;

public class ListCategoriesHandler(StorageUnitOfWork unitOfWork) : IQueryHandler<ListCategories, List<Category>>
{
    public Task<List<Category>> Handle(ListCategories request, CancellationToken cancellationToken)
    {
        List<Category> rootCategories = unitOfWork.Categories.Query().ToList();
        return Task.FromResult(rootCategories);
    }
}