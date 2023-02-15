using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class CoberturaController : ApiController
    {
        [HttpGet]
        [Route("api/Cobertura/GetAll")]

        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Cobertura.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
