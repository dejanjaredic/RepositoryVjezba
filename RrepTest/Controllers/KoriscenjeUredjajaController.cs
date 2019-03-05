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
using RrepTest.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RrepTest.Controllers
{
    [Route("api/[controller]")]
    public class KoriscenjeUredjajaController : BaseController<KoriscenjeUredjaja, KoriscenjeUredjajaDto, int>
    {
        private readonly IKoriscenjeUredjajaRepository _repository;
        private readonly IOsobaRepository _osobaRepository;
        private readonly IUredjajRepository _uredjajRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public KoriscenjeUredjajaController
        (
            IKoriscenjeUredjajaRepository repository,
            IMapper mapper,
            IOsobaRepository osobaRepository,
            IUredjajRepository uredjajRepository,
            IUnitOfWork unitOfWork
            ) 
            : base(repository, mapper, unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _osobaRepository = osobaRepository;
            _uredjajRepository = uredjajRepository;
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

        [HttpPost("add/{name}/{surname}/{device}")]
        public IActionResult Post(string name, string surname, string device)
        {

            var osoba = _osobaRepository.GetByNameSurname(name, surname);
            var uredjaj = _uredjajRepository.GetByName(device);
            _repository.AddData(osoba, uredjaj);
            return Ok("Osoba: "+name+" "+ surname + " je zaduzila: "+device);
        }


    }
}
