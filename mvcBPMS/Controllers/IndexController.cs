using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcBPMS.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            Models.BPMSxEntities db = new Models.BPMSxEntities();

            var data = db.contact;

            return View(data);
        }
    }
}