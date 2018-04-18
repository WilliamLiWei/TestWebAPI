using System;
using System.Collections.Generic;

namespace DBTest.Models
{
    public partial class TestTable2
    {
        public long Id { get; set; }
        public Guid? TestTableId { get; set; }
        public string Memo { get; set; }
        public string Memo2 { get; set; }
    }
}
