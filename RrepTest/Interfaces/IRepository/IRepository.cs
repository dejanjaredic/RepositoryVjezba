using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RrepTest.Interfaces.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T input);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Delete(int id);
        void Save();
        void Edit(int id, T input);
    }
}
