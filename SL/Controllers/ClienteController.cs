using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{

    public class ClienteController : ApiController
    {
        [HttpGet]
        [Route("api/Cliente/GetAll")]
        public IHttpActionResult Get()
        {
            ML.Result result = BL.Cliente.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Cliente/GetById/{IdCliente}")]
        // GET: api/Cliente/5
        public IHttpActionResult GetById(int IdCliente)
        {
            ML.Cliente cliente = new ML.Cliente();
            cliente.Planes = new ML.Planes();
            cliente.Coberturas = new ML.Cobertura();
            ML.Result result = BL.Cliente.GetById(IdCliente);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Cliente
        [HttpPost]
        [Route("api/Cliente/Add")]
        public IHttpActionResult Post([FromBody]ML.Cliente cliente)
        {
            ML.Result result = BL.Cliente.Add(cliente);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route ("ap/Cliente/Update")]
        // PUT: api/Cliente/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
        }
    }
}
