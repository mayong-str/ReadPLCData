using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadPLCData
{
    public class DataBaseHandle
    {
        /// <summary>
        /// 插入操作
        /// </summary>
        /// <param name="work_duration"></param>
        /// <param name="hold_duration"></param>
        /// <param name="transport_duration"></param>
        /// <param name="thd_product_id"></param>
        /// <param name="device_id"></param>
        /// <param name="number"></param>
        public static void Insert(Int16[] work_duration, Int16[] hold_duration, Int16[] transport_duration, Int16[] thd_product_id, Int16[] device_id, int number, int thd_product_kind)
        {
            for (int i = 0; i < work_duration.Length; i++)
            {
                string sql = string.Empty;
                number++;
                if (thd_product_id[i] != 0 && device_id[i] != 0 && thd_product_kind != 0)
                {
                    sql = string.Format("insert into  log_per_station (id,station_id,work_duration,hold_duration,transport_duration,thd_product_id,device_id,create_time,update_time,is_delete,thd_product_kind) " +
                    "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", number, (i + 1), work_duration[i], hold_duration[i], transport_duration[i], thd_product_id[i], device_id[i], DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 0, thd_product_kind);
                }

                else if (thd_product_id[i] != 0 && device_id[i] == 0 && thd_product_kind != 0)
                {
                    sql = string.Format("insert into  log_per_station (id,station_id,work_duration,hold_duration,transport_duration,thd_product_id,create_time,update_time,is_delete,thd_product_kind) " +
                    "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", number, (i + 1), work_duration[i], hold_duration[i], transport_duration[i], thd_product_id[i], DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 0, thd_product_kind);
                }
                else if (thd_product_id[i] != 0 && device_id[i] != 0 && thd_product_kind == 0)
                {
                    sql = string.Format("insert into  log_per_station (id,station_id,work_duration,hold_duration,transport_duration,thd_product_id,device_id,create_time,update_time,is_delete) " +
                    "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", number, (i + 1), work_duration[i], hold_duration[i], transport_duration[i], thd_product_id[i], device_id[i], DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 0);
                }
                else if (thd_product_id[i] == 0 && device_id[i] != 0 && thd_product_kind != 0)
                {
                    sql = string.Format("insert into  log_per_station (id,station_id,work_duration,hold_duration,transport_duration,device_id,create_time,update_time,is_delete,thd_product_kind) " +
                    "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", number, (i + 1), work_duration[i], hold_duration[i], transport_duration[i], device_id[i], DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 0, thd_product_kind);
                }
                else if (thd_product_id[i] == 0 && device_id[i] != 0 && thd_product_kind == 0)
                {
                    sql = string.Format("insert into  log_per_station (id,station_id,work_duration,hold_duration,transport_duration,device_id,create_time,update_time,is_delete) " +
                    "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", number, (i + 1), work_duration[i], hold_duration[i], transport_duration[i], device_id[i], DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 0);
                }
                else if (thd_product_id[i] == 0 && device_id[i] == 0 && thd_product_kind != 0)
                {
                    sql = string.Format("insert into  log_per_station (id,station_id,work_duration,hold_duration,transport_duration,create_time,update_time,is_delete,thd_product_kind) " +
                   "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", number, (i + 1), work_duration[i], hold_duration[i], transport_duration[i], DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 0, thd_product_kind);
                }
                else if (thd_product_id[i] != 0 && device_id[i] == 0 && thd_product_kind == 0)
                {
                    sql = string.Format("insert into  log_per_station (id,station_id,work_duration,hold_duration,transport_duration,thd_product_id,create_time,update_time,is_delete) " +
                    "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", number, (i + 1), work_duration[i], hold_duration[i], transport_duration[i], thd_product_id[i], DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 0);
                }
                else
                {
                    sql = string.Format("insert into  log_per_station (id,station_id,work_duration,hold_duration,transport_duration,create_time,update_time,is_delete) " +
                   "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", number, (i + 1), work_duration[i], hold_duration[i], transport_duration[i], DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 0);
                }

                OperateDataBase.ExecuteNonQuery(sql);
            }
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="scheduled_amount"></param>
        public static void Update(short scheduled_amount)
        {
            string sql = "update production_task set scheduled_amount =" + scheduled_amount + ", update_time= '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "' where status = 1";

            OperateDataBase.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 查询操作
        /// </summary>
        /// <returns></returns>
        public static int Select()
        {
            string sql = "SELECT TOP 1 id FROM log_per_station ORDER BY id DESC";
            return OperateDataBase.ExecuteScalar(sql);
        }


        public static void Insert_L(Int16[] work_duration, Int16[] hold_duration, Int16[] transport_duration, Int16[] thd_product_id, Int16[] device_id, int thd_product_kind)
        {
            string type = string.Empty; //类型
            string sql = string.Empty;
            Int16[] status_duration = new Int16[1];
            for (int i = 0; i < work_duration.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                    {
                        type = "作业时间";
                        status_duration[0] = work_duration[i];
                    }
                    else if(j == 1)
                    {
                        type = "等待时间";
                        status_duration[0] = hold_duration[i];
                    }
                    else if(j == 2)
                    {
                        type = "移动时间";
                        status_duration[0] = transport_duration[i];
                    }
                    else
                    {
                        //j = 0;
                    }
                    if (thd_product_id[i] != 0 && device_id[i] != 0 && thd_product_kind != 0)
                    {
                        sql = string.Format("insert into  log_periodic_station (station_id,status,status_duration,thd_product_id,thd_product_type,device_id,create_time) " +
                        "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", (i + 1), type, status_duration[0], thd_product_id[i], thd_product_kind, device_id[i], DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    }
                    else if (thd_product_id[i] != 0 && device_id[i] == 0 && thd_product_kind != 0)
                    {
                        sql = string.Format("insert into  log_periodic_station (station_id,status,status_duration,thd_product_id,thd_product_type,create_time) " +
                        "values('{0}','{1}','{2}','{3}','{4}','{5}')", (i + 1), type, status_duration[0], thd_product_id[i], thd_product_kind, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    }
                    else if (thd_product_id[i] != 0 && device_id[i] != 0 && thd_product_kind == 0)
                    {
                        sql = string.Format("insert into  log_periodic_station (station_id,status,status_duration,thd_product_id,device_id,create_time) " +
                        "values('{0}','{1}','{2}','{3}','{4}','{5}')", (i + 1), type, status_duration[0], thd_product_id[i], device_id[i], DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    }
                    else if (thd_product_id[i] == 0 && device_id[i] != 0 && thd_product_kind != 0)
                    {
                        sql = string.Format("insert into  log_periodic_station (station_id,status,status_duration,thd_product_type,device_id,create_time) " +
                        "values('{0}','{1}','{2}','{3}','{4}','{5}')", (i + 1), type, status_duration[0], thd_product_kind, device_id[i], DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    }
                    else if (thd_product_id[i] == 0 && device_id[i] != 0 && thd_product_kind == 0)
                    {
                        sql = string.Format("insert into  log_periodic_station (station_id,status,status_duration,device_id,create_time) " +
                        "values('{0}','{1}','{2}','{3}','{4}')", (i + 1), type, status_duration[0], device_id[i], DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    }
                    else if (thd_product_id[i] == 0 && device_id[i] == 0 && thd_product_kind != 0)
                    {
                        sql = string.Format("insert into  log_periodic_station (station_id,status,status_duration,thd_product_type,create_time) " +
                         "values('{0}','{1}','{2}','{3}','{4}')", (i + 1), type, status_duration[0], thd_product_kind, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    }
                    else if (thd_product_id[i] != 0 && device_id[i] == 0 && thd_product_kind == 0)
                    {
                        sql = string.Format("insert into  log_periodic_station (station_id,status,status_duration,thd_product_id,create_time) " +
                        "values('{0}','{1}','{2}','{3}','{4}')", (i + 1), type, status_duration[0], thd_product_id[i], DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    }
                    else
                    {
                        sql = string.Format("insert into  log_periodic_station (station_id,status,status_duration,create_time) " +
                        "values('{0}','{1}','{2}','{3}')", (i + 1), type, status_duration[0],DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    }

                    OperateDataBase.ExecuteNonQuery(sql);
                }
            }
        }

        internal static void Insert_S(short[] work_duration, short[] hold_duration, short[] transport_duration)
        {
            string type = string.Empty; //类型
            string sql = string.Empty;
            Int16[] status_duration = new Int16[1];
            for (int i = 0; i < work_duration.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                    {
                        type = "作业时间";
                        status_duration[0] = work_duration[i];
                    }
                    else if (j == 1)
                    {
                        type = "等待时间";
                        status_duration[0] = hold_duration[i];
                    }
                    else if (j == 2)
                    {
                        type = "移动时间";
                        status_duration[0] = transport_duration[i];
                    }
                    else
                    {
                        //j = 0;
                    }
                    //sql = string.Format("insert into  log_rt_station_status (station_id,station_status,status_duration,create_time) " +
                    //    "values('{0}','{1}','{2}','{3}')", (i + 1), type, status_duration[0], DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    sql = "update log_rt_station_status set status_duration = '" + status_duration[0] + "', update_time = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "' where station_id = '" + (i + 1) + "' and station_status = '" + type + "'";

                    OperateDataBase.ExecuteNonQuery(sql);
                }
            }
        }
    }
}
