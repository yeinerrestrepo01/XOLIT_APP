using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOLIT.Productos.Domain.Dto
{
    /// <summary>
    /// Dto productos
    /// </summary>
    public class ProductoDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public decimal ValorVentaConIva { get; set; }
        public int CantidadUnidadesInventario { get; set; }
        public decimal PorcentajeIVAAplicado { get; set; }
    }
}
