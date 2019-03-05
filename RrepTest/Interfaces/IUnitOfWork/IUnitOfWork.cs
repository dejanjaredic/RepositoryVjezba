using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;


namespace RrepTest.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork 
    {
        void Save();
        void Dispose();
        void Commit();
        void Start();

        
    }
}
