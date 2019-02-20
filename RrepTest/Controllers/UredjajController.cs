using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RrepTest.Interfaces.IRepository;
using RrepTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RrepTest.Controllers
{
    [Route("api/[controller]")]
    public class UredjajController : Controller
    {
        
        protected readonly IUredjajRepository _repository;
        public UredjajController(IUredjajRepository repository)
        {
           
            _repository = repository;
        }
        [HttpPost("kreiraj")]
        public ActionResult CreateData(Uredjaj input)
        {
            return Ok(_repository.AddData(input));
        }

        [HttpGet("getalldata")]
        public ActionResult<IEnumerable<Uredjaj>> GetAllData()
        {
            return Ok(_repository.GetData());
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_repository.GetById(id));
        }

        [HttpPut("editdata/{id}")]
        public IActionResult Editdata(int id, Uredjaj input)
        {
            var getData = _repository.GetById(id);
            getData.Name = input.Name;
            _repository.Save();
            return Ok("Izmijenjano");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteData(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
           _repository.Delete(id);
            _repository.Save();

            return Ok("deleted");
        }
    }
}
