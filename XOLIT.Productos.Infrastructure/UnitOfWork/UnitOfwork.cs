using System;
using XOLIT.ShoppingCart.Domain.Entities;
using XOLIT.ShoppingCart.Infrastructure.DBContext;
using XOLIT.ShoppingCart.Infrastructure.Repository;

namespace CaseLink.Core.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Uni of work
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Objeto de contexto de base de datos
        /// </summary>
        private readonly XolitDbContext _context;


        private bool _disposed;

        /// <summary>
        /// Obteto de repositiro para productos
        /// </summary>
        private Repository<Producto> ProductoRepositoryUw;

        /// <summary>
        /// Inicializador de <class>UnitOfWork</class>
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(XolitDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Metodo encargado de realizar la confirmacion de transaccion en base de datos sincronamente
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// Metodo encargado de realizar la confirmacion de transaccion en base de datos asincronamente
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        ///  ProductoRepository
        /// </summary>
        public Repository<Producto> ProductoRepository
        {
            get
            {
                if (ProductoRepositoryUw == null)
                    ProductoRepositoryUw = new Repository<Producto>(_context);

                return ProductoRepositoryUw;
            }
        }

        #region Entity

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing) _context.Dispose();
            _disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}