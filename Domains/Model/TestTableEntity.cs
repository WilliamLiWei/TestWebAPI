using Domains.BaseModel;
using System;
using System.Collections.Generic;

namespace Domains.Model
{
    public partial class TestTableEntity : AggregateRoot
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Sex { get; set; }
    }
}
