using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RadnoMjestoVjezba.Middleware;
using RrepTest.Interfaces.IUnitOfWork;
using RrepTest.Models;
using RrepTest.MyAttributes;
using RrepTest.MyExceptions;
using Swashbuckle.AspNetCore.Swagger;

namespace RrepTest.Filters
{
    [UniversalFilterAttribut]
    public class UnitFilter : IAsyncActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            bool begin = false;
            var request = context.HttpContext.Request.Method.Equals("GET");
            if (!request)
            {
                _unitOfWork.Start();
                begin = true;
            }
            bool complited = false;
            try
            {
                var awaitNext = await next();
                if (awaitNext.Exception != null)
                {
                    throw awaitNext.Exception;
                }
                if (begin)
                {
                    _unitOfWork.Save();
                    complited = true; 
                }
            }
            catch (ExceptionFilterTest e)
            {
                complited = false;
            }
            finally
            {
                if (!request)
                {
                    if (complited)
                    {
                        _unitOfWork.Commit();
                        _unitOfWork.Dispose();
                    }
                    else
                    {
                        _unitOfWork.Dispose();
                    }
                }
            }
        }  
    }
}
