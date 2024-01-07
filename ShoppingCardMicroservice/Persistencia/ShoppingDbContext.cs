using Microsoft.EntityFrameworkCore;
using ShoppingCardMicroservice.Modelo;

namespace ShoppingCardMicroservice.Persistencia
{
    public class ShoppingDbContext : DbContext
    {
        public ShoppingDbContext(DbContextOptions options) : base(options) { }
        public DbSet<CarritoSession> CarritoSessions { get; set; }
        public DbSet<CarritoSessionDetalle> CarritoSessionDetalles { get; set; }
    }
}
