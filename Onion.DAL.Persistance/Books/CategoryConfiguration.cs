using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.DAL.Entities.Books
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        void IEntityTypeConfiguration<Category>.Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(t => t.CategoryName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
