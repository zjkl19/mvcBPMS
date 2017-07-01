using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;   //FormCollection

//using mvcBPMS.Models.Entities;

namespace mvcBPMS.Models.Abstract
{
    public interface IStaffRepository
    {
        //IEnumerable<staff> staff { get; }
        IEnumerable<staff> prop_staff { get; }

        IEnumerable <staff> QueryStaffBystaff_no(int staff_no);

        bool AddStaff(FormCollection fc);
    }
}