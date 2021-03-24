using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Entidades;
using Teste.DAO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        // GET: api/<EnderecoController>
        [HttpGet]
        public IEnumerable<Endereco> Get()
        {
            var repository = new EnderecoDAO();
            return repository.SelectAllEndereco();
        }

        // GET api/<EnderecoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EnderecoController>
        [HttpPost]
        public void Post(string Rua, int Numero, string Complemento)
        {

            var repository = new EnderecoDAO();
             repository.InsertData(Rua, Numero, Complemento );
        }

        // PUT api/<EnderecoController>/5
        [HttpPut]
        public void Put(Endereco endereco)
        {
            var repository = new EnderecoDAO();
            repository.UpdateData(endereco);
        }

        // DELETE api/<EnderecoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var repository = new EnderecoDAO();
            repository.DeleteData(id);
        }
    }
}
