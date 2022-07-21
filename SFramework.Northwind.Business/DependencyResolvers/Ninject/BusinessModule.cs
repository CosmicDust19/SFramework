using System.Data.Entity;
using Ninject.Modules;
using SFramework.Core.DataAccess;
using SFramework.Core.DataAccess.EntityFramework;
using SFramework.Core.DataAccess.NHibernate;
using SFramework.Northwind.Business.Abstract;
using SFramework.Northwind.Business.Concrete.Managers;
using SFramework.Northwind.DataAccess.Abstract;
using SFramework.Northwind.DataAccess.Concrete.EntityFramework;
using SFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers;

namespace SFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            //Business
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IUserService>().To<UserManager>().InSingletonScope();

            //DataAccess
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>)).InSingletonScope();
            Bind<DbContext>().To<NorthwindContext>().InSingletonScope();
            Bind<NHibernateHelper>().To<SqlServerHelper>().InSingletonScope();

        }
        
    }
}
