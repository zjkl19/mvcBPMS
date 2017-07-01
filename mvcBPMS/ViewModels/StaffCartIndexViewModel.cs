using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using mvcBPMS.Models.Entities;

namespace mvcBPMS.ViewModels
{
    public class ProjectStaffCartIndexViewModel
    {
        public ProjectCart ProjectCart { get; set; }
        public StaffCart StaffCart { get; set; }
        public string ReturnUrl { get; set; }
    }
}