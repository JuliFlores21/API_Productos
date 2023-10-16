using API_Productos.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Productos.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(
            DbContextOptions<ApplicationDBContext> options
            ): base(options) { }
       public DbSet<Producto> Producto {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                   IdProducto=1,
                    Nombre="Producto 1",
                    Descripcion="Descripcion producto 1",
                    Cantidad=12
                },
                new Producto
                {
                    IdProducto = 2,
                    Nombre = "Producto 2",
                    Descripcion = "Descripcion producto 2",
                    Cantidad = 22
                }

                );
        }
    }
}
