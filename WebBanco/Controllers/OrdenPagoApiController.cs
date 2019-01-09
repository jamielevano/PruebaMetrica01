using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBanco.Models;
using WebBanco.DAO;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebBanco.Controllers
{
    [Route("api/[controller]")]
    public class OrdenPagoApiController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<OrdenPago> Get(int idSucursal, string moneda)
        {
            OrdenPagoDao oOrdenPagoDao = new OrdenPagoDao();
            var data = oOrdenPagoDao.Listar().Where(p => p.IdSucursal == idSucursal && p.Moneda.ToUpper() == moneda.ToUpper());
            return data;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
