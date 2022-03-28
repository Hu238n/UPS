using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.Core.Helper.Abstract.Response
{
    // Root myDeserializedClass =;
 

    public class Meta
    {
        public Pagination Pagination { get; set; }
    }

   

    public class Root<T>
    {
        public int Code { get; set; }
        public Meta Meta { get; set; }
        public T Data { get; set; }
    }


}
