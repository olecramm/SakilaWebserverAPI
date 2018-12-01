using Microsoft.EntityFrameworkCore;
using Sakila.webserverAPI.Models;

namespace Sakila.webserverAPI.Models
{
    class SakilaDBContext : DbContext
    {
        public SakilaDBContext(DbContextOptions<SakilaDBContext> options)
            : base(options) { }

        public DbSet<Actor> Actor { get; set; }
    }

    class SakilaDbContextFactory
    {
        public static SakilaDBContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SakilaDBContext>();
            optionsBuilder.UseMySQL(connectionString);
            var dbContext = new SakilaDBContext(optionsBuilder.Options);
            return dbContext;
        }
    }

}