using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadPLCData
{
    public class PLCAddressValue
    {
        //存放读取PLC软元件地址的值
        public List<string> work_duration { get; set; } //作业持续时间  
        public List<string> hold_duration { get; set; } //工位等待时间
        public List<string> transport_duration { get; set; } //产线移动时间
        public List<string> thd_product_id { get; set; } //第三方产品id
        public List<string> device_id { get; set; } //小车id
    }
}
