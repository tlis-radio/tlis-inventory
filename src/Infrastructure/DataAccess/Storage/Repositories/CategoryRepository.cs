using Tlis.Inventory.Application.Features.Storage.Entities;
using Tlis.Inventory.Application.Features.Storage.Repositories;

namespace Tlis.Inventory.Infrastructure.DataAccess.Storage.Repositories;

public class CategoryRepository(StorageDbContext dbContext) : DefaultRepository<Category, StorageDbContext>(dbContext), ICategoryRepository;