using DBTest.Models;
using System;
using System.Linq;

namespace DBTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //liweitestContext dc = new liweitestContext();
            //TestTable tt = new TestTable()
            //{
            //    Id = Guid.NewGuid(),
            //    Name="liwei",
            //    Address = "beijing"
            //};
            //dc.TestTable.Add(tt);

            //tt = new TestTable()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "liwei2",
            //    Address = "beijing2"
            //};
            //dc.TestTable.Add(tt);

            //dc.SaveChanges();

            //var liweiList = dc.TestTable.ToList();
            //liweiList.ForEach(x => Console.WriteLine(x.Id + "  " + x.Name + "  " + x.Address));

            //var dd = liweiList.Find(x => x.Name == "liwei");
            
            //Console.WriteLine("OK");
            //Console.ReadKey();
        }
    }
}
