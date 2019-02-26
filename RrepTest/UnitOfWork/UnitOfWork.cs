using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RrepTest.Interfaces.Ather;
using RrepTest.Interfaces.IUnitOfWork;
using RrepTest.Models;

namespace RrepTest.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private Dictionary<IDomain, IUnitOfWorkRepository> _insertedAggregates;
        private Dictionary<IDomain, IUnitOfWorkRepository> _updatedAggregates;
        private Dictionary<IDomain, IUnitOfWorkRepository> _deletedAggregates;
        public UnitOfWork(DataContext context)
        {
            _insertedAggregates = new Dictionary<IDomain, IUnitOfWorkRepository>();
            _updatedAggregates = new Dictionary<IDomain, IUnitOfWorkRepository>();
            _deletedAggregates = new Dictionary<IDomain, IUnitOfWorkRepository>();
            _context = context;
        }

        public void Commit()
        {
            foreach (IDomain domain in _insertedAggregates.Keys)
            {
                _insertedAggregates[domain].PersistInsertion(domain);
            }

            foreach (IDomain domain in _updatedAggregates.Keys)
            {
                _updatedAggregates[domain].PersistUpdate(domain);
            }

            foreach (IDomain domain in _deletedAggregates.Keys)
            {
                _deletedAggregates[domain].PersistDeletion(domain);
            }
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        //public void Complete()
        //{
        //    _context.SaveChanges();
        //}

        public void RegisterDeletion(IDomain domain, IUnitOfWorkRepository repository)
        {
            if (!_deletedAggregates.ContainsKey(domain))
            {
                _deletedAggregates.Add(domain, repository);
            }
        }

        public void RegisterInsertion(IDomain domain, IUnitOfWorkRepository repository)
        {
            if (!_insertedAggregates.ContainsKey(domain))
            {
                _insertedAggregates.Add(domain, repository);
            }
        }

        public void RegisterUpdate(IDomain domain, IUnitOfWorkRepository repository)
        {
            if (!_updatedAggregates.ContainsKey(domain))
            {
                _updatedAggregates.Add(domain, repository);
            }
        }
    }
}
