using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tlis.Inventory.Application.Features.Storage.Entities;

namespace Tlis.Inventory.Infrastructure.DataAccess.Storage.EntityConfigurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(item => item.Id);

        builder.HasOne<Category>()
            .WithMany()
            .HasForeignKey(item => item.CategoryId)
            .IsRequired();

        builder.HasMany<Tag>()
            .WithMany()
            .UsingEntity<ItemToTag>()
            .HasKey(itemToTag => new { itemToTag.ItemId, itemToTag.TagName });

        builder.Property(item => item.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(item => item.Quantity)
            .IsRequired();
    }
}