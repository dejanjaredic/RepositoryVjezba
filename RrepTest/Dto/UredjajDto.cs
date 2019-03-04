using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RrepTest.Dto
{
    public class UredjajDto
    {
        [Required]
        public string Name { get; set; }
    }
}
