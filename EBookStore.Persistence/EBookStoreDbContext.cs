using EBookStore.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Persistence
{
    public class EBookStoreDbContext : DbContext
    {
        public EBookStoreDbContext(DbContextOptions<EBookStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<PurchasedBook> PurchasedBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(schema: DatabaseGlobal.Schema);

            builder.HasSequence<long>("auto_increment")
               .StartsAt(1)
               .IncrementsBy(1);

            builder.ApplyConfigurationsFromAssembly(typeof(EBookStoreDbContext).Assembly);
        }
    }
}
