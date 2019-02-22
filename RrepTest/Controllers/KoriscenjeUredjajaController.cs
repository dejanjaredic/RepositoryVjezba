using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RrepTest.Interfaces.IRepository;
using RrepTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RrepTest.Controllers
{
    [Route("api/[controller]")]
    public class KoriscenjeUredjajaController : BaseController<KoriscenjeUredjaja>
    {
        private readonly IKoriscenjeUredjajaRepository _repository;
        private readonly IMapper _mapper;
        public KoriscenjeUredjajaController(IKoriscenjeUredjajaRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        [HttpGet("getalldata")]
        public IActionResult Get()
        {
            return base.Get();
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            return base.GetById(id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return base.Delete(id);
        }

        // POST api/<controller>
        [HttpPost("add/{name}/{surname}/{devices}")]
        public IActionResult Post(string name, string surname, string devices)
        {
            _repository.AddData(name, surname, devices);

            return Ok("Created");
        }


    }
}
