using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using mvcBPMS.Models.Entities;

namespace mvcBPMS.Infrastructure.Binders
{
    public class StaffCartModelBinder : IModelBinder
    {
        private const string sessionKey = "staffCart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //通过会话获取Cart
            StaffCart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (StaffCart)controllerContext.HttpContext.Session[sessionKey];
            }

            //若会话中没有Cart,则创建一个
            if (cart == null)
            {
                cart = new StaffCart();
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