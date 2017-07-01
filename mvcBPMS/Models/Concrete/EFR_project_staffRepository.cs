using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using mvcBPMS.Models.Abstract;

namespace mvcBPMS.Models.Concrete
{
    public class EFR_project_staffRepository:IR_project_staffRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<r_project_staff> prop_r_project_staff
        { 
            get
            {
                return context.r_project_staff;
            }
        }

        public IEnumerable<r_project_staff> QueryR_project_staff_By_project_id(string project_id)
        {
            return context.r_project_staff.Where(p => p.project_id == project_id);
        }

        public IQueryable<join_r_project_staff_staff> Query_join_r_project_staff_staff_By_project_id(string project_id)
        {
            var query = from p in context.staff
                         join q in context.r_project_staff
                         on p.id equals q.staff_id
                         where q.project_id == project_id
                         //select p;
                         select new join_r_project_staff_staff
                         {
                             id = p.id,
                             staff_no = p.staff_no,
                             staff_name = p.staff_name
                         };
            return query;
        }
    }
}