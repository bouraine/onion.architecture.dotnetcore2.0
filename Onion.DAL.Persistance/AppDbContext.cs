using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Onion.DAL.Entities.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Data.AppDbContext
{
    public partial class AppDbContext : DbContext
    {
        private string _StringConnection = "server=localhost; Port=5432;user id=postgres;password=postgres;database=Onion_LOCAL";

        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public AppDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_StringConnection);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }
}
