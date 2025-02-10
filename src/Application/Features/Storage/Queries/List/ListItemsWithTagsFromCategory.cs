using Tlis.Inventory.Application.Features.Storage.Dtos;
using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Queries.List;

public record ListItemsWithTagsFromCategory(int CategoryId) : IQuery<List<ItemWithTagsDto>>;