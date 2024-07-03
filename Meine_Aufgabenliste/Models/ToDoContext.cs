using Microsoft.EntityFrameworkCore;

namespace Meine_Aufgabenliste.Models {
    public class ToDoContext : DbContext {
        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=D:\SQLite_Databases\Meine_Aufgabenliste\ToDos.db");
    }
}
