using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelCommon.Attribute
{
    /// <summary>
    /// 自定义描述信息,用于Excel表头
    /// </summary>
    public class ExcelDesAttribute : System.Attribute
    {
        public string ExcelDes { get; set; }

        public ExcelDesAttribute(string level)
        {
            this.ExcelDes = level;
        }
    }
}
