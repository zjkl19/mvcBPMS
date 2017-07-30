using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//using mvcBPMS.Models.Entities;
using System.Data.Entity;

namespace mvcBPMS.Models.Concrete
{
    public class EFDbContext:DbContext
    {

        public DbSet<staff> staff { get; set; }

        public DbSet<contact> contact { get; set; }

        public DbSet<r_project_staff> r_project_staff { get; set; }

        public DbSet<project> project { get; set; }

        public System.Data.Entity.DbSet<mvcBPMS.Models.join_r_project_staff_staff> join_r_project_staff_staff { get; set; }
    }
}