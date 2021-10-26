using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Buecherapp.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!Directory.Exists("data"))
                Directory.CreateDirectory("data");

            string dbPath = Path.Combine("data", "books.db");
            optionsBuilder.UseSqlite("Data Source=" + dbPath);
        }
    }
}
