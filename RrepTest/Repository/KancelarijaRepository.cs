using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RrepTest.Interfaces.IRepository;
using RrepTest.Models;

namespace RrepTest.Repository
{
    public class KancelarijaRepository : Repository<Kancelarija>, IKancelarijaRepository
    {
        protected readonly DataContext _context;

        public KancelarijaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

    }
}
