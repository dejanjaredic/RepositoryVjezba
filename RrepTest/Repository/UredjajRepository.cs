using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
