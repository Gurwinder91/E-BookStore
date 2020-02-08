using AutoMapper;
using EBookStore.Application.Books.Queries.GetSpecificBook;
using EBookStore.Application.Test.Infrastructure;
using EBookStore.Persistence.Models;
using EBookStore.Repository.IRepositories;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EBookStore.Application.Test.Books.Queries
{
    [Collection("QueryCollection")]
    public class GetSpecificBookQueryhandlerTests
    {
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly IMapper _mapper;

        public GetSpecificBookQueryhandlerTests(QueryTestFixture fixture)
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetSpecificBookTest()
        {
            // Arrange
            var book =new Book
            {
                 Name = "Half Girlfriend",  AuthorName = "Chetan Bhagat", Cost = 900, PublishedOn = DateTime.Now.AddYears(-6), WrittenIn = "English", Description= "Lorum Ipsum is dummy data"
            };

            var sut = new GetSpecificBookQueryHandler(_mockBookRepository.Object, _mapper);
            _mockBookRepository.Setup(x => x.FindAsync(It.IsAny<Expression<Func<Book, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(book);

            // Act
            var result = await sut.Handle(new GetSpecificBookQuery {  bookId = 1}, CancellationToken.None);

            // Assert
            result.Should().BeOfType<GetSpecificBookViewModel>();
        }
    }
}
