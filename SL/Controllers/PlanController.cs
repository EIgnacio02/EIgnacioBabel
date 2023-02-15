using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class PlanController : ApiController
    {
        // GET: Empleado
        [HttpGet]
        [Route("api/Plan/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result=BL.Plan.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}