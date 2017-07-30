using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using mvcBPMS.Models.Abstract;

namespace mvcBPMS.Models.Concrete
{
    public class EFProjectRepository:IProjectRepository
    {
        private EFDbContext context = new EFDbContext();

        //浏览全部项目
        public IEnumerable<project> prop_project
        {
            get
            {
                return context.project;
            }
        }
    }
}