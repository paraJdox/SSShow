using SSShow.Core.Data.Entities;
using SSShow.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SSShow.Infrastructure.UnitTests.Data.Repositories
{
    public class UserRepositoryTests
    {
        private readonly UserRepository _sut;

        public UserRepositoryTests()
        {
            _sut = new UserRepository();
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnUserObjectInTheArgument_IfUserIsNotNull()
        {
            // Arrange
            var newUser = new User
            {
                Id = new Random().Next(1, int.MaxValue),
                Username = "Test UserName",
                Password = "TestPassword",
                Email = "test@email.com",
            };

            // Act
            var user = await _sut.CreateAsync(newUser);

            // Assert
            Assert.True(user != null);
        }
    }
}
