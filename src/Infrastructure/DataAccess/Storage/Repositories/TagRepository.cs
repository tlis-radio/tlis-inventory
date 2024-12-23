using Tlis.Inventory.Application.Features.Storage.Entities;
using Tlis.Inventory.Application.Features.Storage.Repositories;

namespace Tlis.Inventory.Infrastructure.DataAccess.Storage.Repositories;

public class TagRepository(StorageDbContext dbContext) : DefaultRepository<Tag, StorageDbContext>(dbContext), ITagRepository;