using System;
using System.Collections.Generic;
using System.Linq;
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
            _unitOfWork.Start();
            bool complited = false;
            try
            {
                await next();
                _unitOfWork.Save();
                complited = true;
            }
            catch (ExceptionFilterTest e)
            {
                Console.WriteLine(e);
                complited = false;
                throw;
            }
            finally
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
