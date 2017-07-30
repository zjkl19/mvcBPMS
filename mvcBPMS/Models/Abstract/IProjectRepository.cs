using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcBPMS.Models.Abstract
{
    public interface IProjectRepository
    {
        //浏览全部项目        
        IEnumerable<project> prop_project { get; }
        
    }
}