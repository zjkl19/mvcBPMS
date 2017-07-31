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

        /// <summary>
        ///通过工号查询职工信息
        /// </summary>
        /// <param name="staff_no">职工工号(与数据库中的定义相关联)<see cref="staff"/></param>
        /// <returns>指定工号的职工详细信息<see cref="r_project_staff"/></returns>
        IEnumerable<staff> QueryStaffBystaff_no(int staff_no);

        /// <summary>
        ///往数据库添加职工信息
        /// </summary>
        /// <param name="fc">包含工号、姓名等在内的表单信息</param>
        /// <returns>添加成功返回1，否则返回0</returns>
        bool AddStaff(FormCollection fc);
    }
}