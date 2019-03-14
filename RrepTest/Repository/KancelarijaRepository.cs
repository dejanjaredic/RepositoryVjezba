using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RrepTest.Dto;
using RrepTest.Interfaces.IRepository;
using RrepTest.Models;
using RrepTest.MyAttributes;

namespace RrepTest.Repository
{
    [UniversalDI]
    public class KancelarijaRepository : Repository<Kancelarija, int>, IKancelarijaRepository
    {
        protected readonly DataContext _context;

        public KancelarijaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public Kancelarija GeetFromDescription(string name)
        {
            var kancelarija = _context.Kancelarije;
            var kancelarijeQuery =
                kancelarija.FirstOrDefault(x => x.Opis.Contains(name));

            return kancelarijeQuery;
        }

        public bool ProvjeraPostojanjaKancelarije(int id)
        {
            bool postoji = false;

            var kancelarija = _context.Kancelarije;
            var kancelarijaQuery =
                kancelarija.Where(x => x.Id == id);
            var rezultat = kancelarijaQuery.Count();
            if (rezultat != 0)
            {
                postoji = true;
            }

            return postoji;
        }

        public void KreiranjeKancelarije(Kancelarija input)
        {
            _context.Kancelarije.Add(input);
        }
    }
}
