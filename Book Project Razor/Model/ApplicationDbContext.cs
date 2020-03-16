using Microsoft.EntityFrameworkCore;

namespace Book_Project_Razor.Model
{
    //Dziedziczenie po klasie DbContext z EntityFramework
    public class ApplicationDbContext : DbContext
    {
        // Konstruktor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Nazwa tabeli w bazie na podstawie wcześniej stworzonego modelu(klasy) "Book"
        public DbSet<Book> Books { get; set; }
    }
}
