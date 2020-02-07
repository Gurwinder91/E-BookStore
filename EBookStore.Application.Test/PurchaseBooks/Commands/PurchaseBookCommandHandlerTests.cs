using EBookStore.Application.PurchaseBooks.Commands.PurchaseBook;
using EBookStore.Persistence.Models;
using EBookStore.Repository.IRepositories;
using FluentAssertions;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EBookStore.Application.Test.PurchaseBooks.Commands
{
    public class PurchaseBookCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IPurchasedBookRepository> _mockPurchasedBookRepository;

        public PurchaseBookCommandHandlerTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockPurchasedBookRepository = new Mock<IPurchasedBookRepository>();
        }

        [Fact]
        public async Task PurchaseBook()
        {
            //Arrange
            var user = new User
            {
                Email = "abc@abc.com",
                Password = "123445"
            };
            var sut = new PurchaseBookCommandHandler(_mockPurchasedBookRepository.Object, _mockUserRepository.Object);
            _mockUserRepository.Setup(x => x.FindAsync(It.IsAny<Expression<Func<User, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(user);

            //Act
            var result = await sut.Handle(new PurchaseBookCommand { UserEmail = "abc@gmail.com", BookId= 1, PaymentMode ="Cash" }, default(CancellationToken));

            //Assert
            result.Should().BeOfType<Unit>();
        }
    }
}
