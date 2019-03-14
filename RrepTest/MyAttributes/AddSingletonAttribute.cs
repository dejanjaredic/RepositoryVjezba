using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RrepTest.MyAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AddSingletonAttribute : Attribute
    {
    }
}
