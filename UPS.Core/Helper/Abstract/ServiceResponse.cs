using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPS.Core.Helper.Abstract.Response;

namespace UPS.Core.Helper.Abstract
{
    public class ServiceResponse<T>
    {
        public ServiceResponse(T data,Meta meta)
        {
            Error = false;
            Data = data;
            ServiceMessage = "Success";
            Meta = meta;
        }
        public ServiceResponse(string message = null, bool error = false)
        {
            Error = error;
            ServiceMessage = message;
        }
        public string ServiceMessage { get; set; }
        public bool Error { get; set; } = false;
        public Meta Meta { get; set; }
        public T Data { get; set; }
    }
}
