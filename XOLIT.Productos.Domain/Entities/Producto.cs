using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XOLIT.ShoppingCart.Domain.Entities
{
    /// <summary>
    /// Entidad Producto
    /// </summary>
    /// 

    [Table("Producto")]
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public decimal ValorVentaConIva { get; set; }
        public int CantidadUnidadesInventario { get; set; }
        public decimal PorcentajeIVAAplicado { get; set; }
    }
}
