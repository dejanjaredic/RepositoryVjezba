using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RadnoMjestoVjezba.Middleware;
using RrepTest.Interfaces.IRepository;
using RrepTest.Models;
using RrepTest.MyAttributes;
using RrepTest.MyExceptions;

namespace RrepTest.Repository
{
    [UniversalDI]
    public class Repository<T, Ttype> : IRepository<T, Ttype> where T : class
    {
        protected DataContext Context { get; }


        public Repository(DataContext context)
        {
            Context = context;
        }
        

        public void Add(T input)
        {
            if (input == null)
            {
                throw (new ExceptionFilterTest("Greska pri unosu"));
            }
                Context.Set<T>().Add(input);
        }

        public void Delete(Ttype id)
        {
            
            var data = Context.Set<T>().Find(id);
            if (data == null)
            {
                throw (new ExceptionFilterTest("Nepostojeci entitet"));
            }
            Context.Set<T>().Remove(data);
        }

        public void Edit(Ttype id, T input)
        {
            // var data = _context.Set<T>().Find(id);
            var entry = Context.Set<T>().Attach(input);
            if (id == null)
            {
                throw (new ExceptionFilterTest("Nepostojeci entitet"));
            }
            entry.State = EntityState.Modified;
           
        }

        public IEnumerable<T> GetAll()
        {

            var data = Context.Set<T>().ToList();
            if (data == null)
            {
                throw (new ExceptionFilterTest("Nepostojeci Entitet"));

            }
            return data;
        }

        public T GetById(Ttype id)
        {
            var data = Context.Set<T>().Find(id);
            if (data == null)
            {
                throw (new ExceptionFilterTest("Nepostojeci entitet"));

            }
            return data;
        }
    }
}
