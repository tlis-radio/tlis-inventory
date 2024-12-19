using Tlis.Inventory.Application.Features.Storage.Repositories;

namespace Tlis.Inventory.Application.Features.Storage;

public class StorageUnitOfWork(IItemRepository itemRepository, ICategoryRepository categoryRepository)
{
    public IItemRepository Items { get; set; } = itemRepository;

    public ICategoryRepository Categories { get; set; } = categoryRepository;
}