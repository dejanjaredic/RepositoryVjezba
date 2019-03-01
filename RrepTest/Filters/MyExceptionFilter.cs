using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using RrepTest.Interfaces.IUnitOfWork;

namespace RrepTest.Filters
{
    public class MyExceptionFilter : IExceptionFilter
    {
        private readonly IUnitOfWork _unitOfWork;

        public MyExceptionFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnException(ExceptionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
