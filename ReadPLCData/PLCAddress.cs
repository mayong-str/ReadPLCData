using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadPLCData
{
    public class PLCAddress
    {
        //存放PLC软元件地址
        public List<string> Work_duration_address { get; set; } //作业持续时间  
        public List<string> Hold_duration_address { get; set; } //工位等待时间
        public List<string> Transport_duration_address { get; set; } //产线移动时间
        public List<string> Thd_product_id_address { get; set; } //第三方产品id
        public List<string> Device_id_address { get; set; } //小车id
    }
}
