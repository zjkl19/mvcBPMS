using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using mvcBPMS.Models;

namespace mvcBPMS.ViewModels
{
    public class staff_r_project_staffViewModel
    {
         public IEnumerable<staff> staff { get; set; }
         public IEnumerable<r_project_staff> r_project_staff { get; set; }
       
    }
}