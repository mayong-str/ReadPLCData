using HslCommunication.Reflection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadPLCData
{
    public class DataExample
    {
        /// <summary>
        /// 工位1的作业持续时间
        /// </summary>
        [HslDeviceAddress("D150")] 
        public int work_duration_1 { get; set; }
        
        /// <summary>
        /// 工位2的作业持续时间
        /// </summary>
        [HslDeviceAddress("D170")] 
        public int work_duration_2 { get; set; }

        /// <summary>
        /// 工位3的作业持续时间
        /// </summary>
        [HslDeviceAddress("D190")]
        public int work_duration_3 { get; set; }

        /// <summary>
        /// 工位4的作业持续时间
        /// </summary>
        [HslDeviceAddress("D210")]
        public int work_duration_4 { get; set; }

        /// <summary>
        /// 工位5的作业持续时间
        /// </summary>
        [HslDeviceAddress("D230")]
        public int work_duration_5 { get; set; }

        /// <summary>
        /// 工位6的作业持续时间
        /// </summary>
        [HslDeviceAddress("D250")]
        public int work_duration_6 { get; set; }

        /// <summary>
        /// 工位7的作业持续时间
        /// </summary>
        [HslDeviceAddress("D270")]
        public int work_duration_7 { get; set; }

        /// <summary>
        /// 工位8的作业持续时间
        /// </summary>
        [HslDeviceAddress("D290")]
        public int work_duration_8 { get; set; }

        /// <summary>
        /// 工位9的作业持续时间
        /// </summary>
        [HslDeviceAddress("D310")]
        public int work_duration_9 { get; set; }

        /// <summary>
        /// 工位10的作业持续时间
        /// </summary>
        [HslDeviceAddress("D330")]
        public int work_duration_10 { get; set; }

        /// <summary>
        /// 工位11的作业持续时间
        /// </summary>
        [HslDeviceAddress("D350")]
        public int work_duration_11 { get; set; }

        /// <summary>
        /// 工位12的作业持续时间
        /// </summary>
        [HslDeviceAddress("D370")]
        public int work_duration_12 { get; set; }

        /// <summary>
        /// 工位13的作业持续时间
        /// </summary>
        [HslDeviceAddress("D390")]
        public int work_duration_13 { get; set; }

        /// <summary>
        /// 工位14的作业持续时间
        /// </summary>
        [HslDeviceAddress("D410")]
        public int work_duration_14 { get; set; }

        /// <summary>
        /// 工位15的作业持续时间
        /// </summary>
        [HslDeviceAddress("D430")]
        public int work_duration_15 { get; set; }

        /// <summary>
        /// 工位16的作业持续时间
        /// </summary>
        [HslDeviceAddress("D450")]
        public int work_duration_16 { get; set; }

        /// <summary>
        /// 工位17的作业持续时间
        /// </summary>
        [HslDeviceAddress("D470")]
        public int work_duration_17 { get; set; }

        /// <summary>
        /// 工位18的作业持续时间
        /// </summary>
        [HslDeviceAddress("D490")]
        public int work_duration_18 { get; set; }

        /// <summary>
        /// 工位19的作业持续时间
        /// </summary>
        [HslDeviceAddress("D510")]
        public int work_duration_19 { get; set; }

        /// <summary>
        /// 工位20的作业持续时间
        /// </summary>
        [HslDeviceAddress("D530")]
        public int work_duration_20 { get; set; }

        #region //注释
        ///// <summary>
        ///// 工位1的工位等待时间
        ///// </summary>
        //[HslDeviceAddress("D4040")]
        //public int hold_duration_1 { get; set; }

        ///// <summary>
        ///// 工位2的工位等待时间
        ///// </summary>
        //[HslDeviceAddress("D4041")]
        //public int hold_duration_2 { get; set; }

        ///// <summary>
        ///// 工位3的工位等待时间
        ///// </summary>
        //[HslDeviceAddress("D4042")]
        //public int hold_duration_3 { get; set; }

        ///// <summary>
        ///// 工位4的工位等待时间
        ///// </summary>
        //[HslDeviceAddress("D4043")]
        //public int hold_duration_4 { get; set; }

        ///// <summary>
        ///// 工位5的工位等待时间
        ///// </summary>
        //[HslDeviceAddress("D4044")]
        //public int hold_duration_5 { get; set; }

        ///// <summary>
        ///// 工位6的工位等待时间
        ///// </summary>
        //[HslDeviceAddress("D4045")]
        //public int hold_duration_6 { get; set; }

        ///// <summary>
        ///// 工位7的工位等待时间
        ///// </summary>
        //[HslDeviceAddress("D4046")]
        //public int hold_duration_7 { get; set; }

        ///// <summary>
        ///// 工位8的工位等待时间
        ///// </summary>
        //[HslDeviceAddress("D4047")]
        //public int hold_duration_8 { get; set; }

        ///// <summary>
        ///// 工位9的工位等待时间
        ///// </summary>
        //[HslDeviceAddress("D4048")]
        //public int hold_duration_9 { get; set; }

        ///// <summary>
        ///// 工位10的工位等待时间
        ///// </summary>
        //[HslDeviceAddress("D4049")]
        //public int hold_duration_10 { get; set; }

        ///// <summary>
        ///// 工位11的工位等待时间
        ///// </summary>
        //[HslDeviceAddress("D4050")]
        //public int hold_duration_11 { get; set; }

        ///// <summary>
        ///// 工位12的工位等待时间
        ///// </summary>
        //[HslDeviceAddress("D4051")]
        //public int hold_duration_12 { get; set; }

        ///// <summary>
        ///// 工位13的工位等待时间
        ///// </summary>
        //[HslDeviceAddress("D4052")]
        //public int hold_duration_13 { get; set; }

        ///// <summary>
        ///// 工位14的工位等待时间
        ///// </summary>
        //[HslDeviceAddress("D4053")]
        //public int hold_duration_14 { get; set; }

        ///// <summary>
        ///// 工位15的工位等待时间
        ///// </summary>
        //[HslDeviceAddress("D4054")]
        //public int hold_duration_15 { get; set; }

        ///// <summary>
        ///// 工位16的工位等待时间
        ///// </summary>
        //[HslDeviceAddress("D4055")]
        //public int hold_duration_16 { get; set; }

        ///// <summary>
        ///// 工位17的工位等待时间
        ///// </summary>
        //[HslDeviceAddress("D4056")]
        //public int hold_duration_17 { get; set; }

        ///// <summary>
        ///// 工位18的工位等待时间
        ///// </summary>
        //[HslDeviceAddress("D4057")]
        //public int hold_duration_18 { get; set; }

        ///// <summary>
        ///// 工位19的工位等待时间
        ///// </summary>
        //[HslDeviceAddress("D4058")]
        //public int hold_duration_19 { get; set; }

        ///// <summary>
        ///// 工位20的工位等待时间
        ///// </summary>
        //[HslDeviceAddress("D4059")]
        //public int hold_duration_20 { get; set; }

        ///// <summary>
        ///// 工位1的产线移动时间
        ///// </summary>
        //[HslDeviceAddress("D4060", 20)]
        //public int[] transport_duration_1 { get; set; }

        ///// <summary>
        ///// 工位1的第三方产品id
        ///// </summary>
        //[HslDeviceAddress("D4200", 20)]
        //public Int64[] thd_product_id_1 { get; set; }

        ///// <summary>
        ///// 工位1的小车id
        ///// </summary>
        //[HslDeviceAddress("D4080", 20)]
        //public int[] device_id_1 { get; set; }
        #endregion
    }
}
