using EBookStore.Api.IntegrationTest.Infrastructure;
using EBookStore.Application.Users.Queries.Orders;
using EBookStore.Application.Users.Queries.VerifyUser;
using EBookStore.Persistence;
using EBookStore.Persistence.Models;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EBookStore.Api.IntegrationTest.TestScenarios
{
    [Collection("QueryCollection")]
    public class UserScenarios
    {
        private readonly HttpClient _client;
        private readonly EBookStoreDbContext _context;

        public UserScenarios(QueryTestFixture fixture)
        {
            _client = fixture.Client;
            _context = fixture.Context;
        }

        [Fact]
        public async Task UserShouldGetTokenWithCorrectEmailAndPassword()
        {
            // Arrange
            var user = new User
            {
                Email = "abc@abc.com",
                Password = "233223"
            };
            _context.Users.Add(user);
            _context.SaveChanges();

            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("api/user/token", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var returnedUser = JsonConvert.DeserializeObject<VerifyUserModel>(stringResponse);
            returnedUser.Email.Should().Be(user.Email);
            returnedUser.Token.Should().NotBeEmpty();
            returnedUser.Token.Should().NotBeEmpty();

            // Removing Added Data
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        [Fact]
        public async Task UserShouldGetHisOrders()
        {
            // Arrange
            var user = new User
            {
                Email = "abc@abc.com",
                Password = "233223"
            };
            var book = new Book
            {
                AuthorName = "Test",
                Cost = 12,
                Name = "Test Book",
                PublishedOn = DateTime.Now,
                Stock = 5,
                Title = "Test Book Title"
            };
            var purchaseBook = new PurchasedBook
            {
                Book = book,
                User = user,
                BookId = book.Id,
                UserId = user.Id,
                PaymentMode = "Cash",
                Count = 2
            };
            _context.PurchasedBooks.Add(purchaseBook);
            _context.SaveChanges();
            var count = _context.PurchasedBooks.Where(x => x.User.Email == user.Email).Select(x => x.Id).Count();

            // Act
            var response = await _client.GetAsync($"api/user/orders?{ClaimTypes.Email}={user.Email}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<IEnumerable<UserOrderModel>>(stringResponse);
            orders.Should().HaveCount(count);

            // Removing Added Data
            _context.PurchasedBooks.Remove(purchaseBook);
            _context.Users.Remove(user);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
