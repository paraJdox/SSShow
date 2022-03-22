using Microsoft.EntityFrameworkCore;
using SSShow.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSShow.Infrastructure.Data.Contexts
{
    internal class AppMainContext : DbContext
    {
        public AppMainContext(DbContextOptions<AppMainContext> options) : base(options)
        {
            // This is an empty constructor, but the parameter is needed for dependency injection
        }

        public DbSet<User> User { get; set; } = null!;
    }
}
