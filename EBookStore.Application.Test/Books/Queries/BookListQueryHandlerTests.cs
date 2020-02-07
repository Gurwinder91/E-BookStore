using AutoMapper;
using EBookStore.Application.Books.Queries.GetBookList;
using EBookStore.Application.Test.Infrastructure;
using EBookStore.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Linq;
using Moq;
using EBookStore.Repository.IRepositories;
using EBookStore.Persistence.Models;

namespace EBookStore.Application.Test.Books.Queries
{
   [Collection("QueryCollection")]
    public class BookListQueryHandlerTests
    {
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly IMapper _mapper;

        public BookListQueryHandlerTests(QueryTestFixture fixture)
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetBooksTest()
        {
            // Arrange
            var books = new TestAsyncEnumerable<Book>(new []
            {
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
            }).AsQueryable();

            var sut = new BookListQueryHandler(_mockBookRepository.Object, _mapper);
            _mockBookRepository.Setup(x => x.GetAll()).Returns(books);

            // Act
            var result = await sut.Handle(new BookListQuery(), CancellationToken.None);

            // Assert
            result.Should().BeOfType<List<BookListViewModel>>();
            result.Should().HaveCount(books.Count());
        }
    }
}
