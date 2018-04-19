using Domains.IRespositories;
using Domains.Model;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class TestTableRepository : EFBaseRepository<TestTableEntity>, ITestTableRepository
    {
        public TestTableRepository(IEFUnitOfWork eFUnitOfWork) : base(eFUnitOfWork)
        {
        }
    }
}
