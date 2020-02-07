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
                new Book {
                     AuthorName = "Test",
                      Cost = 12,
                      Name = "Test Book",
                      PublishedOn = DateTime.Now,
                      Stock = 5,
                      Title = "Test Book Title"
                },
                 new Book {
                     AuthorName = "Test1",
                      Cost = 12,
                      Name = "Test1 Book",
                      PublishedOn = DateTime.Now,
                      Stock = 5,
                      Title = "Test1 Book Title"
                }
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
