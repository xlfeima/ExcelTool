using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Test.Models
{
    public class USER_INFO
    {
        /// <summary>
        /// 用户工号
        /// </summary>
        [Description("用户工号")]
        public string USER_NO { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Description("姓名")]

        public string USER_NAME { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [Description("邮箱")]

        public string Email { get; set; }

    }
}
