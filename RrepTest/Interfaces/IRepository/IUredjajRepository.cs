using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RrepTest.Models;
using RrepTest.MyAttributes;

namespace RrepTest.Interfaces.IRepository
{
    //[AddScoped]
    public interface IUredjajRepository : IRepository<Uredjaj, int>
    {
        int GetByName(string device);
    }
}
