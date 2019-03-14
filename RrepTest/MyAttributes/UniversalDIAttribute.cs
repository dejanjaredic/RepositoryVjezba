using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RrepTest.MyAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class UniversalDIAttribute : Attribute
    {
        public EnumServiceForDI Name { get; }

        public UniversalDIAttribute(EnumServiceForDI name = EnumServiceForDI.Transient)
        {
            this.Name = name;
        }
    }
}
