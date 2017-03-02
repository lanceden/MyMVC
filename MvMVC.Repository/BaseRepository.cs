using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvMVC.IRepository;
using System.Data.Entity;
using System.Linq.Expressions;

namespace MvMVC.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly DbContext _db = null;
        private readonly DbSet<T> _dbSet = null;

        public BaseRepository()
        {
            _db = Activator.CreateInstance(Type.GetType("MvMVC.Repository.MyDbContext")) as DbContext;
            _dbSet = _db.Set<T>();
        }
        #region 新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        public void Add(T model) => _dbSet.Add(model);
        #endregion
        #region 刪除
        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isAttach"></param>
        public void Delete(T model, bool isAttach)
        {
            if (!isAttach) _dbSet.Attach(model);
            _dbSet.Remove(model);
        }

        public void DeleteRange(Expression<Func<T, bool>> predicate)
        {
            _dbSet.RemoveRange(_dbSet.Where(predicate).ToList());
        }
        #endregion
        #region 修改
        // <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="proNames"></param>
        public void Edit(T model, params string[] proNames)
        {
            var entry = _db.Entry(model);
            entry.State = EntityState.Unchanged;
            foreach (var proName in proNames)
            {
                entry.Property(proName).IsModified = true;
            }
            _db.Configuration.ValidateOnSaveEnabled = false;
        }
        #endregion
        #region 查詢
        /// <summary>
        /// 查詢
        /// </summary>
        public List<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }
        /// <summary>
        /// 執行SQL語法
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<TResult> RunSql<TResult>(string sqlStr, params object[] parameters)
        {
            return _db.Database.SqlQuery<TResult>(sqlStr, parameters).ToList();
        }
        #endregion

        public int SaveChanges() => _db.SaveChanges();
    }
}
