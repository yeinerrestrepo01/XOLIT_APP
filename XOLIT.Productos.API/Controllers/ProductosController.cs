using Microsoft.AspNetCore.Mvc;
using System.Net;
using XOLIT.ShoppingCart.Application;
using XOLIT.ShoppingCart.Domain.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XOLIT.ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        public IProductoService ProductoService;
        public ProductosController(IProductoService productoService)
        {
            ProductoService = productoService;
        }
        // GET: api/<ProductosController>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseDto<List<ProductoDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseDto<List<ProductoDto>>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseDto<List<ProductoDto>>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ResponseDto<List<ProductoDto>>), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseDto<List<ProductoDto>>), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Get()
        {
            var ResultadoTransaccion = ProductoService.ObtenerListadoProductos();
            return StatusCode((int)ResultadoTransaccion.HttpStatusCode, ResultadoTransaccion);
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
