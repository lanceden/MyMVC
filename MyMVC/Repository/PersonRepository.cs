using Respotiroy;
using System.Collections.Generic;
using System.Linq;

namespace MyMVC
{
    public class PersonRepository:RepositoryADO
    {
        #region 獲取Person資料
        /// <summary>
        /// 獲取Person資料
        /// </summary>
        /// <returns></returns>
        public IList<Person> Get()
        {
            return base.GetDataTable("select * from Person order by Id desc")
                .ToList<Person>();
        } 
        #endregion
    }
}