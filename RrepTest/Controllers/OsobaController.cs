using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RrepTest.Dto;
using RrepTest.Interfaces.IRepository;
using RrepTest.Interfaces.IUnitOfWork;
using RrepTest.Models;
using RrepTest.MyExceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RrepTest.Controllers
{
    [Route("api/[controller]")]
    public class OsobaController : BaseController<Osoba, OsobaDto>
    {
        private readonly IOsobaRepository _repository;
        private readonly IKancelarijaRepository _kancelarijaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OsobaController(IOsobaRepository repository, IMapper mapper, IKancelarijaRepository kancelarijaRepository, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _kancelarijaRepository = kancelarijaRepository;
            _unitOfWork = unitOfWork;
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

        [HttpPut("izmjena/{id}")]
        public IActionResult EditData(int id, OsobaUpdateDto input)
        {
                var osoba = _repository.GetById(id);
                _mapper.Map<OsobaUpdateDto, Osoba>(input, osoba);
                return Ok(osoba);
        }

        [HttpGet("getbynamesurname")]
        public IActionResult GetByNameSurname(string name, string surname)
        {
            return Ok(_repository.GetByNameSurname(name, surname));

        }

        [HttpPost("kreiranjeosobe/{opis}")]
        public IActionResult CreatePerson(OsobaDto input, string opis)
        {
            
            try
            {
                var kancelarija = _kancelarijaRepository.GeetFromDescription(opis) ?? new Kancelarija { Opis = opis };
                var newPerson = _mapper.Map<Osoba>(input);
                newPerson.Kancelarija = kancelarija;
                _repository.AddPerson(newPerson);

            }
            catch (ExceptionFilterTest e)
            {
                Console.WriteLine(e);
                throw;
            }

            try
            {
                _unitOfWork.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return Ok("Sacuvano");
        }

        //[HttpGet]
        //public IActionResult TestKancelarija(KancelarijaDto input)
        //{
        //    var kancelarija = _kancelarijaRepository.GeetFromDescription(input);
        //    var provjeraKancelarije = _kancelarijaRepository.ProvjeraPostojanjaKancelarije(kancelarija);

        //    return Ok(provjeraKancelarije);
        //}

    }
}
