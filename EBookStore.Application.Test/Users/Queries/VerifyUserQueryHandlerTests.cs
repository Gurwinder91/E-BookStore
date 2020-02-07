using EBookStore.Application.Test.Infrastructure;
using EBookStore.Application.Users.Queries.IssueToken;
using EBookStore.Application.Users.Queries.VerifyUser;
using EBookStore.Persistence;
using EBookStore.Persistence.Models;
using EBookStore.Repository.IRepositories;
using FluentAssertions;
using MediatR;
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
  
    public class VerifyUserQueryHandlerTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IMediator> _mockMediator;

        public VerifyUserQueryHandlerTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockMediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task VerifyUserAndIssueToken()
        {
            //Arrange
            var token = "dfsd345gdfgdkjlfjt;34534";
            var user = new User
            {
                Email = "abc@abc.com",
                Password = "123445"
            };
            var sut = new VerifyUserQueryHandler(_mockUserRepository.Object, _mockMediator.Object);
            _mockUserRepository.Setup(x => x.FindAsync(It.IsAny<Expression<Func<User, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(user);
            _mockMediator.Setup(x => x.Send(It.IsAny<UserIssueTokenQuery>(), default(CancellationToken))).ReturnsAsync(new UserIssueTokenModel
            {
                Token = token
            });
             
            //Act
            var result = await sut.Handle(new VerifyUserQuery { Email = user.Email, Password = user.Password }, CancellationToken.None);

            //Assert
            result.Should().BeOfType<VerifyUserModel>();
            result.Email.Should().Be(user.Email);
            result.Token.Should().Be(token);
        }
    }

}
