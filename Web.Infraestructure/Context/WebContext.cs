using Microsoft.EntityFrameworkCore;
using Web.Domain.Models;

namespace Web.Infraestructure.Context
{
    public class WebContext : DbContext
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
