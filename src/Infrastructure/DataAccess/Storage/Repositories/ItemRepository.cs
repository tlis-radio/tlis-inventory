using Tlis.Inventory.Application.Features.Storage.Entities;

namespace Tlis.Inventory.Infrastructure.DataAccess.Storage.Repositories;

public class ItemRepository(StorageDbContext dbContext) : DefaultRepository<Item, StorageDbContext>(dbContext);