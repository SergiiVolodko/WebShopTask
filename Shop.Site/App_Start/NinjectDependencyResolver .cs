﻿using System;
using System.Collections.Generic;
using Ninject;

namespace Shop.Site
{
    public class NinjectDependencyResolver: 
     System.Web.Http.Dependencies.IDependencyResolver
     {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
         {
             _kernel = kernel;
         }
         public System.Web.Http.Dependencies.IDependencyScope BeginScope()
         {
             return this;
         }
  
         public object GetService(Type serviceType)
         {
             return _kernel.TryGet(serviceType);
         }
  
         public IEnumerable<object> GetServices(Type serviceType)
         {
             try
             {
                 return _kernel.GetAll(serviceType);
             }
             catch (Exception)
             {
                 return new List<object>();
             }
         }
  
         public void Dispose()
         {
             // When BeginScope returns 'this', the Dispose method must be a no-op.
         }
    }
}