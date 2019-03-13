using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RrepTest.Models;
using RrepTest.MyExceptions;

namespace RrepTest.Filters
{
    public class RresultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            var result = context.Result as ObjectResult;
            if (result.StatusCode >= 200 && result.StatusCode <= 300)
            {
                var resp = new ExceptionResponse();
                resp.Data = result.Value;
                resp.IsError = false;
                resp.Error = null;

                context.Result = new ObjectResult(resp);
            }
            else if (result.StatusCode >=400 && result.StatusCode <= 500)
            {
                //result.StatusCode = (int) HttpStatusCode.InternalServerError;
                var resp = new ExceptionResponse();
                resp.Data = "Internal Server Error";
                resp.IsError = true;
                resp.Error = null;

                context.Result = new ObjectResult(resp) {StatusCode = StatusCodes.Status500InternalServerError};
            }
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            return;
        }
    }
}
