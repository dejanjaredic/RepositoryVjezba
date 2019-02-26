using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RrepTest.Interfaces.Ather;

namespace RrepTest.Models
{
    public class Customer : IDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
    }
}
