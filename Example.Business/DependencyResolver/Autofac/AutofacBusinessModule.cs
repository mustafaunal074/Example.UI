using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Example.Business.Abstract;
using Example.Business.Concrete;
using Example.Core.DataAccess.Abstract;
using Example.Core.DataAccess.Concrete.EntityFramework;
using Example.DataAccess.Abstract;
using Example.DataAccess.Concrete.EntityFramework;
using Example.DataAccess.Concrete.EntityFramework.Context;

namespace Example.Business.DependencyResolver.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Transient
            //services.AddTransient<ICategoryDal, EfCategoryDal>();
            //builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().InstancePerDependency();
            //Scoped
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().InstancePerLifetimeScope();

            //Scoped
            //services.AddScoped<ICategoryService, CategoryManager>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<AuthManager>().As<IAuthService>().InstancePerLifetimeScope();

            //Scoped
            builder.RegisterType<EfUnitOfWork<AppDbContext>>().As<IUnitOfWork<AppDbContext>>().InstancePerLifetimeScope();

            //Singleton
            //builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
        }
    }
}
