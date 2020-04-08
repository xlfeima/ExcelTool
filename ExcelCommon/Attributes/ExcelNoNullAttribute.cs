using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelCommon.Attribute
{
    /// <summary>
    /// 验证字段不为空属性
    /// true 则表示不可为空
    /// </summary>
    /// 
    public class ExcelNoNullAttribute : System.Attribute
    {

        public bool ExcelNoNull { get; set; }

        public ExcelNoNullAttribute(bool level)
        {
            this.ExcelNoNull = level;
        }
    }
}
