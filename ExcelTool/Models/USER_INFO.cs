using ExcelCommon;
using ExcelCommon.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelTool
{
    public class USER_INFO
    {
        /// <summary>
        /// 用户工号
        /// </summary>
        [ExcelDes("用户工号")]
        [ExcelNoNull(true)]//设置后导入excel该字段不能为空
        public string USER_NO { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [ExcelDes("姓名")]
        public string USER_NAME { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [ExcelDes("邮箱")]
        public DateTime? Email { get; set; }

    }
}
