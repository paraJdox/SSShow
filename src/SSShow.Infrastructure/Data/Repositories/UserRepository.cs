using SSShow.Core.Data.Repositories;
using SSShow.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSShow.Infrastructure.Data.Contexts;

namespace SSShow.Infrastructure.Data.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly AppMainContext _context;

        public UserRepository(AppMainContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            if (user == null) { return null!; }

            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
