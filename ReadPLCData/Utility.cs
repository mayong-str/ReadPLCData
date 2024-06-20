using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ReadPLCData
{
    public class Utility
    {
        /// <summary>
        /// 转化实体类到数组
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static object[] ConvertEntityToArray(object entity)
        {
            Type type = entity.GetType();
            PropertyInfo[] properties = type.GetProperties();
            object[] values = new object[properties.Length];

            for (int i = 0; i < properties.Length; i++)
            {
                values[i] = properties[i].GetValue(entity);
            }

            return values;
        }


        /// <summary>
        /// xml字符串转DataTable
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        public static DataTable stam(string xmlPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);

            StringReader theReader = new StringReader(doc.OuterXml);
            DataSet theDataSet = new DataSet();
            theDataSet.ReadXml(theReader);

            return theDataSet.Tables[0];
        }


    }
}
