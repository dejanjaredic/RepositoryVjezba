using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RrepTest.Interfaces.IRepository;
using RrepTest.Interfaces.IUnitOfWork;

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
            var data = _repository.GetById(id);
            var mappingData = _mapper.Map<TDto>(data);
            return Ok(mappingData);
        }

        // POST api/<controller>
        [HttpPost("add")]
        protected virtual IActionResult Post(TDto input)
        {
            _unitOfWork.Start();
            try
            {
                var maperData = _mapper.Map<T>(input);
                _repository.Add(maperData);
                _unitOfWork.Save();
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                _unitOfWork.Dispose();
            }
            
            return Ok("Sacuvano");
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        protected virtual IActionResult Put(int id, TDto input)
        {
            _unitOfWork.Start();
            try
            {
                var data = _repository.GetById(id);
                _mapper.Map(input, data);
                _unitOfWork.Save();
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                _unitOfWork.Dispose();
            }
            
            return Ok("Promijenjeno");

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        protected virtual IActionResult Delete(int id)
        {
            _repository.Delete(id);
            _unitOfWork.Save();
            return Ok("Obrisano");
        }
    }
}
