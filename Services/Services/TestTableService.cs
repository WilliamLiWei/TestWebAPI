using Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using Domains.Model;

namespace Services.Services
{
    public class TestTableService : ITestTableService
    {
        private TestTableDomain _testTableDomain;
        private liweitestContext _liweitestContext;
        public TestTableService(TestTableDomain testTableDomain, liweitestContext liweitestContext)
        {
            _testTableDomain = testTableDomain;
            _liweitestContext = liweitestContext;
        }
        public int RecordAdd(string addr,string name,int sex)
        {
            TestTableEntity testTableEntity = _testTableDomain.AddNewTestTable(addr, name, sex);
            _liweitestContext.TestTable.Add(testTableEntity);
            _liweitestContext.SaveChanges();
            return 1;
        }

        public int RecordDel()
        {
            return 1;
        }

        public int RecordRead()
        {
            return 1;
        }

        public int RecordUpdate()
        {
            return 1;
        }
    }
}
