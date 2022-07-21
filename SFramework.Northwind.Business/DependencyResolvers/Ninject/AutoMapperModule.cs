using AutoMapper;
using Ninject.Modules;

namespace SFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToConstant(GetMapperConfiguration().CreateMapper()).InSingletonScope();
        }

        private MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(GetType().Assembly);
            });
        }
    }
}
