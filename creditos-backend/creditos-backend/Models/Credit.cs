    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creditos_backend.Models
{
    public class Credit
    {
        public int ID { get; set; }
        public Guid ClientID { get; set; }
        public decimal Cantidad { get; set; }
        public int Estado { get; set; }

    }
}
