using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RrepTest.Models
{
    public class ExceptionResponse
    {
        //public int Id { get; set; }
        public object Data { get; set; }
        public bool IsError { get; set; }
        public Error Error { get; set; }
    }
}
