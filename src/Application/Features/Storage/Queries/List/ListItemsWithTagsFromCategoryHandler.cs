using Tlis.Inventory.Application.Features.Storage.Dtos;
using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Queries.List;

public class ListItemsWithTagsFromCategoryHandler(StorageUnitOfWork unitOfWork)
    : IQueryHandler<ListItemsWithTagsFromCategory, List<ItemWithTagsDto>>
{
    public Task<List<ItemWithTagsDto>> Handle(ListItemsWithTagsFromCategory request,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(unitOfWork.Items.Query()
            .Where(item => item.CategoryId == request.CategoryId)
            .GroupJoin(unitOfWork.ItemsToTags.Query(),
                item => item.Id,
                tag => tag.ItemId,
                (item, tags) => new ItemWithTagsDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Quantity = item.Quantity,
                    Tags = tags.Select(tag => tag.TagName).ToList()
                }
            ).ToList()
        );
    }
}