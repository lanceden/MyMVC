using System.Data.Entity;

namespace MvMVC.Repository
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() :
            base("name=SKLEntities")
        {

        }
    }
}
