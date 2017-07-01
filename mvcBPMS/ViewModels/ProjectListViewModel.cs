using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using mvcBPMS.Models;

namespace mvcBPMS.ViewModels
{
    public class ProjectListViewModel
    {
        public IEnumerable<project> prop_project { get; set; }
    }
}