using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RrepTest.Interfaces.IUnitOfWork;
using RrepTest.MyExceptions;

namespace RrepTest.Filters
{
    public class UnitFilter : IActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            _unitOfWork.Start();
            bool complited = false;
            try
            {
                _unitOfWork.Save();
                complited = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
                complited = false;
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

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }  
    }
}
