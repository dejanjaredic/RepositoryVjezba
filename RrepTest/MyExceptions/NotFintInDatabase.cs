using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RrepTest.MyExceptions
{
    public class NotFintInDatabase : Exception
    {
        
        public NotFintInDatabase(string message) : base(message)
        {
        }

       
    }
}
