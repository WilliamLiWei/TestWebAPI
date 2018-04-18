using System;
using Domains.Model;

namespace Domains
{
    public class TestTableDomain
    {
        //负责整理TestTable的业务整理
        
        public TestTableDomain()
        {
        }

        public TestTableEntity AddNewTestTable(string addr, string name, int sex)
        {
            TestTableEntity testTableEntity = new TestTableEntity()
            {
                Id = Guid.NewGuid(),
                Address = addr,
                Name = name,
                Sex = sex
            };
            return testTableEntity;
        }
    }
}
