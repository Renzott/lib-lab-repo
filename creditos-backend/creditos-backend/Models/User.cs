using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creditos_backend.Models
{
    public class User
    {  
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string password { get; set; }
    }
}
