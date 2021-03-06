﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RrepTest.Interfaces.IRepository;
using RrepTest.Interfaces.IUnitOfWork;
using RrepTest.Models;
using RrepTest.MyExceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RrepTest.Controllers
{
    [Route("api/[controller]")]
    public class BaseController<T, TDto, Ttype> : Controller where T : class where TDto : class
    {
        
        private readonly IRepository<T, Ttype> _repository;
        private readonly IMapper _mapper;
        public BaseController(IRepository<T, Ttype> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        protected virtual IActionResult Get()
        {
            var data = _repository.GetAll();
            var mapData = _mapper.Map<IEnumerable<TDto>>(data);
            return Ok(mapData);
        }

        // GET api/<controller>/5
        [HttpGet("getbyid/{id}")]
        protected virtual IActionResult GetById(Ttype id)
        {
                var data = _repository.GetById(id);
                var mappingData = _mapper.Map<TDto>(data);
                return Ok(mappingData);
        }

        // POST api/<controller>
        [HttpPost("add")]
        protected virtual IActionResult Post(TDto input)
        {

                var maperData = _mapper.Map<T>(input);
                _repository.Add(maperData);
                return Ok(input);

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        protected virtual IActionResult Put(Ttype id, TDto input)
        {
                var data = _repository.GetById(id);
                _mapper.Map(input, data);
                return Ok("Promijenjeno");
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        protected virtual IActionResult Delete(Ttype id)
        {
            var data = _repository.GetById(id);
            _repository.Delete(id);
            return Ok(data);
        }


    }
}
