using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOLIT.Productos.Domain.Entities
{
    [Table("DetalleFactura")]
    public class DetalleFactura
    {
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
