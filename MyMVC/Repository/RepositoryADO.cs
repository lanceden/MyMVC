namespace MyMVC
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class RepositoryADO
    {
        //SQL 連線字串
        private const string connStr = "server=.;database=SKl;uid=lance;pwd=123456";
        #region 執行新增 修改 刪除 SQL
        /// <summary>
        /// 執行新增 修改 刪除 SQL
        /// </summary>
        /// <returns></returns>
        public int ExecuteNonQuery(string sqlStr, params SqlParameter[] parameters)
        {
            using (var dbConn = new SqlConnection(connStr))
            {
                dbConn.Open();
                using (var cmd = dbConn.CreateCommand())
                {
                    cmd.CommandText = sqlStr;
                    cmd.Parameters.AddRange(parameters);
                    var res = cmd.ExecuteNonQuery();
                    Console.WriteLine(res);
                }
            }
            return -1;
        }
        #endregion
        #region 執行查詢SQL
        /// <summary>
        /// 執行查詢SQL
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable(string sqlStr)
        {
            var connStr = "server=.;database=SKL;uid=lance;pwd=123456";
            using (var dbConn = new SqlConnection(connStr))
            {
                dbConn.Open();
                using (var cmd = dbConn.CreateCommand())
                {

                    cmd.CommandText = sqlStr;
                    var dt = new DataTable();
                    var adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        #endregion
    }
}