namespace ReadPLCData
{
    public class DataValue
    {
        /// <summary>
        /// 持续时间
        /// </summary>
        public short[] Work_duration { get; set; }

        /// <summary>
        /// 等待时间
        /// </summary>
        public short[] Hold_duration { get; set; }

        /// <summary>
        /// 产线移动时间
        /// </summary>
        public short[] Transport_duration { get; set; }

        /// <summary>
        /// //第三方产品id
        /// </summary>
        public short[] Thd_product_id { get; set; }

        /// <summary>
        /// 小车id
        /// </summary>
        public short[] Device_id { get; set; }

        /// <summary>
        /// 实时持续时间
        /// </summary>
        public short[] Work_duration_s { get; set; }

        /// <summary>
        /// 实时等待时间
        /// </summary>
        public short[] Hold_duration_s { get; set; }

        /// <summary>
        /// 实时产线移动时间
        /// </summary>
        public short[] Transport_duration_s { get; set; }
    }
}