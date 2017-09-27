using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using mvcBPMS.Models.Abstract;
using mvcBPMS.Models.Entities;

using mvcBPMS.ViewModels;

namespace mvcBPMS.Controllers
{
    public class StaffCartController : Controller
    {
        //职工仓库（库模式）
        private IStaffRepository stfrepository;
 
        //构造函数
        public StaffCartController(IStaffRepository stfrepo)
        {
            stfrepository = stfrepo;
        }

        //列表
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
                ProjectCart = pCart,
                prop_staff = stfrepository.prop_staff
            };
            return View(model);
        }

        /// <summary>
        ///添加“职工购物车”
        /// </summary>
        /// <param name="cart">“职工购物车”<see cref="StaffCart"/></param>
        /// <param name="id">被添加职工的id</param>
        /// <param name="returnUrl"></param>
        /// <returns>RedirectToRouteResult</returns>
        public RedirectToRouteResult AddToStaffCart(StaffCart cart, string id, string returnUrl)
        {
            var staff = stfrepository.prop_staff.FirstOrDefault(p => p.id == id);
            if (staff != null)
            {
                cart.AddItem(staff);
            }
            return RedirectToAction("Index", new { returnUrl= returnUrl });
        }

        /// <summary>
        ///将“职工”从“职工购物车”中移除
        /// </summary>
        /// <param name="cart">“职工购物车”<see cref="StaffCart"/></param>
        /// <param name="id">被移除职工的id</param>
        /// <param name="returnUrl"></param>
        /// <returns>RedirectToRouteResult</returns>
        public RedirectToRouteResult RemoveFromStaffCart(StaffCart cart, string id, string returnUrl)
        {
            var staff = stfrepository.prop_staff.FirstOrDefault(p => p.id == id);
            if (staff != null)
            {
                cart.RemoveLine(staff);
            }
            return RedirectToAction("Index", new { returnUrl=returnUrl });
        }


        /// <summary>
        ///“项目购物车”-“职工购物车”显示页面
        /// </summary>
        /// <param name="pcart">“项目购物车”<see cref="ProjectCart"/></param>
        /// <param name="stfcart">“职工购物车”<see cref="StaffCart"/></param>
        /// <param name="returnUrl"></param>
        /// <returns>ViewResult</returns>
        public ViewResult Index(ProjectCart pCart,StaffCart stfCart, string returnUrl)
        {
            return View(new ProjectStaffCartIndexViewModel
            {


                ProjectCart = pCart,
                StaffCart = stfCart,
                ReturnUrl = returnUrl

            });
        }

        /// <summary>
        ///“项目购物车”-“职工购物车”结算
        /// </summary>
        /// <param name="pcart">“项目购物车”<see cref="ProjectCart"/></param>
        /// <param name="stfcart">“职工购物车”<see cref="StaffCart"/></param>
        /// <returns>ActionResult</returns>
        public ActionResult Checkout(ProjectCart prjcart, StaffCart stfCart)
        {

            if (stfCart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your StaffCart is empty.");
            }

            if (ModelState.IsValid)
            {
                //cart.Clear();
                //ViewBag.Items = cart;

                //TempData["projectCart"] = cart;
                //var td = (ProjectCart)TempData["projectCart"];
                //var ppCart = cart;
                //Session.Remove("Cart");
                return RedirectToAction("List", "StaffCart", new { pCart = stfCart });

                //return View(model);

                //测试代码
                //显示购物车清单
                //return View(new ProjectCartListViewModel
                //{
                //    ProjectCart = cart
                //});
            }
            return View("Completed");

        }
    }
}