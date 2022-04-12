using System.Net;
using XOLIT.ShoppingCart.Commond.AutoMapper;
using XOLIT.ShoppingCart.Domain.Dto;
using XOLIT.ShoppingCart.Domain.Entities;
using XOLIT.ShoppingCart.Infrastructure.GenericRepository;

namespace XOLIT.ShoppingCart.Application
{
    /// <summary>
    /// Clase para implementacion de servicios de Productos
    /// </summary>
    public class ProductoService : IProductoService
    {
        /// <summary>
        /// Objeto de respositorio productos
        /// </summary>
        private readonly IProductoRepository RepositoryProductos;

        /// <summary>
        /// Objeto de MapperXOLIT
        /// </summary>
        private readonly MapperXOLIT<Producto, ProductoDto> MapperProductos;

        /// <summary>
        /// Inicializador de clase servicios <class>ProductoService</class>
        /// </summary>
        /// <param name="productoRepository">productoRepository</param>
        public ProductoService(IProductoRepository productoRepository)
        {
            RepositoryProductos = productoRepository;
            MapperProductos = new MapperXOLIT<Producto, ProductoDto>();

        }

        /// <summary>
        /// obtiene el listado general de productos
        /// </summary>
        /// <returns></returns>
        public ResponseDto<List<ProductoDto>> ObtenerListadoProductos()
        {
            var RespuestaTransaccion = new ResponseDto<List<ProductoDto>>();
            
            var ResultadoCOnsultaProducto = RepositoryProductos.ObtenerListadoProductos();
            if (ResultadoCOnsultaProducto.Any())
            {
                var ResultadoMap = MapperProductos.CreteMapper(ResultadoCOnsultaProducto);
                RespuestaTransaccion.Data = ResultadoMap;
                RespuestaTransaccion.Count = ResultadoMap.Count;
                RespuestaTransaccion.IsSuccess = true;
                RespuestaTransaccion.HttpStatusCode = HttpStatusCode.OK;
            }
            else
            {
                RespuestaTransaccion.IsSuccess = true;
                RespuestaTransaccion.Count = 0;
                RespuestaTransaccion.HttpStatusCode = HttpStatusCode.NoContent;
            }
            
            return RespuestaTransaccion;
        }
    }
}