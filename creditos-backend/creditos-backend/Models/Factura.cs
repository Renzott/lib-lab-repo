using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creditos_backend.Models
{
    public class Factura
    {
		public string id { get; set; }
		public decimal import { get; set; }
		public decimal igv { get; set; }
		public DateTime fechaEmision { get; set; }
		public DateTime fechaVencimiento { get; set; }
		public int estadoFactura { get; set; }
		public int estado { get; set; }
		public string observaciones { get; set; }
		public int creditoID { get; set; }
	}
}
