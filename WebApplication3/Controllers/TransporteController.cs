using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.DAO;
using Teste.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransporteController : ControllerBase
    {
        // GET: api/<TransporteController>
        [HttpGet]
        public IEnumerable<Transporte> Get()
        {
            var repository = new TransporteDAO();
            return repository.SelectAllTransporte();
        }

        // GET api/<TransporteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TransporteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TransporteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TransporteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
