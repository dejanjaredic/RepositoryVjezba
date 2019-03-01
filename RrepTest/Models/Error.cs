using System;

namespace RrepTest.Models
{
    public class Error
    {
        //public int Id { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
    }
}