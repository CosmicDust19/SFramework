using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using SFramework.Core.DataAccess.NHibernate;

namespace SFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers
{
    public class SqlServerHelper : NHibernateHelper
    {
        protected override ISessionFactory InitializeFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("NorthwindContext")))
                .Mappings(t => t.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
    }
}
