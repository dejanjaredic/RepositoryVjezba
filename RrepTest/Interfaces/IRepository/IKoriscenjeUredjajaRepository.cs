using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RrepTest.Models;

namespace RrepTest.Interfaces.IRepository
{
    public interface IKoriscenjeUredjajaRepository : IRepository<KoriscenjeUredjaja>
    {
        //IEnumerable<KoriscenjeUredjaja> GetAllData();
        //KoriscenjeUredjaja GetById(int id);
        //void Delete(int id);
        //void AddData();
        void AddData(int osoba, int device);
    }
}
