using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using mvcBPMS.Models.Entities;

namespace mvcBPMS.ViewModels
{
    public class ProjectCartIndexViewModel
    {
        public ProjectCart ProjectCart { get; set; }
        public string ReturnUrl { get; set; }
    }
}