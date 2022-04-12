using CaseLink.Core.Infrastructure.UnitOfWork;
using XOLIT.ShoppingCart.Domain.Entities;
using XOLIT.ShoppingCart.Infrastructure.DBContext;
using XOLIT.ShoppingCart.Infrastructure.GenericRepository;

namespace XOLIT.ShoppingCart.Infrastructure.GenericRepository.Implementation
{
    /// <summary>
    /// Repostorio generico para prodctos
    /// </summary>
    public class ProductoRepository : IProductoRepository
    {
        /// <summary>
        /// Objeto de Uni of Wrok
        /// </summary>
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Inicializador de clase <class>ProductoRepository</class>
        /// </summary>
        public ProductoRepository(XolitDbContext xolitDbContext)
        {
            UnitOfWork = new UnitOfWork(xolitDbContext);
        }

        /// <summary>
        ///  Obtiene el listado general de los productos almacenados en base de datos
        /// </summary>
        /// <returns></returns>
        public List<Producto> ObtenerListadoProductos()
        {
            return UnitOfWork.ProductoRepository.AsQueryable().ToList();
        }
    }
}
