using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcBPMS.Controllers
{
    public class projectController : Controller
    {
        // GET: project
        //显示前n条项目信息
        public ActionResult Index()
        {
            int n = 50;     //显示前50条数据

            //创建数据库实体
            var db = new Models.BPMSxEntities();

            //var data = db.project;   //查询所有数据

            var data = (from p in db.project
                        select p).Take(n);

            return View(data);
        }

        public ActionResult SearchProject()
        {
            var keyStr = "桥梁";  //搜索关键字
            //创建数据库实体
            var db = new Models.BPMSxEntities();

            var data = from p in db.project
                       where p.project_name.Contains(keyStr)
                       select p;

            return View(data);

        }

        [HttpGet]
        public ActionResult ProjectDetails(string id)
        {

            //创建数据库实体
            var db = new Models.BPMSxEntities();

            //int option = 1;

  
                var data= from p in db.project
                          where p.id == id
                          select p;

            
            var data1 = from p in db.contact
                        join p1 in db.project
                        on p.id equals p1.contact_id
                        where p1.id == id
                        select p;

            //from t in db.tb_projects
            //from t0 in db.tb_staffs
            //where
            //  t.resp_staff_no == t0.staff_no &&
            //  t0.staff_name == "李鹏"
            //select new
            //{
            //    项目名称 = t.prj_name,
            //    t0.staff_name
            //}

            ViewBag.cnt = data1;

            var data2 = from p in db.r_project_staff
                        where p.project_id == id
                        select p;

            ViewBag.r_p_s = data2;

            var data3 = from p in db.project_money_flow
                        where p.project_id == id
                        select p;

            ViewBag.p_m_f = data3;

            return View(data);
        }
    }
}