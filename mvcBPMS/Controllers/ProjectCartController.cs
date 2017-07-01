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
        private IProjectRepository repository;

        public ProjectCartController(IProjectRepository repo)
        {
            repository = repo;
        }

        public RedirectToRouteResult AddToProjectCart(ProjectCart cart, string id,string returnUrl)
        {
            var project = repository.prop_project.FirstOrDefault(p => p.id == id);
            if(project!=null)
            {
                cart.AddItem(project);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromProjectCart(ProjectCart cart, string id,string returnUrl)
        {
            var project = repository.prop_project.FirstOrDefault(p => p.id ==id);
            if (project != null)
            {
                cart.RemoveLine(project);
            }
            return RedirectToAction("Index", new { returnUrl });
        }


        public ViewResult Index(ProjectCart cart,string returnUrl)
        {
            return View(new ProjectCartIndexViewModel
            {
                ReturnUrl = returnUrl,
                ProjectCart = cart
                
            });
        }

        //结算项目"购物车"
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