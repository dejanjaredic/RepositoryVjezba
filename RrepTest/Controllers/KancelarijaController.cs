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
    public class KancelarijaController : BaseController<Kancelarija, KancelarijaDto>
    {
        private readonly IKancelarijaRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public KancelarijaController(IKancelarijaRepository repository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
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
        public IActionResult Add(KancelarijaDto input)
        {
            return base.Post(input);
        }

        [HttpPut("edit/{id}")]
        public IActionResult Edit(int id, Kancelarija input)
        {
            //_unitOfWork.Start();
            try
            {
                var kancelarija = _repository.GetById(id);
                kancelarija.Opis = input.Opis;
                _repository.Edit(id, kancelarija);
                //_unitOfWork.Save();
                //_unitOfWork.Commit();
            }
            catch (NotFintInDatabase e)
            {
                return NotFound(e.Message);
            }
            //finally
            //{
            //    _unitOfWork.Dispose();
            //}
            
            return Ok("Promijenjeno");

        }

    }
}
