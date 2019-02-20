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
    public class OsobaController : Controller
    {
        protected readonly DataContext _context;
        protected readonly IOsobaRepository _repository;
        public OsobaController(DataContext context, IOsobaRepository repository)
        {
            _context = context;
            _repository = repository; 
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var osoba = _repository.GetOsobaById(id);
            return Ok(osoba);
        }
        
    }
}
