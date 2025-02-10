using Tlis.Inventory.Application.Features.Storage.Dtos;
using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Queries.Get;

public record GetCategoryById(int CategoryId) : IQuery<CategoryDto?>;