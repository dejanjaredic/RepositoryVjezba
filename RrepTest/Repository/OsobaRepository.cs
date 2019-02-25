using RrepTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RrepTest.Interfaces.IRepository;

namespace RrepTest.Repository
{
    public class OsobaRepository : Repository<Osoba>, IOsobaRepository
    {
        protected readonly DataContext _context;


        public OsobaRepository(DataContext context) : base(context)
        {
            _context = context;
        }


        public void AddData(Osoba input)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var osoba = new Osoba
                    {
                        Ime = input.Ime,
                        Prezime = input.Prezime,
                    };
                    var sveKancelarije = _context.Kancelarije;
                    var sveKancelarijeQuery = sveKancelarije.Select(x => x.Opis);
                    if (sveKancelarijeQuery.Contains(input.Kancelarija.Opis))
                    {
                        var getKancelarijaId = _context.Kancelarije;
                        var getKancelarijaQuery =
                            getKancelarijaId.Where(x => x.Opis.Contains(input.Kancelarija.Opis)).Select(y => y.Id).FirstOrDefault();
                        if (getKancelarijaQuery != null)
                        {
                            osoba.KancelarijaId = getKancelarijaQuery;
                        }
                    }
                    else
                    {
                        osoba.Kancelarija = new Kancelarija
                        {
                            Opis = input.Kancelarija.Opis
                        };
                    }

                    _context.Osobe.Add(osoba);
                    _context.SaveChanges();

                    transaction.Commit();

                }
                catch (Exception e)
                {

                }
            }
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
                catch (Exception e)
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


            return osobaQuery.FirstOrDefault();
        }

    }
}
