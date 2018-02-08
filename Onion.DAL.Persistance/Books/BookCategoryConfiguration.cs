using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.DAL.Entities.Books
{
    public class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
    {
        void IEntityTypeConfiguration<BookCategory>.Configure(EntityTypeBuilder<BookCategory> builder)
        {

            //builder.HasKey(bc => new { bc.BookId, bc.CategoryId});
            builder.HasKey(bc => bc.Id);

            //BookCategory is the join entity between Book and Category used to represent many to many relationship
            builder.HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId);

            builder.HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);
        }
    }
}
