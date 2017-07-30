using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;   //FormCollection

namespace mvcBPMS.Models.Abstract
{
    public interface IR_project_staffRepository
    {
        //浏览全部职工项目参与信息
        IEnumerable<r_project_staff> prop_r_project_staff { get; }

        /// <summary>
        ///通过项目id查询职工的参与情况
        /// </summary>
        /// <param name="project_id">项目id(与数据库中的定义相关联)<see cref="project"/></param>
        /// <returns>指定项目id的职工参与情况<see cref="r_project_staff"/></returns>
        IEnumerable<r_project_staff> QueryR_project_staff_By_project_id(string project_id);

        /// <summary>
        ///通过项目id查询职工的参与情况
        /// </summary>
        /// <param name="project_id">项目id(与数据库中的定义相关联)<see cref="project"/></param>
        /// <returns>指定项目id的职工参与情况<see cref="join_r_project_staff_staff"/></returns>
        IQueryable<join_r_project_staff_staff> Query_join_r_project_staff_staff_By_project_id(string project_id);

        //bool AddStaff(FormCollection fc)
    }
}