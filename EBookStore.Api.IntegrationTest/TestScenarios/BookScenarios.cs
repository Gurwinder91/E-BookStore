using EBookStore.Api.IntegrationTest.Infrastructure;
using EBookStore.Application.Books.Queries.GetBookList;
using EBookStore.Persistence;
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
    }
}
