using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MvMVC.IRepository
{
    public interface IBaseRepository<T> where T:class,new()
    {
        void Add(T model);
        void Edit(T model,params string[] proNames);
        void Delete(T model,bool isAttach);
        void DeleteRange(Expression<Func<T, bool>> predicate);
        List<T> Get(Expression<Func<T, bool>> predicate);
        List<TResult> RunSql<TResult>(string sqlStr, params object[] parameters);
        int SaveChanges();
    }
}
