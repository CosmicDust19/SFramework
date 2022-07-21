using FluentValidation;
using Ninject.Modules;
using SFramework.Northwind.Business.ValidationRules.FluentValidation;
using SFramework.Northwind.Entities.Concrete;

namespace SFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class ValidationModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidator>().InSingletonScope();
        }
    }
}
