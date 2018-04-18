using Domains.BaseModel;
using System;
using System.Collections.Generic;

namespace Domains.Model
{
    public partial class TestTable2 : IEntity
    {
        public long Id { get; set; }
        public Guid? TestTableId { get; set; }
        public string Memo { get; set; }
        public string Memo2 { get; set; }
    }
}
