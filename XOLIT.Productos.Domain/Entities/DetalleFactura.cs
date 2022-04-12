using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XOLIT.ShoppingCart.Domain.Entities
{
    /// <summary>
    /// Entidad DetalleFactura
    /// </summary>
    [Table("DetalleFactura")]
    public class DetalleFactura
    {
        [Key]
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Iva { get; set; }
        public decimal ValorIva { get; set; }
        public decimal ValorCompra { get; set; }

        public virtual Producto? ProductoNavegacion { get; set; }
        public virtual EncabezadoFactura? EncabezadoFacturaNavegacion { get; set; }
    }
}
