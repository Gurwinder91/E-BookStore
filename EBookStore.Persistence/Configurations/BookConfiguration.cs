using EBookStore.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Persistence.Configurations
{
    class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(book => book.Id);
            builder.Property(book => book.Id).HasDefaultValueSql($"nextval('{DatabaseGlobal.Schema}.auto_increment')");

            builder.Property(book => book.Name).IsRequired().HasMaxLength(100);
            builder.Property(book => book.AuthorName).IsRequired().HasMaxLength(100);

            builder.Property(book => book.WrittenIn).IsRequired().HasMaxLength(50);

            builder.Property(book => book.Cost);

            builder.Property<DateTime>("PublishedOn").ValueGeneratedOnAdd();
            builder.Property<DateTime>("PublishedOn").HasDefaultValueSql("(now() at time zone 'utc')");
        }
    }
}
