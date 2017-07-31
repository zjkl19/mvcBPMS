using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using mvcBPMS.Models.Abstract;

//20170625添加,林迪南
using mvcBPMS.Models.Entities;

using mvcBPMS.ViewModels;


using Ninject;


using System.Security.Cryptography;     //Md5加密
using System.Text;

namespace mvcBPMS.Controllers
{
    public class StaffController : Controller
    {
        //职工仓库（库模式）
        private IStaffRepository repository;

        //构造函数
        public StaffController(IStaffRepository staffRepository)
        {
            this.repository = staffRepository;
        }

        /// <summary>
        ///Index表示控制器默认页面
        /// <returns>ViewResult</returns>
        public ViewResult Index()
        {
            //Models.BPMSxEntities db = new Models.BPMSxEntities();

            //var data = db.staff;

            //return View(data);
            return View(repository.prop_staff);
        }

        /// <summary>
        ///列出指定项目购物车下，所有职工信息
        /// </summary>
        /// <param name="pcart">准备进行结算的“项目购物车”<see cref="ProjectCart"/></param>
        /// <returns>ViewResult</returns>
        public ViewResult List(ProjectCart pCart)
        {

            //ProjectCart pc;
            //return View(repository.prop_project);

            //临时代码
            //后面用自定义视图模型替代
            //ViewBag.pCart = pCart;
            //Session.Clear();
            //ViewBag.ProjectCart = pCart;
            var model = new ProjectCartStaffListViewModel
            {
                //ProjectCart= (ProjectCart)TempData["projectCart"],
                ProjectCart = pCart,
                prop_staff = repository.prop_staff
            };
            return View(model);
        }

        /// <summary>
        /// 职工信息查询
        /// </summary>
        public ActionResult QueryStaff()
        {

            ViewBag.query = 0;
            return View();
        }

        /// <summary>
        /// 列出指定工号的职工信息
        /// </summary>
        /// <param name="fc">包含工号的页面表单元素</param>
        /// <returns>ViewResult:指定工号的职工信息的视图</returns>
        [HttpPost]
        public ViewResult QueryStaff(FormCollection fc)
        {
            int staff_no = Convert.ToInt32(fc["staff_no"]);     //读入表单数据

            ViewBag.staff_no = staff_no;
            ViewBag.query = 1;

            //return View(query);
            //return View(repository.staff);
            return View(repository.QueryStaffBystaff_no(staff_no));
        }

        //[ChildActionOnly]
        //public ActionResult GetDetailstaff()
        //{
        //    return PartialView(repository.QueryStaffBystaff_no(1743));
        //}


        /// <summary>
        /// 添加职工信息
        /// </summary>
        /// <returns>ViewResult:添加职工信息的视图</returns>
        public ViewResult AddStaff()
        {      
            return View();
        }

        /// <summary>
        /// 添加职工信息
        /// </summary>
        /// <param name="fc">含有职工信息的表单</param>
        /// <returns>ViewResult:添加职工信息的后返回的视图</returns>
        [HttpPost]
        public ViewResult AddStaff(FormCollection fc)
        {
            ViewBag.message = "添加信息成功！";

            var result=repository.AddStaff(fc);

            if( result==false)
            { 
                ViewBag.message = "添加信息失败！";
            }
            return View();

        }

        /// <summary>
        /// 修改职工信息
        /// </summary>
        /// <returns>ViewResult:修改职工信息的视图</returns>
        public ViewResult ModStaff()
        {
            return View();
        }

        /// <summary>
        /// 修改指定工号的职工信息
        /// </summary>
        /// <param name="fc">含有职工信息的表单</param>
        /// <returns>ViewResult:修改职工信息的后返回的视图</returns>
        [HttpPost]
        public ActionResult ModStaff(FormCollection fc)
        {

            int staff_no = Convert.ToInt32(fc["staff_no"]);
            string staff_password = Convert.ToString(fc["staff_password"]);
            string staff_name = Convert.ToString(fc["staff_name"]);
            string gender = Convert.ToString(fc["gender"]);
            string office_phone = Convert.ToString(fc["office_phone"]);
            string mobile_phone = Convert.ToString(fc["mobile_phone"]);
            string position = Convert.ToString(fc["position"]);


            using (Models.BPMSxEntities db = new Models.BPMSxEntities())
            {
                var query = from p in db.staff
                            where p.staff_no == staff_no
                            select p;
                if (query != null)
                {
                    foreach (var q in query)
                    {
                        q.staff_password = "";

                        MD5 md5 = MD5.Create(); //实例化一个md5对像
                        byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(staff_password));//加密后是一个字节类型的数组

                        //字符串拼接
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            q.staff_password = q.staff_password + bytes[i].ToString("x2");
                            //sb.Append(bytes[i]);
                        }
                        //return sb.ToString();

                        //newData.staff_password = sb.ToString();

                        q.staff_name = staff_name;
                        if (gender == "男")
                        {
                            q.gender = false;
                        }
                        else
                        {
                            q.gender = true;
                        }

                        q.office_phone = office_phone;
                        q.mobile_phone = mobile_phone;
                        q.position = position;
                    }

                    try
                    {
                        db.SaveChanges();
                        ViewBag.message = "修改信息成功！";    //数据库操作回显信息
                    }
                    catch (Exception ex)
                    //catch (DbEntityValidationException dbEx)

                    {
                        throw new Exception("数据库更新信息出现异常。");
                    }
                    
                }
            }
                return View();
        }

       
    }
}