using BookMicroservice.Modelo;
using Microsoft.EntityFrameworkCore;

namespace BookMicroservice.Persistencia
{
    public class BookDBContext : DbContext
    {
        public BookDBContext( DbContextOptions<BookDBContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
