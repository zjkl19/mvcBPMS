using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;   //FormCollection

namespace mvcBPMS.Models.Abstract
{
    public interface IR_project_staffRepository
    {
        
        IEnumerable<r_project_staff> prop_r_project_staff { get; }

        IEnumerable<r_project_staff> QueryR_project_staff_By_project_id(string project_id);

        IQueryable<join_r_project_staff_staff> Query_join_r_project_staff_staff_By_project_id(string project_id);

        //bool AddStaff(FormCollection fc)
    }
}