using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RrepTest.Interfaces.Ather;

namespace RrepTest.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork
    {
        void RegisterUpdate(IDomain domain, IUnitOfWorkRepository repository);
        void RegisterInsertion(IDomain domain, IUnitOfWorkRepository repository);
        void RegisterDeletion(IDomain domain, IUnitOfWorkRepository repository);
        void Commit();
        void Complete();
    }
}
