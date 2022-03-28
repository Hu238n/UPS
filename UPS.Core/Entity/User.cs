using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.Core.Entity
{
    public class User:BaseEntity<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
    }
}
