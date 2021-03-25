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
    public class PessoaController : ControllerBase
    {
        // GET: api/<PessoaController>
        [HttpGet]
        public IEnumerable<Pessoa> Get()
        {
            var repository = new PessoaDAO();
            return repository.SelectAllPessoa();
        }

        // GET api/<PessoaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PessoaController>
        [HttpPost]
        public void Post(string nome, int idade)
        {

            var repository = new PessoaDAO();
            repository.InsertDataPessoa(nome, idade);
        }

        // PUT api/<PessoaController>/5
        [HttpPut]
        public void Put(Pessoa pessoa)
        {
            var repository = new PessoaDAO();
            repository.UpdateDataPessoa(pessoa);
        }

        // DELETE api/<PessoaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var repository = new PessoaDAO();
            repository.DeleteDataPessoa(id);
        }
    }
}
