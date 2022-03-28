using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.Core.Helper.Abstract
{
    public class Pagination
    {
        public int Total { get; set; }
        public int Pages { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
