using RrepTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RrepTest.Interfaces.IRepository;

namespace RrepTest.Repository
{
    public class OsobaRepository : IOsobaRepository
    {
        protected readonly DataContext _context;

        public OsobaRepository(DataContext context)
        {
            _context = context;
        }
        public Osoba GetOsobaById(int id)
        {
            return _context.Osobe.Find(id);
        }

    }
}
