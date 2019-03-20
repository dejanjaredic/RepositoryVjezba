using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RrepTest.Models;
using RrepTest.MyAttributes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RrepTest.Controllers
{
    [Route("api/[controller]")]
    
    public class TestController : Controller
    {
        private readonly DataContext _context;

        public TestController(DataContext context)
        {
            _context = context;
        }
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
        [HttpGet("expresion1")]
        public IActionResult GetExp()
        {
            int[] num = new[] {2, 5, 3, 6, 8, 7657, 34, 2, 65, 34};

            var n = num.Where(x => x < 5 && x > 2);
            var uredjaji = _context.Uredjaji;
            var uredjajiQuery =
                uredjaji.Select(x => x);
            //x => x < 5 && x > 2
            Expression<Func<int, bool>> test = x => (x < 5 && x > 2);
            ParameterExpression numPar = Expression.Parameter(typeof(int), "x");
            return Ok(test.Body);

            //var randy = new Random();
            //Func<bool> randomBool = () => randy.Next() % 2 == 0;

            //if (randomBool())
            //{
            //    uredjaji = uredjaji.Where(y => y.Id > 2);
            //}

            //if (randomBool())
            //{
            //    uredjaji = uredjaji.Where(x => x.Id > 5);
            //}


            //return Ok(uredjaji);
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
