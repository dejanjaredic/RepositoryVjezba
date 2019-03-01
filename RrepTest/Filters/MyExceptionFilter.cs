using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RrepTest.Interfaces.IUnitOfWork;
using RrepTest.Models;
using RrepTest.MyExceptions;

namespace RrepTest.Filters
{
    public class MyExceptionFilter : IExceptionFilter
    {
        
        public void OnException(ExceptionContext context)
        {
            
            context.ExceptionHandled = true;
                    var resp = new ExceptionModel();
                    var error = new Error()
                    {
                        Message = context.Exception.Message,
                        Exception = context.Exception.Data.ToString(),
                        StackTrace = context.Exception.StackTrace
                    };
                    resp.IsError = true;
                    resp.Data = null;
                    resp.Error = error;
                    context.Result = new ObjectResult(resp);
        }
        
    }
}
