using Tlis.Inventory.Application.Features.Storage.Repositories;

namespace Tlis.Inventory.Application.Features.Storage;

public class StorageUnitOfWork(IItemRepository itemRepository, ICategoryRepository categoryRepository,
    IItemToTagRepository itemToTagRepository, ITagRepository tagRepository)
{
    public IItemRepository Items { get; set; } = itemRepository;

    public ICategoryRepository Categories { get; set; } = categoryRepository;

    public IItemToTagRepository ItemsToTags { get; set; } = itemToTagRepository;

    public ITagRepository Tags { get; set; } = tagRepository;
}