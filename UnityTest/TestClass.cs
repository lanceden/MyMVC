using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvMVC.Repository;
using MyMVC.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace UnityTest
{
    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public void AddTest()
        {
            var db = new BaseRepository<Person>();
            db.Add(new Person() { Name = "TestClass", Age = "321" });
            var res = db.SaveChanges();
            Assert.AreEqual(res, 1);
        }
        [TestMethod]
        public void SelectTest()
        {
            var db = new BaseRepository<Person>();
            var list = db.Get(s => true);
            Assert.AreEqual(list.Count, 112);
        }
        [TestMethod]
        public void RunSQLTest()
        {
            var db = new BaseRepository<Person>();
            var person = db.RunSql<Person>(@"SELECT * FROM [SKL].[dbo].[Person] a 
        where Id = @Id
        order by a.Id desc",
        new SqlParameter("@Id", System.Data.SqlDbType.Int) { Value = 113 }).FirstOrDefault();
            Assert.AreEqual(person.Name, "TestClass1");
        }
        [TestMethod]
        public void DeleteRangeTest()
        {
            var db = new BaseRepository<Person>();
            var ids = new[] {111,112,113 };
            db.DeleteRange(s => ids.Contains(s.Id));
            var res = db.SaveChanges();
            Assert.AreEqual(res, 3);
        }
    }
}
