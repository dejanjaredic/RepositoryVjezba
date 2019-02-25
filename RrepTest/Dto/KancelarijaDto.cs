using RrepTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RrepTest.Dto
{
    public class KancelarijaDto
    {
        public string Opis { get; set; }

        public List<Osoba> Osoba { get; set; } = new List<Osoba>();
    }
}
