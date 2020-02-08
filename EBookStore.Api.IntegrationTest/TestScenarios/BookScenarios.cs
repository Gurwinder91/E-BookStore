using EBookStore.Api.IntegrationTest.Infrastructure;
using EBookStore.Application.Books.Queries.GetBookList;
using EBookStore.Application.Books.Queries.GetSpecificBook;
using EBookStore.Persistence;
using EBookStore.Persistence.Models;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EBookStore.Api.IntegrationTest.TestScenarios
{
    [Collection("QueryCollection")]
    public class BookScenarios
    {
        private readonly HttpClient _client;
        private readonly EBookStoreDbContext _context;

        public BookScenarios(QueryTestFixture fixture)
        {
            _client = fixture.Client;
            _context = fixture.Context;
        }

        [Fact]
        public async Task ShouldReturnAllBooks()
        {
            // Arrange
            var count = _context.Books.Select(x=>x.Id).Count();

            // Act
            var response = await _client.GetAsync("api/book?email=abc@abc.com");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var book = JsonConvert.DeserializeObject<IEnumerable<BookListViewModel>>(stringResponse);
            book.Should().HaveCount(count);
        }

        [Fact]
        public async Task ShouldReturnSpecificBook()
        {
            // Arrange
            var book = new Book { Name = "Half Girlfriend", AuthorName = "Chetan Bhagat", Cost = 900, PublishedOn = DateTime.Now.AddYears(-6), WrittenIn = "English", Description = "Lorum Ipsum is dummy data" };
            _context.Books.Add(book);
            _context.SaveChanges();

            // Act
            var response = await _client.GetAsync($"api/book/{book.Id}/?email=abc@abc.com");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var receivedBook = JsonConvert.DeserializeObject<GetSpecificBookViewModel>(stringResponse);
            receivedBook.Should().NotBeNull();

            //Removing Added Book
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
