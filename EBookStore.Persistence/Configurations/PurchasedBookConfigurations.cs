using EBookStore.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Persistence.Configurations
{
    public class PurchasedBookConfigurations : IEntityTypeConfiguration<PurchasedBook>
    {
        public void Configure(EntityTypeBuilder<PurchasedBook> builder)
        {
            builder.HasKey(purchasedBook => new { purchasedBook .UserId, purchasedBook.BookId});

            builder.HasOne(purchasedBook => purchasedBook.Book)
                .WithMany(purchasedBook => purchasedBook.PurchasedBooks)
                .HasForeignKey(purchasedBook => purchasedBook.BookId);

            builder.HasOne(purchasedBook => purchasedBook.User)
                .WithMany(purchasedBook => purchasedBook.PurchasedBooks)
                .HasForeignKey(purchasedBook => purchasedBook.UserId);

        }
    }
}
