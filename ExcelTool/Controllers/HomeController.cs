using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelCommon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExcelTool.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        ///文件上传
        /// </summary>
        /// <returns></returns>
        public IActionResult UpLoadFile(IFormFile file)
        {
            // 1.1存放Excel文件到本地服务器
            string filePath = ExcelHelper.SaveExcelFile(file);
            // 保存文件并获取文件路径
            //// 单元格抬头
            // Description 属性对应抬头文字
            var cellheader = ReflectionHelp.CellHeader<USER_INFO>();
            // 1.2解析文件，存放到一个List集合里
            StringBuilder errorMsg = new StringBuilder();

            List<USER_INFO> enlist = ExcelHelper.ExcelToEntityList<USER_INFO>(cellheader, filePath, out errorMsg);
         
            // TODO：其他检测
            bool isSuccess = false;
            if (errorMsg.Length == 0)
            {
                isSuccess = true; // 若错误信息成都为空，表示无错误信息
            }

            var rs = new { success = isSuccess, msg = errorMsg.ToString(), data = enlist };

            return Json(rs);
        }

        /// <summary>
        /// 实体导出成Excel对象
        /// </summary>
        public IActionResult EntityToExcel()
        {
            List<USER_INFO> list = new List<USER_INFO>() {

                 new USER_INFO{ USER_NO="xxx",USER_NAME="xx",Email=DateTime.Now},
                 new USER_INFO { USER_NO = "xxx", USER_NAME = "xx", Email = DateTime.Now },
                 new USER_INFO { USER_NO = "xxxx", USER_NAME = "xx", Email =DateTime.Now }
            };
            // 2.设置单元格抬头
            // key：实体对象属性名称，可通过反射获取值
            // value：Excel列的名称
            var cellheader = ReflectionHelp.CellHeader<USER_INFO>();

            var result = ExcelHelper.EntityListToExcel2003(cellheader, list, "个人信息");

            return null;
        }
    }
}
