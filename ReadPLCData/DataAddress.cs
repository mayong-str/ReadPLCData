namespace ReadPLCData
{
    public class DataAddress
    {
        /// <summary>
        /// 持续时间 PLC软元件地址
        /// </summary>
        public string[] Work_duration_address { get; set; }

        /// <summary>
        /// 等待时间 PLC软元件地址
        /// </summary>
        public string[] Hold_duration_address { get; set; }

        /// <summary>
        /// 产线移动时间 PLC软元件地址
        /// </summary>
        public string[] Transport_duration_address { get; set; }

        /// <summary>
        /// 第三方产品id PLC软元件地址
        /// </summary>
        public string[] Thd_product_id_address { get; set; }

        /// <summary>
        /// 小车id PLC软元件地址
        /// </summary>
        public string[] Device_id_address { get; set; }

        /// <summary>
        /// 实时持续时间 PLC软元件地址
        /// </summary>
        public string[] Work_duration_address_s { get; set; }

        /// <summary>
        /// 实时等待时间 PLC软元件地址
        /// </summary>
        public string[] Hold_duration_address_s { get; set; }

        /// <summary>
        /// 实时产线移动时间 PLC软元件地址
        /// </summary>
        public string[] Transport_duration_address_s { get; set; }
    }
}