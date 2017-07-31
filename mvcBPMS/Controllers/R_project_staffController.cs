using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using mvcBPMS.Models.Abstract;

namespace mvcBPMS.Controllers
{
    public class R_project_staffController : Controller
    {
        //项目-职工关联表仓库
        private IR_project_staffRepository repository;

        //构造函数
        public R_project_staffController(IR_project_staffRepository repo)
        {
            this.repository = repo;
        }

        // GET: R_project_staff
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///查询“项目-职工”关联表
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult QueryR_project_staff()
        {
            //Models.BPMSxEntities db = new Models.BPMSxEntities();
            //var query = from q in db.staff
            //           select q;
            //return View(query);
            ViewBag.query = 0;
            return View();
        }

        /// <summary>
        ///通过项目id查询“项目-职工”关联表信息
        /// </summary>
        /// <param name="fc">含有项目id的表单</param>
        /// <returns>ViewResult</returns>
        [HttpPost]
        public ViewResult QueryR_project_staff(FormCollection fc)
        {
            string project_id = Convert.ToString(fc["project_id"]);     //读入表单数据

            //Models.BPMSxEntities db = new Models.BPMSxEntities();

            //var query = from q in db.staff
            //            where q.staff_no == staff_no
            //            select q;

            //ViewBag.staff_no = staff_no;
            ViewBag.query = 1;

            //return View(query);
            //return View(repository.staff);
            return View(repository.QueryR_project_staff_By_project_id(project_id));
        }

        /// <summary>
        ///查询指定项目id参与的职工信息
        /// </summary>
        /// <returns>ActionResult</returns>
        [ChildActionOnly]
        public ActionResult GetRelatedstaff()
        {
            return PartialView(repository.Query_join_r_project_staff_staff_By_project_id("8387a311a7d44bcc9c2e43e8b49d9e2d"));
        }

        /// <summary>
        ///添加“项目-职工”关联表中的记录（开发者测试使用）
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult AddR_project_staff()
        {
            return View();
        }

        /// <summary>
        ///添加“项目-职工”关联表中的记录（开发者测试使用）
        /// </summary>
        /// <param name="fc">包含项目id，职工工号等信息的表单</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult AddR_project_staff(FormCollection fc)
        {

            string project_id = Convert.ToString(fc["project_id"]);
            int staff_no = Convert.ToInt32(fc["staff_no"]);
            double scene_coff = Convert.ToDouble(fc["scene_coff"]);
            double plan_coff = Convert.ToDouble(fc["plan_coff"]);
            double report_coff = Convert.ToDouble(fc["report_coff"]);
            double report_check_coff = Convert.ToDouble(fc["report_check"]);
            double others_check = Convert.ToDouble(fc["others_check"]);

            var newData = new Models.r_project_staff();

            newData.id = Guid.NewGuid().ToString("N"); //去掉短横杠

            newData.project_id = project_id;

            Models.BPMSxEntities db = new Models.BPMSxEntities();

            var query = (from p in db.staff
                         where p.staff_no == staff_no
                         select new
                         {
                             p.id
                         }
             ).DefaultIfEmpty();

            newData.staff_id = query.First().id;

            newData.scene_coff = scene_coff;
            newData.plan_coff = plan_coff;
            newData.report_coff = plan_coff;
            newData.report_check_coff = report_check_coff;
            newData.others_coff = others_check;


            try
            {
                db.r_project_staff.Add(newData);
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