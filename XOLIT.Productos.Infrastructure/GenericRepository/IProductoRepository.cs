using XOLIT.ShoppingCart.Domain.Entities;

namespace XOLIT.ShoppingCart.Infrastructure.GenericRepository
{
    public interface IProductoRepository
    {
        /// <summary>
        /// Obtiene el listado general de los productos almacenados en base de datos
        /// </summary>
        /// <returns></returns>
        List<Producto> ObtenerListadoProductos();
    }
}
