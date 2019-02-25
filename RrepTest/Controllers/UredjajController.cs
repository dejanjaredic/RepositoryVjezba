using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RrepTest.Dto;
using RrepTest.Interfaces.IRepository;
using RrepTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RrepTest.Controllers
{
    [Route("api/[controller]")]
    public class UredjajController : BaseController<Uredjaj, UredjajDto>
    {
        
        private readonly IUredjajRepository _repository;
        private readonly IMapper _mapper;
        public UredjajController(IUredjajRepository repository, IMapper mapper) : base(repository, mapper)
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

        [HttpPost]
        public IActionResult Add(UredjajDto input)
        {
            return base.Post(input);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, UredjajDto input)
        {
            return base.Put(id, input);
        }

        [HttpGet("getbyname")]
        public IActionResult GetByName(string name)
        {
          return Ok(_repository.GetByName(name));
           
        }
       
    }
}
