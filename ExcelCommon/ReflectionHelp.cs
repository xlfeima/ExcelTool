using ExcelCommon.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelCommon
{
    public class ReflectionHelp
    {
        /// <summary>
        /// 泛型获取表单元格抬头
        /// </summary>
        /// <typeparam name="T"></typeparam>
        ///  key：实体对象属性名称，可通过反射获取值
        /// value：属性对应的Description中文注解
        /// <returns></returns>
        public static Dictionary<string, string> CellHeader<T>()
        {
            Type T1 = typeof(T);//类型
            var result = T1.GetProperties();//获取属性
            Dictionary<string, string> cellheader = new Dictionary<string, string>();
            foreach (var item in result)
            {
                var obs = item.GetCustomAttributes(typeof(ExcelDesAttribute), false);//获取字段的Description属性
                var value = string.Empty;
                foreach (ExcelDesAttribute record in obs)
                {
                    value = record.ExcelDes;
                }
                var Key = item.Name;//字段名称
                cellheader.Add(Key, value);
            }
            return cellheader;
        }
    }
}
