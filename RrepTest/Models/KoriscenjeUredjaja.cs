using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RrepTest.Models
{
    public class KoriscenjeUredjaja
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime VrijemeOd { get; set; }
        public DateTime? VrijemeDo { get; set; }

        public int UredjajId { get; set; }
        [ForeignKey("UredjajId")]
        public Uredjaj Uredjaj { get; set; }

        public int OsobaId { get; set; }
        [ForeignKey("OsobaId")]
        public Osoba Osoba { get; set; }
    }
}
