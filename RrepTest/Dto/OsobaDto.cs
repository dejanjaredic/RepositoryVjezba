using RrepTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RrepTest.Dto
{
    public class OsobaDto
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int KancelarijaId { get; set; }
        [ForeignKey("KancelarijaId")]
        public KancelarijaDto Kancelarija { get; set; }
    }
}
