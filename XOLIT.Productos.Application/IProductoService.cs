using XOLIT.ShoppingCart.Domain.Dto;

namespace XOLIT.ShoppingCart.Application
{
    public interface IProductoService
    {
        /// <summary>
        /// Obtiene el listado general de productos
        /// </summary>
        /// <returns></returns>
        public ResponseDto<List<ProductoDto>> ObtenerListadoProductos();
    }
}
