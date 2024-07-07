using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Meine_Aufgabenliste.Models {
    public class ApplicationDbContext : DbContext {

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Kategorie> Kategorie { get; set; }
        public DbSet<Schluesselwort> Schluesselwort { get; set; }
        public DbSet<Verantwortlicher> Verantwortlicher { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) { 
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("SQLiteConnection");

            options.UseSqlite(connectionString);
        }
    }
}
