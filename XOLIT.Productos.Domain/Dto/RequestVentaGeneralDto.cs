using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOLIT.ShoppingCart.Domain.Dto
{
    public class RequestVentaGeneralDto
    {
        public string? IdentificacionCliente { get; set; }
        public string? NombreCliente { get; set; }
        public string? DireccioEnvio { get; set; }
        public string? TelefonoCliente { get; set; }
        public DateTime FechaEnvio { get; set; }
    }
}
