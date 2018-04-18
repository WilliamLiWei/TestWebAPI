using Domains.IRespositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.UnitOfWork
{
    public interface IEFUnitOfWork : IUnitOfWorkRepositoryContext
    {
        DbContext context { get; }
    }
}
