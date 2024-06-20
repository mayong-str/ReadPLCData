using HslCommunication.LogNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadPLCData
{
    public class OperateDataBase
    {
        static string sqlServerConfig = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString; //数据库字符连接串
        /// <summary>
        /// 执行查询，返回第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteScalar(string sql)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(sqlServerConfig);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                int value = Convert.ToInt32(sqlCommand.ExecuteScalar());
                return value;
            }
            catch (Exception ex)
            {
                GlobalLog.WriteInfoLog("ExecuteScalar：" + sql);
                GlobalLog.WriteErrorLog("ExecuteScalar：" + ex.Message);
                return -1;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// 执行查询，返回受影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(sqlServerConfig);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                int rows = sqlCommand.ExecuteNonQuery();
                return rows;
            }
            catch (Exception ex)
            {
                GlobalLog.WriteInfoLog("ExecuteNonQuery：" + sql);
                GlobalLog.WriteErrorLog("ExecuteNonQuery：" + ex.Message);
                return -1;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
