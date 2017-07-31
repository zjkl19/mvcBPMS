using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using mvcBPMS.Models;
using mvcBPMS.Models.Abstract;
using mvcBPMS.Models.Entities;

using mvcBPMS.ViewModels;

namespace mvcBPMS.Controllers
{
    public class ProjectCartController : Controller
    {
        //项目仓库（库模式）
        private IProjectRepository repository;

        //构造函数
        public ProjectCartController(IProjectRepository repo)
        {
            repository = repo;
        }

        /// <summary>
        ///添加“项目购物车”
        /// </summary>
        /// <param name="cart">“项目购物车”<see cref="ProjectCart"/></param>
        /// <param name="id">被添加项目的id</param>
        /// <param name="returnUrl"></param>
        /// <returns>RedirectToRouteResult</returns>
        public RedirectToRouteResult AddToProjectCart(ProjectCart cart, string id,string returnUrl)
        {
            var project = repository.prop_project.FirstOrDefault(p => p.id == id);
            if(project!=null)
            {
                cart.AddItem(project);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        ///将“项目”从“项目购物车”中移除
        /// </summary>
        /// <param name="cart">“项目购物车”<see cref="ProjectCart"/></param>
        /// <param name="id">被移除项目的id</param>
        /// <param name="returnUrl"></param>
        /// <returns>RedirectToRouteResult</returns>
        public RedirectToRouteResult RemoveFromProjectCart(ProjectCart cart, string id,string returnUrl)
        {
            var project = repository.prop_project.FirstOrDefault(p => p.id ==id);
            if (project != null)
            {
                cart.RemoveLine(project);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        ///首页
        /// </summary>
        /// <param name="cart">“项目购物车”<see cref="ProjectCart"/></param>
        /// <param name="id">被移除项目的id</param>
        /// <param name="returnUrl"></param>
        /// <returns>RedirectToRouteResult</returns>
        public ViewResult Index(ProjectCart cart,string returnUrl)
        {
            return View(new ProjectCartIndexViewModel
            {
                ReturnUrl = returnUrl,
                ProjectCart = cart
                
            });
        }

        /// <summary>
        /// 结算“项目购物车”
        /// </summary>
        /// <param name="cart">“项目购物车”<see cref="ProjectCart"/></param>
        /// <returns>ActionResult</returns>

        //[HttpPost]
        public ActionResult Checkout(ProjectCart cart)
        {
            
            if (cart.Lines.Count()==0)
            {
                ModelState.AddModelError("", "Sorry, your ProjectCart is empty.");
            }

            if (ModelState.IsValid)
            {
                //cart.Clear();
                //ViewBag.Items = cart;

                //TempData["projectCart"] = cart;
                //var td = (ProjectCart)TempData["projectCart"];
                //Session.Remove("Cart");
                return RedirectToAction("List","StaffCart", new { pCart= cart });              

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