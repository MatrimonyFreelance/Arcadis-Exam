using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace arcadis_api_srijit.Response
{
    public class ResponseModel
    {
        public object Data { get; set; }
        public HttpStatusCode Status { get; set; }

        public string Message { get; set; }
    }
}
