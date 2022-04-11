﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOLIT.Productos.Domain.Entities
{
    [Table("EncabezadoFactura")]
    public class EncabezadoFactura
    {
        public int IdFactura { get; set; }
        public string? IdentificacionCliente { get; set; }
        public string? NombreCliente { get; set; }
        public string? DireccioEnvio { get; set; }
        public string? TelefonoCliente { get; set; }
        public DateTime FechaEnvio { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Iva { get; set; }
        public decimal TotalVenta { get; set; }
        public decimal TotalVeEstadonta { get; set; }
    }
}
