using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

using Ninject;

using mvcBPMS.Models;
using mvcBPMS.Models.Abstract;
using mvcBPMS.Models.Concrete;
//using mvcBPMS.Models.Entities;

//using Moq;

namespace mvcBPMS.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object>GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            //将绑定放这里
            kernel.Bind<IStaffRepository>().To<EFStaffRepository>();
            kernel.Bind<IR_project_staffRepository>().To<EFR_project_staffRepository>();
            kernel.Bind<IProjectRepository>().To<EFProjectRepository>();
        }
    }
}