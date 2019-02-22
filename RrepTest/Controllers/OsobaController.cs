﻿using System;
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
    public class OsobaController : BaseController<Osoba>
    {
        private readonly IOsobaRepository _repository;
        private readonly IMapper _mapper;
        public OsobaController(IOsobaRepository repository, IMapper mapper) : base(repository, mapper)
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

        [HttpPost("kreiranjeosobe")]
        public IActionResult CreatePerson(Osoba input)
        {
            _repository.AddData(input);

            return Ok("Sacuvano");
        }

        [HttpPut("izmjena/{id}")]
        public IActionResult EditData(int id, Osoba input)
        {
            var osoba = _repository.GetById(id);
            osoba.Ime = input.Ime;
            osoba.Prezime = input.Prezime;
            _repository.Save();

            return Ok(osoba);
        }

    }
}
