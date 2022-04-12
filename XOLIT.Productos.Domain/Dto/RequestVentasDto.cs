namespace XOLIT.ShoppingCart.Domain.Dto
{
    /// <summary>
    /// Entidad  de request para ventas
    /// </summary>
    public class RequestVentasDto
    {
        public RequestVentaGeneralDto? InformacionGeneral {get; set; }
        public DetalleVentaRequestDto? DetalleVenta {get; set; }
    }
}
