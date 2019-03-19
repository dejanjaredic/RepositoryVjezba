using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using RrepTest.Interfaces.IUnitOfWork;
using RrepTest.Models;
using RrepTest.MyAttributes;
using RrepTest.MyExceptions;

namespace RrepTest.Filters
{
    [UniversalFilterAttribut]
    public class MyExceptionFilter : IExceptionFilter
    {
        
        public void OnException(ExceptionContext context)
        {
            //var result = context.Result as ObjectResult;
            //if (result.StatusCode != StatusCodes.Status200OK)
            //{
                context.ExceptionHandled = true;
                var resp = new ExceptionResponse();
                var error = new Error()
                {
                    Message = context.Exception.Message,
                    Exception = context.Exception.Data.ToString(),
                    StackTrace = context.Exception.StackTrace
                };
            
            if (context.Exception.GetBaseException() is SqlException ex)
            {
                var num = ex.Number;
                if (num == 547)
                {
                    error.Message = "Brisanje nije dozvoljeno";
                }
            }
            resp.IsError = true;
                resp.Data = null;
                resp.Error = error;
                context.Result = new ObjectResult(resp);
            //}
                
        }


    }
}
