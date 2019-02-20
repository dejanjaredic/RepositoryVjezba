using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RrepTest.Interfaces.IRepository;
using RrepTest.Models;

namespace RrepTest.Repository
{
    public class KancelarijaRepository : IKancelarijaRepository
    {
        protected readonly DataContext _context;

        public KancelarijaRepository(DataContext context)
        {
            _context = context;
        }

        public Kancelarija GetById(int id)
        {
            return _context.Kancelarije.Find(id);  
        }

        public void Create(Kancelarija input)
        {
            _context.Kancelarije.Add(input);
           
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Kancelarija> GetAll()
        {
            return _context.Kancelarije.ToList();
        }

        public void Delete(int id)
        {
            var kancelarija = _context.Kancelarije.Find(id);
            _context.Kancelarije.Remove(kancelarija);
        }

        public void EditData(int id, Kancelarija input)
        {
            var kancelarija = _context.Kancelarije.Find(id);
            kancelarija.Opis = input.Opis;
        }
    }
}
