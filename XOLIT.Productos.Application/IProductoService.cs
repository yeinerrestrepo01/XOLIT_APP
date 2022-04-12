using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
