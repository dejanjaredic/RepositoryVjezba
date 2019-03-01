using System;
using System.Collections.Generic;
using System.Linq;
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
            if (result.StatusCode == StatusCodes.Status200OK)
            {
                var resp = new ExceptionModel();
                resp.Data = result.Value;
                resp.IsError = false;
                resp.Error = null;

                context.Result = new ObjectResult(resp);
            }
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            return;
        }
    }
}
