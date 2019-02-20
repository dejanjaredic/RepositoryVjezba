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
    public class UredjajRepository : IUredjajRepository
    {
        protected readonly DataContext _context;

        public UredjajRepository(DataContext context)
        {
            _context = context;
        }

        public Uredjaj AddData(Uredjaj input)
        {
            _context.Uredjaji.Add(input);
            _context.SaveChanges();
            return input;

        }

        public List<Uredjaj> GetData()
        {
            IEnumerable<Uredjaj> uredjaj = _context.Uredjaji;
            var uredjajiQuery =
                uredjaj.Select(x => x);

            return uredjajiQuery.ToList();
        }

        public Uredjaj GetById(int id)
        {
            return _context.Uredjaji.Find(id);
        }

        public void EditData(int id, Uredjaj input)
        {
            var uredjaj = _context.Uredjaji.Find(id);
            uredjaj.Name = input.Name;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var uredjaj = _context.Uredjaji.Find(id);
            _context.Uredjaji.Remove(uredjaj);
        }

        
    }
}
