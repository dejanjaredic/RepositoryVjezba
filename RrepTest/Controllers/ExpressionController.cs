using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RrepTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RrepTest.Controllers
{
    [Route("api/[controller]")]
    public class ExpressionController : Controller
    {
        private readonly DataContext _context;

        public ExpressionController(DataContext context)
        {
            _context = context;
        }

        /*
         *_context.DeviceUsage.Where(x => x.PersonId == 1)
         * .OrderByDescending(x => x.DataFrom)
         * .ThenBy(x => x.Device.Name)
         * .Skip(0).Take(10)
        // */
        [HttpGet]
        public IActionResult GetDeviceUsage()
        {
            return Ok();
        }
        //var expression = GetWhereExpression<Entitet>(op, propName, stringValue);
        //var result = lista.AsQueryable().Where(expression);

        [HttpGet("proba")]
        public Expression<Func<KoriscenjeUredjaja, bool>> GetWhereExpression(string propName, int value)
        {

            // ---------- Where --------------
            ParameterExpression paramExp1 = Expression.Parameter(typeof(KoriscenjeUredjaja), "x");
            ConstantExpression constExp1 = Expression.Constant(value, typeof(int));
            var propExp1 = Expression.Property(paramExp1, propName);
            BinaryExpression equal = Expression.Equal(propExp1, constExp1);
            Expression<Func<KoriscenjeUredjaja, bool>> finalWhereExpresion = Expression.Lambda<Func<KoriscenjeUredjaja, bool>>(equal, paramExp1);
            // -------------
            _context.KorisceniUredjaji.Where(finalWhereExpresion);
            return finalWhereExpresion;
        }
        [HttpGet("proba2")]
        public Expression getOrderExpression(string paramName)
        {
            ParameterExpression paramExp1 = Expression.Parameter(typeof(KoriscenjeUredjaja), "x");
            var propExp2 = Expression.Property(paramExp1, paramName);
            var objExp = Expression.Convert(propExp2, typeof(object));
            Expression<Func<KoriscenjeUredjaja, object>> finalOrderExp =
                Expression.Lambda<Func<KoriscenjeUredjaja, object>>(objExp, paramExp1);

            return finalOrderExp;
        }

        




    }
}
