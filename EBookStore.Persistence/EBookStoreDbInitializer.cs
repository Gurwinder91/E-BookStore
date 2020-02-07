using EBookStore.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBookStore.Persistence
{
    public class EBookStoreDbInitializer
    {
        private EBookStoreDbContext _context;
        public static void Initialize(EBookStoreDbContext context)
        {
            var initializer = new EBookStoreDbInitializer
            {
                _context = context
            };
            initializer.SeedEverything();
        }

        private void SeedEverything()
        {
            _context.Database.EnsureCreated();

            if (_context.Books.Any())
            {
                return; // Db has been seeded
            }

            SeedBooks();

            SeedUsers();
        }

        private void SeedBooks()
        {
            var books = new[]
           {
             new Book{Name = "Demo",  AuthorName = "Gurwinder", Cost = 12, PublishedOn = DateTime.Now, Stock = 5, Title= "Gurwinder Demo"}
            };

            _context.Books.AddRange(books);
            _context.SaveChanges();
        }

        private void SeedUsers()
        {
            var users = new[]
            {
             new User{Email = "abc@gmail.com", Password = "123456"},
             new User{Email = "xyz@gmail.com", Password = "123456"},
            };

            _context.Users.AddRange(users);

            _context.SaveChanges();
        }
    }
}
