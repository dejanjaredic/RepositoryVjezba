using RrepTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RrepTest.Interfaces.IRepository
{
    public interface IKancelarijaRepository
    {
        Kancelarija GetById(int id);
        void Create(Kancelarija input);
        void Save();
        IEnumerable<Kancelarija> GetAll();
        void Delete(int id);
        void EditData(int id, Kancelarija input);
    }
}
