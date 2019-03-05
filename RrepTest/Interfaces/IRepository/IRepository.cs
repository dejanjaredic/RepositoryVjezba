using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RrepTest.Interfaces.IRepository
{
    public interface IRepository<T, Ttype> where T : class
    {
        void Add(T input);
        IEnumerable<T> GetAll();
        T GetById(Ttype id);
        void Delete(Ttype id);
        
        void Edit(Ttype id, T input);
        
    }
}
