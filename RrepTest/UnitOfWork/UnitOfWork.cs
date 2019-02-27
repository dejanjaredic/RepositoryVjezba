using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

using RrepTest.Interfaces.IUnitOfWork;
using RrepTest.Models;

namespace RrepTest.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;
        private TransactionScope _transaction;
        public UnitOfWork(DataContext context  )
        {
            
            _context = context;
        }

        public void Start() 
            => this._transaction = new TransactionScope();
        public void Commit() 
            => this._transaction.Complete();
        public void Save() 
            => _context.SaveChanges();
        public void Dispose() 
            => _transaction?.Dispose();




    }
}
