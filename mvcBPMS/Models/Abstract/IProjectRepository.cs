using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcBPMS.Models.Abstract
{
    public interface IProjectRepository
    {
        
        IEnumerable <project> prop_project { get; }

        
    }
}