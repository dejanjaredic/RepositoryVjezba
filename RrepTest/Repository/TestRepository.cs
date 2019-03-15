using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RrepTest.Models;
using RrepTest.MyAttributes;

namespace RrepTest.Interfaces.IRepository
{
    [UniversalDI]
    public class TestRepository : IRepository<Uredjaj, int>
    {
        public void Add(Uredjaj input)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Uredjaj> GetAll()
        {
            throw new NotImplementedException();
        }

        public Uredjaj GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id, Uredjaj input)
        {
            throw new NotImplementedException();
        }
    }
}
