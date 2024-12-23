using Microsoft.EntityFrameworkCore;
using Tlis.Inventory.Application.Features.Storage.Entities;
using Tlis.Inventory.Infrastructure.DataAccess.Storage.EntityConfigurations;

namespace Tlis.Inventory.Infrastructure.DataAccess.Storage;

public class StorageDbContext : DbContext
{
    internal DbSet<Item> Items { get; set; } = null!;

    internal DbSet<ItemToTag> ItemToTags { get; set; } = null!;

    internal DbSet<Tag> Tags { get; set; } = null!;

    internal DbSet<Category> Categories { get; set; } = null!;
    
    public StorageDbContext(DbContextOptions<StorageDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}