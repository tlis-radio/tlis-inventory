using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tlis.Inventory.Application.Features.Storage.Entities;

namespace Tlis.Inventory.Infrastructure.DataAccess.Storage.EntityConfigurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(tag => tag.Name);

        builder.Property(tag => tag.Name)
            .IsRequired()
            .HasMaxLength(50)
            .ValueGeneratedNever();
        
        builder.HasMany<Item>()
            .WithMany()
            .UsingEntity<ItemToTag>()
            .HasKey(itemToTag => new { itemToTag.ItemId, itemToTag.TagName });
    }
}