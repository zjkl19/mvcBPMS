using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcBPMS.Controllers
{
    //该类暂时弃用 林迪南 20170731
    public class Project_diffcult_coffController : Controller
    {
        // GET: Project_diffcult_coff
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProject_diffcult_coff()
        {
            return View();
        }

        /// <summary>
        /// 添加项目难度系数信息
        /// </summary>
        /// <param name="fc">页面表单元素的数据</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddProject_diffcult_coff(FormCollection fc)
        {

            string prj_diffculty_type = Convert.ToString(fc["prj_diffculty_type"]);
            double diffcult_coff = Convert.ToDouble(fc["diffcult_coff"]);

            var newData = new Models.project_diffcult_coff();

            newData.id = Guid.NewGuid().ToString("N"); //去掉短横杠

            Models.BPMSxEntities db = new Models.BPMSxEntities();

            newData.prj_diffculty_type = prj_diffculty_type;
            newData.diffcult_coff = diffcult_coff;

            try
            {
                db.project_diffcult_coff.Add(newData);
                db.SaveChanges();
                ViewBag.message = "添加信息成功！";    //数据库操作回显信息
            }
            catch (Exception ex)
            {
                throw new Exception("数据库添加信息出现异常。");
            }

            return View();

        }
    }
}