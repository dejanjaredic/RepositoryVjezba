using RrepTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RrepTest.Dto
{
    public class KoriscenjeUredjajaDto
    {
        public DateTime VrijemeOd { get; set; }
        public DateTime? VrijemeDo { get; set; }

        public int UredjajId { get; set; }
        [ForeignKey("UredjajId")]
        public UredjajDto Uredjaj { get; set; }

        public int OsobaId { get; set; }
        [ForeignKey("OsobaId")]
        public OsobaDto Osoba { get; set; }
    }
}
