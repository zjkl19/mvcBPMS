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
        private IStaffRepository stfrepository;
 

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
                //ProjectCart= (ProjectCart)TempData["projectCart"],
                ProjectCart = pCart,
                prop_staff = stfrepository.prop_staff
            };
            return View(model);
        }

        public RedirectToRouteResult AddToStaffCart(StaffCart cart, string id, string returnUrl)
        {
            var staff = stfrepository.prop_staff.FirstOrDefault(p => p.id == id);
            if (staff != null)
            {
                cart.AddItem(staff);
            }
            return RedirectToAction("Index", new { returnUrl= returnUrl });
        }

        public RedirectToRouteResult RemoveFromStaffCart(StaffCart cart, string id, string returnUrl)
        {
            var staff = stfrepository.prop_staff.FirstOrDefault(p => p.id == id);
            if (staff != null)
            {
                cart.RemoveLine(staff);
            }
            return RedirectToAction("Index", new { returnUrl=returnUrl });
        }


        //private ProjectCart GetProjectCart()
        //{
        //
        //}

        public ViewResult Index(ProjectCart pCart,StaffCart stfCart, string returnUrl)
        {

           

            return View(new ProjectStaffCartIndexViewModel
            {


                ProjectCart = pCart,
                StaffCart = stfCart,
                ReturnUrl = returnUrl

            });
        }

        //结算项目"购物车"
        //[HttpPost]
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