using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RrepTest.Models;

namespace RrepTest.Interfaces.IRepository
{
    public interface IOsobaRepository
    {
        Osoba GetOsobaById(int id);
    }
}
