using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using mvcBPMS.Models.Abstract;
using mvcBPMS.ViewModels;


using mvcBPMS.Models.Concrete;  //以后删掉这句

using Ninject;

namespace mvcBPMS.Controllers
{
    public class ProjectController : Controller
    {
        //项目仓库（库模式）
        private IProjectRepository repository;

        //构造函数
        public ProjectController(IProjectRepository projectRepository)
        {
            this.repository = projectRepository;
        }

        /// <summary>
        ///项目信息总览
        /// <returns>ViewResult</returns>
        public ViewResult Index()
        {
            return View(repository.prop_project);
        }

        /// <summary>
        ///项目成员管理
        /// <returns>ViewResult</returns>
        public ViewResult List()
        {
            //return View(repository.prop_project);
            var model = new ProjectListViewModel
            {
                prop_project = repository.prop_project
            };
             return View(model);
        }

        /// <summary>
        ///添加项目信息初始页面
        /// <returns>ViewResult</returns>
        public ActionResult AddProject()
        {
            return View();
        }

        /// <summary>
        /// 添加项目信息
        /// </summary>
        /// <param name="fc">包含关联合同编号，项目名称等信息在内的表单</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult AddProject(FormCollection fc)
        {

            string contact_no = Convert.ToString(fc["contact_no"]);
            string project_name = Convert.ToString(fc["project_name"]);
            Decimal standard_product_value = Convert.ToDecimal(fc["standard_product_value"]);
            DateTime enter_data = Convert.ToDateTime(fc["enter_data"]);
            DateTime exit_data = Convert.ToDateTime(fc["exit_data"]);
            DateTime approved_datatime = Convert.ToDateTime(fc["approved_datatime"]);

          
            var newData = new Models.project();

            newData.id = Guid.NewGuid().ToString("N"); //去掉短横杠

            //Models.BPMSxEntities db = new Models.BPMSxEntities();
            var db = new EFDbContext();

            //合同编号为空，表示项目无关联合同
            if (contact_no != "")
            {
                var query = (from p in db.contact
                             where p.contact_no == contact_no.ToUpper()
                             select new
                             {
                                 p.id
                             }
                 ).DefaultIfEmpty();

                newData.contact_id = query.First().id;

            }

            newData.project_name = project_name;

            newData.standard_product_value = standard_product_value;

            newData.enter_date = enter_data;

            newData.exit_date = exit_data;

            newData.approved_datatime= approved_datatime;
            
            try
            {
                db.project.Add(newData);
                db.SaveChanges();
                ViewBag.message = "添加信息成功！";    //数据库操作回显信息
            }
            catch (Exception ex)
            //catch (DbEntityValidationException dbEx)

            {
                throw new Exception("数据库添加信息出现异常。");
            }

            //var data = new Models.staff();
            return View();

        }

        /// <summary>
        /// 修改项目信息初始页面
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult ModProject()
        {

            return View();
        }

        /// <summary>
        /// 修改指定项目id的项目信息
        /// </summary>
        /// <param name="fc">包含准备修改项目的id、关联合同编号、项目名称等信息</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult ModProject(FormCollection fc)
        {
            string id = Convert.ToString(fc["id"]);

            string contact_no = Convert.ToString(fc["contact_no"]);
            string contact_id = "";

            string project_name = Convert.ToString(fc["project_name"]);
            Decimal standard_product_value = Convert.ToDecimal(fc["standard_product_value"]);
            DateTime enter_data = Convert.ToDateTime(fc["enter_data"]);
            DateTime exit_data = Convert.ToDateTime(fc["exit_data"]);
            DateTime approved_datatime = Convert.ToDateTime(fc["approved_datatime"]);

            using (Models.BPMSxEntities db = new Models.BPMSxEntities())
            {

                var query = db.project.FirstOrDefault(p => p.id == id);

                if (query != null)
                {
                    //合同编号为空，表示项目无关联合同
                    if (contact_no != "")
                    {
                        var q = (from p in db.contact
                                 where p.contact_no == contact_no.ToUpper()
                                 select new
                                 {
                                     p.id
                                 }
                         ).DefaultIfEmpty();

                        contact_id = q.First().id;

                    }
                    query.contact_id = contact_id;

                    query.project_name = project_name;
                    query.standard_product_value = standard_product_value;
                    query.enter_date = enter_data;
                    query.exit_date = exit_data;
                    query.approved_datatime = approved_datatime;

                    try
                    {
                        db.SaveChanges();
                        ViewBag.message = "修改信息成功！";    //数据库操作回显信息
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("数据库更新信息出现异常。");
                    }

                }
            }
            return View();
        }
    }
}