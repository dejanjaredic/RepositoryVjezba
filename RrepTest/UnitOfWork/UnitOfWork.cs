using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore.Storage;
using RrepTest.Interfaces.IUnitOfWork;
using RrepTest.Models;
using RrepTest.MyAttributes;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace RrepTest.UnitOfWork
{
    [UniversalDI]
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;
        private IDbContextTransaction _transaction;

       

        public UnitOfWork(DataContext context)
        {
            
            _context = context;
        }

        public void Start() 
            => _transaction = _context.Database.BeginTransaction();
        public void Commit() 
            => this._transaction.Commit();
        public void Save() 
            => _context.SaveChanges();
        public void Dispose() 
            => _transaction?.Dispose();





    }
}
