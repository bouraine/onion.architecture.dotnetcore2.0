using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Onion.DAL.Entities.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Data.AppDbContext
{
    public partial class AppDbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<BookCategory> BookCategory { get; set; }
    }
}
