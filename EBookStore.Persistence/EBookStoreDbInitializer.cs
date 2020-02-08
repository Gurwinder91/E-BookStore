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
             new Book{Name = "Five Point Someone",  AuthorName = "Chetan Bhagat", Cost = 1200, PublishedOn = DateTime.Now.AddYears(-16), WrittenIn = "English", Description= "Lorum Ipsum is dummy data"},
             new Book{Name = "Half Girlfriend",  AuthorName = "Chetan Bhagat", Cost = 900, PublishedOn = DateTime.Now.AddYears(-6), WrittenIn = "English", Description= "Lorum Ipsum is dummy data" },
             new Book{Name = "Nineteen Eighty-Four",  AuthorName = "George Orwell", Cost = 2000, PublishedOn = DateTime.Now.AddYears(-25) , WrittenIn = "French", Description= "Lorum Ipsum is dummy data" },
             new Book{Name = "Pride and Prejudice",  AuthorName = "Jane Austen", Cost = 1100, PublishedOn = DateTime.Now.AddYears(-10) , WrittenIn = "Hindi", Description= "Lorum Ipsum is dummy data" },
             new Book{Name = "The Great Gatsby",  AuthorName = "F. Scott Fitzgerald", Cost = 1000, PublishedOn = DateTime.Now.AddYears(-5) , WrittenIn = "Punjabi", Description= "Lorum Ipsum is dummy data" },
             new Book{Name = "The Handmaid's Tale: The Graphic",  AuthorName = "Margaret Atwood", Cost = 800, PublishedOn = DateTime.Now.AddYears(-8) , WrittenIn = "Punjabi", Description= "Lorum Ipsum is dummy data" },
             new Book{Name = "Lord of the Rings",  AuthorName = "J. R. R. Tolkien", Cost = 1800, PublishedOn = DateTime.Now.AddYears(-17) , WrittenIn = "Hindi", Description= "Lorum Ipsum is dummy data" },
             new Book{Name = "Catch-22",  AuthorName = "Joseph Heller", Cost = 1500, PublishedOn = DateTime.Now.AddYears(-20) , WrittenIn = "french", Description= "Lorum Ipsum is dummy data" }
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
