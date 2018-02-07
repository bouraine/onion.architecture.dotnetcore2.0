using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.DAL.Entities.Books
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        void IEntityTypeConfiguration<Book>.Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(t => t.Title)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
