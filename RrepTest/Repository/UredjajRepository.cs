using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RrepTest.Interfaces.IRepository;
using RrepTest.Models;

namespace RrepTest.Repository
{
    public class UredjajRepository : Repository<Uredjaj>, IUredjajRepository
    {
        protected readonly DataContext _context;


        public UredjajRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public int GetByName(string device)
        {
            var uredjaj = _context.Uredjaji;
            var uredjajQuery =
                uredjaj.Where(x => x.Name.Equals(device)).Select(y => y.Id).FirstOrDefault();
            
            return uredjajQuery;
        }
    }
}
