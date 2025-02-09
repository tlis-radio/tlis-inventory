using Tlis.Inventory.Application.Features.Storage.Dtos;
using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Queries.List;

public sealed record ListCategories : IQuery<List<CategoryDto>>;