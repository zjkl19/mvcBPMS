using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using mvcBPMS.Models.Entities;

namespace mvcBPMS.Models.Abstract
{
    public interface IProjectCartProcessor
    {
        void ProcessProjectCart(ProjectCart cart);
    }
}