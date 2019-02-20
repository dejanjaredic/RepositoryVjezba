using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RrepTest.Models;

namespace RrepTest.Interfaces.IRepository
{
    public interface IUredjajRepository
    {
        Uredjaj AddData(Uredjaj input);
        List<Uredjaj> GetData();
        Uredjaj GetById(int id);
        void EditData(int id, Uredjaj input);
        void Save();
        void Delete(int id);
    }
}
