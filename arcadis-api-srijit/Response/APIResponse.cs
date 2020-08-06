using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace arcadis_api_srijit.Response
{
    public static class APIResponse
    {
        public static ResponseModel CreateResponse<T>(T data, string message, HttpStatusCode httpStatusCode)
        {
            if (data != null)
            {
                ResponseModel responseModel = new ResponseModel();
                responseModel.Data = data;
                responseModel.Status = httpStatusCode;
                responseModel.Message = message;
                return responseModel;
            }
            return null;
        }

        public static ResponseModel CreateErrorResponse(string message, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
                ResponseModel responseModel = new ResponseModel();
                responseModel.Status = httpStatusCode;
                responseModel.Message = message;
                return responseModel;
        }
    }
}
