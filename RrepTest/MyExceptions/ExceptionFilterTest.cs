using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RrepTest.MyExceptions
{
    public class ExceptionFilterTest : Exception
    {
        public ExceptionFilterTest() : base()
        {   
        }
        public ExceptionFilterTest(string message) : base(message)
        {   
        }
        public ExceptionFilterTest(string message, Exception inner) : base(message, inner)
        {   
        }
        public ExceptionFilterTest(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {   
        }
    }
}
