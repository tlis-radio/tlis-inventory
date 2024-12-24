using Tlis.Inventory.Application.Features.Storage.Entities;
using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Queries.List;

public sealed record ListCategories : IQuery<List<Category>>;