using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RrepTest.Interfaces.IRepository;
using RrepTest.Interfaces.IUnitOfWork;
using RrepTest.MyExceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RrepTest.Controllers
{
    [Route("api/[controller]")]
    public class BaseController<T, TDto> : Controller where T : class where TDto : class
    {
        
        private readonly IRepository<T> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public BaseController(IRepository<T> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
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
        protected virtual IActionResult GetById(int id)
        {
            try
            {
                var data = _repository.GetById(id);
                var mappingData = _mapper.Map<TDto>(data);
                return Ok(mappingData);
            }
            catch (NotFintInDatabase e)
            {
                return NotFound(e.Message);
            }
            
            
        }

        // POST api/<controller>
        [HttpPost("add")]
        protected virtual IActionResult Post(TDto input)
        {
            //_unitOfWork.Start();
            try
            {
                var maperData = _mapper.Map<T>(input);
                _repository.Add(maperData);
                //_unitOfWork.Save();
                //_unitOfWork.Commit();
                return Ok("Sacuvano");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            //finally
            //{
            //    _unitOfWork.Dispose();
            //}
            
            
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        protected virtual IActionResult Put(int id, TDto input)
        {
            //_unitOfWork.Start();
            try
            {
                var data = _repository.GetById(id);
                _mapper.Map(input, data);
                //_unitOfWork.Save();
                //_unitOfWork.Commit();
                return Ok("Promijenjeno");
            }
            catch (NotFintInDatabase e)
            {
                return NotFound(e.Message);
            }
            //finally
            //{
            //    _unitOfWork.Dispose();
            //}
            
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        protected virtual IActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return Ok("Obrisano");
            }
            catch (NotFintInDatabase e)
            {
                return NotFound(e.Message);
            }
            //_unitOfWork.Save();
            
        }
    }
}
