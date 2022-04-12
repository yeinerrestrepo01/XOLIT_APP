namespace XOLIT.ShoppingCart.Domain.Dto
{
    /// <summary>
    /// Detalle Factura Dto
    /// </summary>
    public class DetalleFacturaDto
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Iva { get; set; }
        public decimal ValorIva { get; set; }
        public decimal ValorCompra { get; set; }
    }
}
