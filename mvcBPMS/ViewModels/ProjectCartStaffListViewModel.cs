using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using mvcBPMS.Models;

//20170626
using mvcBPMS.Models.Entities;

namespace mvcBPMS.ViewModels
{
    public class ProjectCartStaffListViewModel
    {
        public ProjectCart ProjectCart { get; set; }
        public IEnumerable<staff> prop_staff { get; set; }
    }
}