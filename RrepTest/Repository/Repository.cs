﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RrepTest.Interfaces.IRepository;
using RrepTest.Models;

namespace RrepTest.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        

        public void Add(T input)
        {
            _context.Set<T>().Add(input);
        }

        public void Delete(int id)
        {
            var data = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(data);
        }

        public void Edit(int id, T input)
        {
            // var data = _context.Set<T>().Find(id);
            var entry = _context.Set<T>().Attach(input);
            entry.State = EntityState.Modified;
           
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            var data = _context.Set<T>().Find(id);
            return data;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}