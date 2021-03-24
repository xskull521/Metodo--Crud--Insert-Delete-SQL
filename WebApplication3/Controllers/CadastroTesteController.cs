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
    public class CadastroTesteController : ControllerBase
    {
        // GET: api/<CadastroTesteController>
        [HttpGet]
        public IEnumerable<CadastroTeste> Get()
        {
            var repository = new CadastroTesteDAO();
            return repository.SelectAllClients();
        }

        // GET api/<CadastroTesteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CadastroTesteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CadastroTesteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CadastroTesteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
