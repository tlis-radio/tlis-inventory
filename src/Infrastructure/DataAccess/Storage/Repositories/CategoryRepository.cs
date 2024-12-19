using Tlis.Inventory.Application.Features.Storage.Entities;

namespace Tlis.Inventory.Infrastructure.DataAccess.Storage.Repositories;

public class CategoryRepository(StorageDbContext dbContext) : DefaultRepository<Category, StorageDbContext>(dbContext);