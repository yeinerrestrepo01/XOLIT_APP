using Microsoft.EntityFrameworkCore;

namespace XOLIT.Productos.Infrastructure.DBContext
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        
    }
}