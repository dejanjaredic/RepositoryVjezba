using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RrepTest.Interfaces.Ather;

namespace RrepTest.Interfaces.IUnitOfWork
{
    public interface IUnitOfWorkRepository
    {
        void PersistInsertion(IDomain domain);
        void PersistUpdate(IDomain domain);
        void PersistDeletion(IDomain domain);
    }
}
