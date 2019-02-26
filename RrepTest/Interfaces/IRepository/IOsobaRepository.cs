using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RrepTest.Models;

namespace RrepTest.Interfaces.IRepository
{
    public interface IOsobaRepository : IRepository<Osoba>
    {
        //void AddData(Osoba input);
        void Edit(int id, Osoba input);
        int GetByNameSurname(string name, string surname);
        void AddPerson(Osoba input);

    }
}
