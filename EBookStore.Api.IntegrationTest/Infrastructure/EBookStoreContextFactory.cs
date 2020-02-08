using EBookStore.Persistence;
using EBookStore.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Api.IntegrationTest.Infrastructure
{
    class EBookStoreContextFactory
    {
        public static void Create(EBookStoreDbContext context)
        {

            context.Database.EnsureCreated();

            context.Books.AddRange(new[] {
                new Book{Name = "Five Point Someone",  AuthorName = "Chetan Bhagat", Cost = 1200, PublishedOn = DateTime.Now.AddYears(-16), WrittenIn = "English", Description= "Lorum Ipsum is dummy data"},
               new Book{Name = "Half Girlfriend",  AuthorName = "Chetan Bhagat", Cost = 900, PublishedOn = DateTime.Now.AddYears(-6), WrittenIn = "English", Description= "Lorum Ipsum is dummy data" }
            });

            context.Users.Add(
                new User
                {
                    Email = "abc@abc.com",
                    Password = "123456"
                });

            context.SaveChanges();
        }

        public static void Destroy(EBookStoreDbContext context)
        {
            context.Dispose();
        }
    }
}
