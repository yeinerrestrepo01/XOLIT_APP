namespace XOLIT.ShoppingCart.Domain.Dto
{
    public class DetalleVentaRequestDto
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Iva { get; set; }
        public decimal ValorIva { get; set; }
        public decimal ValorCompra { get; set; }

    }
}
