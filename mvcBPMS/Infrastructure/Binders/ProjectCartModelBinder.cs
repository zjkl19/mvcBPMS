using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using mvcBPMS.Models.Entities;

namespace mvcBPMS.Infrastructure.Binders
{
    public class ProjectCartModelBinder:IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext,ModelBindingContext bindingContext)
        {
            //通过会话获取Cart
            ProjectCart cart = null;
            if(controllerContext.HttpContext.Session!= null)
            {
                cart = (ProjectCart)controllerContext.HttpContext.Session[sessionKey];
            }

            //若会话中没有Cart,则创建一个
            if (cart == null)
            {
                cart = new ProjectCart();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }

            //返回cart
            return cart;
        }
    }
}