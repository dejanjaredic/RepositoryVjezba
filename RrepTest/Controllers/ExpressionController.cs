using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using RrepTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RrepTest.Controllers
{
    [Route("api/[controller]")]
    public class ExpressionController : QueryInfo
    {
        private readonly DataContext _context;

        public ExpressionController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IQueryable Aloha([FromBody]QueryInfo input)
        {
            var korUredjaja = _context.KorisceniUredjaji;
            var expression = GetWhereExpression<KoriscenjeUredjaja>();
            var order = OrderThings<KoriscenjeUredjaja>();
            var result = korUredjaja.AsQueryable().Where(expression).OrderBy(order);
            
            return result;
        }
 
    }
}
