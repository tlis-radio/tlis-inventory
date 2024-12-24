using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tlis.Inventory.Application.Features.Storage.Entities;
using Tlis.Inventory.Application.Features.Storage.Repositories;
using Tlis.Inventory.Core;
using Tlis.Inventory.Infrastructure.DataAccess.Storage;
using Tlis.Inventory.Infrastructure.DataAccess.Storage.Repositories;

namespace Tlis.Inventory.Infrastructure;

public static class InfrastructureModule
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<StorageDbContext>((provider, builder) =>
        {
            string? connectionString = provider.GetRequiredService<IConfiguration>()
                .GetConnectionString("StorageDb");

            if (connectionString is null) 
                throw new NullReferenceException("Connection sting is null");

            builder.UseNpgsql(connectionString);
        });
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IItemToTagRepository, ItemToTagRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
    }
}
