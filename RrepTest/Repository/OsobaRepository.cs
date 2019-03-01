using RrepTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RrepTest.Interfaces.IRepository;
using RrepTest.MyExceptions;

namespace RrepTest.Repository
{
    public class OsobaRepository : Repository<Osoba>, IOsobaRepository
    {
        protected readonly DataContext _context;


        public OsobaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public void Edit(int id, Osoba input)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var osobe = _context.Osobe.Find(id);
                    osobe.Ime = input.Ime;
                    osobe.Prezime = input.Prezime;
                    _context.SaveChanges();
                    transaction.Commit();
                   
                }
                catch (ExceptionFilterTest e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public int GetByNameSurname(string name, string surname)
        {
            var osoba = _context.Osobe;
            var osobaQuery =
                osoba.Where(x => x.Ime.Equals(name) && x.Prezime.Equals(surname)).Select(i => i.Id);

            if (osobaQuery.Count() == 0)
            {
                throw (new ExceptionFilterTest($"Nepostojeca Osoba: {name + " " + surname} "));
            }
            return osobaQuery.FirstOrDefault();
        }

        public void AddPerson(Osoba input)
        {  
           _context.Osobe.Add(input);
        }

    }
}
