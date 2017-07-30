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

        //浏览全部职工项目参与信息
        public IEnumerable<r_project_staff> prop_r_project_staff
        { 
            get
            {
                return context.r_project_staff;
            }
        }

        /// <summary>
        ///通过项目id查询职工的参与情况
        /// </summary>
        /// <param name="project_id">项目id(与数据库中的定义相关联)<see cref="project"/></param>
        /// <returns>指定项目id的职工参与情况<see cref="r_project_staff"/></returns>
        public IEnumerable<r_project_staff> QueryR_project_staff_By_project_id(string project_id)
        {
            return context.r_project_staff.Where(p => p.project_id == project_id);
        }

        /// <summary>
        ///通过项目id查询职工的参与情况
        /// </summary>
        /// <param name="project_id">项目id(与数据库中的定义相关联)<see cref="project"/></param>
        /// <returns>指定项目id的职工参与情况<see cref="join_r_project_staff_staff"/></returns>
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