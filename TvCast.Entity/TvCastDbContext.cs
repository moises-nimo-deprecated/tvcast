using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TvCast.Entity.Entities;

namespace TvCast.Entity
{
    public class TvCastDbContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<Casting> Castings { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Show> Shows { get; set; }

        public TvCastDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("TvCastDbContext");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(_connectionString);
    }
}