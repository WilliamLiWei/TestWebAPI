using System;
using System.Collections.Generic;

namespace DBTest.Models
{
    public partial class TestTableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Sex { get; set; }
    }
}
