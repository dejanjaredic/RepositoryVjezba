using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RrepTest.MyAttributes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RrepTest.Controllers
{
    [Route("api/[controller]")]
    
    public class TestController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IActionResult AddServices()
        {
            List<string> scopedClass = new List<string>();
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().Where(t => t.GetCustomAttributes<UniversalDIAttribute>().Count() > 0);
            foreach (var type in types)
            {
                Type[] getAllInterfaces = type.GetInterfaces();
                foreach (Type t in getAllInterfaces)
                {
                    if (!t.IsGenericType)
                    {
                        continue;
                    }
                    //scopedClass.Add(t +" |==> "+type);
                }

                var someTypes = type.GetInterfaces();
                foreach (var p in someTypes)
                {
                    scopedClass.Add(p.Name + " IsGeneric: ("+p.IsGenericType + ") |==> " + type.Name + " IsGeneric: (" + type.IsGenericType + ")");
                    scopedClass.Add("------------------------------------------------------------------------");
                }
            }
           return Ok(scopedClass);

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
