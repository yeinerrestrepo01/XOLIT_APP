using Microsoft.EntityFrameworkCore;
using XOLIT.ShoppingCart.Domain.Entities;

namespace XOLIT.ShoppingCart.Infrastructure.DBContext
{
    public class XolitDbContext : DbContext
    {
        public XolitDbContext()
        {
        }

        public XolitDbContext(DbContextOptions<XolitDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<EncabezadoFactura> EncabezadoFactura { get; set; }
        public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        
    }
}