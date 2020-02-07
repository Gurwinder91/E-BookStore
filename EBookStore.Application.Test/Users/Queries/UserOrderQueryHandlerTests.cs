using AutoMapper;
using EBookStore.Application.Test.Infrastructure;
using EBookStore.Application.Users.Queries.Orders;
using EBookStore.Persistence.Models;
using EBookStore.Repository.IRepositories;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EBookStore.Application.Test.Users.Queries
{
    [Collection("QueryCollection")]
    public class UserOrderQueryHandlerTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IPurchasedBookRepository> _mockPurchasedBookRepository;
        private readonly IMapper _mapper;

        public UserOrderQueryHandlerTests(QueryTestFixture fixture)
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockPurchasedBookRepository = new Mock<IPurchasedBookRepository>();
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetUserOrders()
        {
            //Arrange
            var user = new User
            {
                Email = "abc@abc.com",
                Password = "123445"
            };
            var purchaseBooks = new TestAsyncEnumerable<PurchasedBook>(new[]{
                new PurchasedBook
                {
                    PurchasedOn = DateTime.Now,
                    PaymentMode = "Card",
                    Book = new Book
                    {
                        AuthorName = "Gurwinder",
                        Title = "Test",
                        Name = "Test",
                    }
                },
                         new PurchasedBook
                {
                    PurchasedOn = DateTime.Now,
                    PaymentMode = "Card",
                    Book = new Book
                    {
                        AuthorName = "Gurwinder",
                        Title = "Test",
                        Name = "Test",
                    }
                }
            }).AsQueryable();

            var sut = new UserOrderQueryHandler(_mockPurchasedBookRepository.Object, _mockUserRepository.Object, _mapper);
            _mockUserRepository.Setup(x => x.FindAsync(It.IsAny<Expression<Func<User, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(user);
            _mockPurchasedBookRepository.Setup(x => x.FindAll(It.IsAny<Expression<Func<PurchasedBook, bool>>>())).Returns(purchaseBooks);

            //Act
            var result = await sut.Handle(new UserOrderQuery { UserEmail = "abc@gmail.com" }, default(CancellationToken));

            //Assert
            result.Should().BeOfType<List<UserOrderModel>>();
            result.Should().HaveCount(purchaseBooks.Count());
        }
    }
}
