using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RrepTest.Dto
{
    public class OsobaUpdateDto
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }  
    }
}
