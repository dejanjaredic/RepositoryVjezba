using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RrepTest.Interfaces.IRepository;
using RrepTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RrepTest.Controllers
{
    [Route("api/[controller]")]
    public class KancelarijaController : Controller
    {
        protected readonly IKancelarijaRepository _repository;

        public KancelarijaController(IKancelarijaRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
            
        }

        // GET api/<controller>/5
        [HttpGet("getbyid/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repository.GetById(id));
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post(Kancelarija input)
        {
           _repository.Create(input);
            _repository.Save();

            return Ok("sacuvano");
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Kancelarija input)
        {
            var kancelarija = _repository.GetById(id);
            kancelarija.Opis = input.Opis;
            _repository.Save();
            return Ok(kancelarija);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
            return Ok("Izbrisano");
        }
    }
}
