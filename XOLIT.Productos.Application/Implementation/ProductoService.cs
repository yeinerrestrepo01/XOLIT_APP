using AutoMapper;
using System.Net;
using XOLIT.ShoppingCart.Domain.Dto;
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

        private readonly IMapper Mapper;

        /// <summary>
        /// Inicializador de clase servicios <class>ProductoService</class>
        /// </summary>
        /// <param name="productoRepository">productoRepository</param>
        public ProductoService(IProductoRepository productoRepository, IMapper mapper)
        {
            RepositoryProductos = productoRepository;
            Mapper = mapper;
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
                var ResultadoMap = Mapper.Map<List<ProductoDto>>(ResultadoCOnsultaProducto);
                RespuestaTransaccion.Data = ResultadoMap;
                RespuestaTransaccion.IsSuccess = true;
                RespuestaTransaccion.HttpStatusCode = HttpStatusCode.OK;
            }
            else
            {
                RespuestaTransaccion.IsSuccess = true;
                RespuestaTransaccion.HttpStatusCode = HttpStatusCode.NoContent;
            }
            
            return RespuestaTransaccion;
        }
    }
}