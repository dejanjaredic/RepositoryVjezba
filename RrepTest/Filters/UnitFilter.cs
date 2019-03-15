using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RrepTest.Interfaces.IUnitOfWork;
using RrepTest.Models;
using RrepTest.MyExceptions;
using Swashbuckle.AspNetCore.Swagger;

namespace RrepTest.Filters
{
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
            var exceprionInRrequest = context.HttpContext.Request.QueryString;
            if (!request)
            {
                _unitOfWork.Start();
                begin = true;
            }
            
            bool complited = false;
            try
            {
                await next();
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
