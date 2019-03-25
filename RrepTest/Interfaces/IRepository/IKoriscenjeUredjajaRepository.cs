using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RrepTest.Models;

namespace RrepTest.Interfaces.IRepository
{
    public interface IKoriscenjeUredjajaRepository : IRepository<KoriscenjeUredjaja, int>
    {
        //IEnumerable<KoriscenjeUredjaja> GetAllData();
        //KoriscenjeUredjaja GetById(int id);
        //void Delete(int id);
        //void AddData();
        void AddData(int osoba, int device);
        IQueryable Aloha([FromBody] QueryInfo input);
    }
}
