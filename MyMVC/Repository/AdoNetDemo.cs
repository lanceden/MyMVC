using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyMVC
{
    public static class AdoNetDemo
    {
        #region Ado.Net
        #region 直接新增資料
        /// <summary>
        /// 直接新增資料
        /// </summary>
        static void Add()
        {
            var connStr = "server=.;database=SKL;uid=lance;pwd=123456";
            //step 1.新增SQL的連線方式
            using (var dbConn = new SqlConnection(connStr))
            {
                //step 2.開啟連線
                dbConn.Open();
                using (var cmd = dbConn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [dbo].[Person] values (102,'Apple2',18)";
                    int result = cmd.ExecuteNonQuery();
                    Console.WriteLine(result);
                }
            }
        }
        #endregion

        #region 帶參數新增資料
        /// <summary>
        /// 帶參數新增資料
        /// </summary>
        static void AddWithParameter(Person pModel)
        {
            var connStr = "server=.;database=SKL;uid=lance;pwd=123456";
            //step 1.新增SQL的連線方式
            using (var dbConn = new SqlConnection(connStr))
            {
                //step 2.開啟連線
                dbConn.Open();
                using (var cmd = dbConn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [dbo].[Person] values (@Name,@Age)";
                    //cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar) { Value = pModel.Name });
                    //cmd.Parameters.Add(new SqlParameter("@Age", SqlDbType.NVarChar) { Value = pModel.Age });
                    cmd.Parameters.AddRange(new SqlParameter[]
                    {
                        new SqlParameter("@Name",SqlDbType.NVarChar) { Value = pModel.Name },
                        new SqlParameter("@Age",SqlDbType.NVarChar) { Value = pModel.Age }
                    });
                    var result = cmd.ExecuteNonQuery();
                    Console.WriteLine(result);
                }
            }
        }
        #endregion

        #region 直接更新資料
        /// <summary>
        /// 直接更新資料
        /// </summary>
        static void Update()
        {
            var connStr = "server=.;database=SKl;uid=lance;pwd=123456";
            using (var dbConn = new SqlConnection(connStr))
            {
                dbConn.Open();
                using (var cmd = dbConn.CreateCommand())
                {
                    cmd.CommandText = "update person set Name='Parameter123',Age=321 where Id = 103";
                    var res = cmd.ExecuteNonQuery();
                    Console.WriteLine(res);
                }
            }
        }
        #endregion

        #region 帶參數更新資料
        /// <summary>
        /// 帶參數更新資料
        /// </summary>
        static void UpdateWithParameter(Person pModel)
        {
            var connStr = "server=.;database=SKl;uid=lance;pwd=123456";
            using (var dbConn = new SqlConnection(connStr))
            {
                dbConn.Open();
                using (var cmd = dbConn.CreateCommand())
                {
                    cmd.CommandText = "update person set Name=@Name,Age=@Age where Id = @Id";
                    cmd.Parameters.AddRange(new SqlParameter[]
                    {
                        new SqlParameter("@Name",SqlDbType.NVarChar) { Value = pModel.Name},
                        new SqlParameter("@Age",SqlDbType.NVarChar) { Value = pModel.Age},
                        new SqlParameter("@Id",SqlDbType.Int) { Value = pModel.Id},
                    });
                    var res = cmd.ExecuteNonQuery();
                    Console.WriteLine(res);
                }
            }
        }
        #endregion

        #region 查詢資料
        /// <summary>
        /// 查詢資料
        /// </summary>
        static void Select()
        {
            var list = new List<Person>();
            var connStr = "server=.;database=SKL;uid=lance;pwd=123456";
            using (var dbConn = new SqlConnection(connStr))
            {
                dbConn.Open();
                using (var cmd = dbConn.CreateCommand())
                {
                    cmd.CommandText = "select * from Person order by Id desc";
                    var dt = new DataTable();
                    var adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    var count = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        list.Add(new Person()
                        {
                            Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                            Name = dt.Rows[i]["Name"].ToString(),
                            Age = dt.Rows[i]["Age"].ToString()
                        });
                    }
                }
            }
        }
        #endregion 
        #endregion
    }
}