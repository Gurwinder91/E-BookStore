using EBookStore.Api.IntegrationTest.Infrastructure;
using EBookStore.Persistence;
using EBookStore.Persistence.Models;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EBookStore.Api.IntegrationTest.TestScenarios
{
    [Collection("QueryCollection")]
    public class PurchaseBookScenarios
    {
        private readonly HttpClient _client;
        private readonly EBookStoreDbContext _context;

        public PurchaseBookScenarios(QueryTestFixture fixture)
        {
            _client = fixture.Client;
            _context = fixture.Context;
        }

        [Fact]
        public async Task UserCanPurchaseBook_GetNotContent()
        {
            // Arrange
            var book = new Book
            {
                AuthorName = "Test",
                Cost = 12,
                Name = "Test Book",
                PublishedOn = DateTime.Now,
                Stock = 5,
                Title = "Test Book Title"
            };
            var user = new User
            {
                Email = "xyz@gmail.com",
                Password = "123456"
            };
            _context.Books.Add(book);
            _context.Users.Add(user);
            _context.SaveChanges();

            var content = new StringContent(JsonConvert.SerializeObject(new { BookId = book .Id}), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync($"api/PurchaseBook?{ClaimTypes.Email}={user.Email}", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            
            // Removing Added Data
            _context.Users.Remove(user);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
