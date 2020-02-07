
using EBookStore.Application.Test.Infrastructure;
using EBookStore.Application.Users.Queries.IssueToken;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Microsoft.Extensions.Configuration;

namespace EBookStore.Application.Test.Users.Queries
{
    [Collection("QueryCollection")]
    public class UserIssueTokenQueryHandlerTests
    {
        private readonly IConfiguration _configuration;

        public UserIssueTokenQueryHandlerTests(QueryTestFixture fixture)
        {
            _configuration = fixture.Configuration;
        }

        [Fact]
        public async Task GetUserToken()
        {
            // Arrange
            var sut = new UserIssueTokenQueryHandler(_configuration);

            // Act
            var result = await sut.Handle(new UserIssueTokenQuery { Email = "abc@abc.com" }, CancellationToken.None);

            // Assert
            result.Should().BeOfType<UserIssueTokenModel>();
            result.Token.Should().NotBeEmpty();
            result.Token.Should().NotBeNull();
        }
    }
}
