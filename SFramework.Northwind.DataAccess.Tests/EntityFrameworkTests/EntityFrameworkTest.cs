using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFramework.Northwind.DataAccess.Concrete.EntityFramework;

namespace SFramework.Northwind.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            EfProductDal productDal = new EfProductDal();

            var result = productDal.GetList();
            Assert.IsNotNull(result);
            Assert.AreEqual(77, result.Count);

        }

        [TestMethod]
        public void Get_all_returns_all_filtered_products()
        {
            EfProductDal productDal = new EfProductDal();

            var result = productDal.GetList(p => p.ProductName.Contains("ab"));
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);

        }
    }
}
