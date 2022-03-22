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
        private readonly UserRepository _sut;
        private readonly AppMainContext _context;

        public UserRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AppMainContext>()
                             .UseInMemoryDatabase(Guid.NewGuid().ToString())
                             .Options;
            _context = new AppMainContext(options);
            _sut = new UserRepository(_context);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnUserObjectInTheArgument_IfUserIsNotNull()
        {
            // Arrange
            var userWithFullySetProperties = new User
            {
                Id = new Random().Next(1, int.MaxValue),
                Username = "Test UserName",
                Password = "TestPassword",
                Email = "test@email.com",
            };

            var userWithIncompleteSetProperties = new User
            {
                Id = new Random().Next(1, int.MaxValue),
                Username = null!,
                Password = "TestPassword",
                Email = null!,
            };

            var userWithNoSetProperties = new User();

            User noUser = null!;


            // Act
            var userWithRequiredProperties = await _sut.CreateAsync(userWithFullySetProperties);

            var userWithIncompleteRequiredProperties = await _sut.CreateAsync(userWithIncompleteSetProperties);

            var userWithNoRequiredProperties = await _sut.CreateAsync(userWithNoSetProperties);

            var nullUser = await _sut.CreateAsync(noUser);


            // Assert
            Assert.NotNull(userWithRequiredProperties);
            Assert.Null(userWithIncompleteRequiredProperties);
            Assert.Null(userWithNoRequiredProperties);
            Assert.Null(nullUser);
        }
    }
}
