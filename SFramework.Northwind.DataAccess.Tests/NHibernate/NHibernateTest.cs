using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFramework.Northwind.DataAccess.Concrete.NHibernate;
using SFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers;

namespace SFramework.Northwind.DataAccess.Tests.NHibernate
{
    [TestClass]
    public class NHibernateTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());

            var result = productDal.GetList();
            Assert.IsNotNull(result);
            Assert.AreEqual(77, result.Count);

        }

        [TestMethod]
        public void Get_all_returns_all_filtered_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());

            var result = productDal.GetList(p => p.ProductName.Contains("ab"));
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);

        }
    }
}
