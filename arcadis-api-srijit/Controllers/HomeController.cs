using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using arcadis_api_srijit.Response;
using BAL.Contract;
using BAL.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace arcadis_api_srijit.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IService _service;
        public HomeController(IService service)
        {
            this._service = service;
        }
        // GET: api/Home
        [HttpGet]
        [Route("get-all-data")]
        public ActionResult Get()
        {
            try
            {
                var returnValue = this._service.GetUserWorkSheets();
                return Ok(APIResponse.CreateResponse(returnValue, "All Records", System.Net.HttpStatusCode.OK));
            }
            catch(Exception ex)
            {
                return Ok(APIResponse.CreateErrorResponse("Exception : " + ex.Message, System.Net.HttpStatusCode.BadGateway));
            }
        }

        [HttpPost]
        [Route("insertdata")]
        public ActionResult InsertRecord(UserWorkSheet userWorkSheet)
        {
            try
            {
                var returnValue = this._service.InsertRecord(userWorkSheet);
                if(returnValue!=null && returnValue.Count() > 0)
                {
                    return Ok(APIResponse.CreateResponse(returnValue, "All Records", System.Net.HttpStatusCode.OK));
                }
                else
                {
                    return BadRequest(APIResponse.CreateErrorResponse("Item not Created" , System.Net.HttpStatusCode.BadRequest));
                }
                
            }
            catch (Exception ex)
            {
                return Ok(APIResponse.CreateErrorResponse("Exception : " + ex.Message, System.Net.HttpStatusCode.BadGateway));
            }
        }


        [HttpPut]
        [Route("updatedata")]
        public ActionResult UpdateRecord(UserWorkSheet userWorkSheet)
        {
            try
            {
                var returnValue = this._service.UpdateRecord(userWorkSheet);
                if (returnValue != null && returnValue.Count() > 0)
                {
                    return Ok(APIResponse.CreateResponse(returnValue, "All Records", System.Net.HttpStatusCode.OK));
                }
                else
                {
                    return BadRequest(APIResponse.CreateErrorResponse("Item not updated", System.Net.HttpStatusCode.BadRequest));
                }

            }
            catch (Exception ex)
            {
                return Ok(APIResponse.CreateErrorResponse("Exception : " + ex.Message, System.Net.HttpStatusCode.BadGateway));
            }
        }
        [HttpDelete]
        [Route("deletedata/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var returnValue = this._service.DeleteRecord(id);
                if (returnValue != null && returnValue.Count() > 0)
                {
                    return Ok(APIResponse.CreateResponse(returnValue, "All Records", System.Net.HttpStatusCode.OK));
                }
                else
                {
                    return BadRequest(APIResponse.CreateErrorResponse("Item not deleted", System.Net.HttpStatusCode.BadRequest));
                }

            }
            catch (Exception ex)
            {
                return Ok(APIResponse.CreateErrorResponse("Exception : " + ex.Message, System.Net.HttpStatusCode.BadGateway));
            }
        }

        [HttpGet]
        [Route("search/{searchString}")]
        public ActionResult Search(string searchString)
        {
            try
            {
                var returnValue = this._service.Search(searchString);
                if (returnValue != null && returnValue.Count() > 0)
                {
                    return Ok(APIResponse.CreateResponse(returnValue, "Search Records", System.Net.HttpStatusCode.OK));
                }
                else
                {
                    return BadRequest(APIResponse.CreateErrorResponse("Item not deleted", System.Net.HttpStatusCode.BadRequest));
                }

            }
            catch (Exception ex)
            {
                return Ok(APIResponse.CreateErrorResponse("Exception : " + ex.Message, System.Net.HttpStatusCode.BadGateway));
            }
        }
    }
}
