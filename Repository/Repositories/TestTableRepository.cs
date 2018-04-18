using Domains.IRespositories;
using Domains.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    class TestTableRepository : EFBaseRepository<TestTableEntity>, ITestTableRepository
    {

    }
}
