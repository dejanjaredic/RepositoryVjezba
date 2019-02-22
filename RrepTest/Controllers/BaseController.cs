using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RrepTest.Interfaces.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RrepTest.Controllers
{
    [Route("api/[controller]")]
    public class BaseController<T> : Controller where T : class
    {
        
        private readonly IRepository<T> _repository;
        private readonly IMapper _mapper;
        public BaseController(IRepository<T> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        protected virtual IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        // GET api/<controller>/5
        [HttpGet("getbyid/{id}")]
        protected virtual IActionResult GetById(int id)
        {
            return Ok(_repository.GetById(id));
        }

        // POST api/<controller>
        [HttpPost("add")]
        protected virtual IActionResult Post(T input)
        {
            _repository.Add(input);
            _repository.Save();
            return Ok("Sacuvano");
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        protected virtual IActionResult Put(int id, T input)
        {
            var data = _repository.GetById(id);
            _mapper.Map(input, data);
            _repository.Save();
            return Ok("Promijenjeno");

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        protected virtual IActionResult Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
            return Ok("Obrisano");
        }
    }
}
