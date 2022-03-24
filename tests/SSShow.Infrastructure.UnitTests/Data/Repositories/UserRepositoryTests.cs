using Microsoft.EntityFrameworkCore;
using SSShow.Core.Data.Entities;
using SSShow.Infrastructure.Data.Contexts;
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
        private readonly AppMainContext _context;

        public UserRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AppMainContext>()
                             .UseInMemoryDatabase(Guid.NewGuid().ToString())
                             .Options;

            _context = new AppMainContext(options);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnUserObjectInTheArgument_IfUserIsNotNull()
        {
            // Arrange
            var sut = new UserRepository(_context);

            var fullySetUser = new User
            {
                Id = new Random().Next(1, int.MaxValue),
                Username = "Test UserName",
                Password = "TestPassword",
                Email = "test@email.com",
            };

            var partiallySetUser = new User
            {
                Id = new Random().Next(1, int.MaxValue),
                Password = "TestPassword",
            };

            var unsetUser = new User();

            User noUser = null!;


            // Act
            var userWithRequiredProperties = await sut.CreateAsync(fullySetUser);

            var userWithIncompleteRequiredProperties = await sut.CreateAsync(partiallySetUser);

            var userWithNoRequiredProperties = await sut.CreateAsync(unsetUser);

            var nullUser = await sut.CreateAsync(noUser);


            // Assert
            Assert.NotNull(userWithRequiredProperties);
            Assert.Null(userWithIncompleteRequiredProperties);
            Assert.Null(userWithNoRequiredProperties);
            Assert.Null(nullUser);
        }
    }
}
