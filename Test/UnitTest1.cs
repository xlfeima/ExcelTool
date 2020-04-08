using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Test.Models;
using System.ComponentModel;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Type T = typeof(USER_INFO);//类型
            Object[] records = T.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);//获取描述属性
            var result = T.GetProperties();
            Dictionary<string, string> cellheader = new Dictionary<string, string>();
            foreach (var item in result)
            {
                var obs = item.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                var value = string.Empty;
                foreach (System.ComponentModel.DescriptionAttribute record in obs)
                {
                    value = record.Description;
                }
                var Key = item.Name;
                cellheader.Add(Key, value);
            }
        }
    }
}
