using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creditos_backend.Models
{
    public class Client
    {
        public Guid UUID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public int DNI { get; set; }
        public string Foto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

    }
}
