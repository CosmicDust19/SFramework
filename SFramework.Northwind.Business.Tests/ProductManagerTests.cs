using AutoMapper;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SFramework.Northwind.Business.Concrete.Managers;
using SFramework.Northwind.DataAccess.Abstract;
using SFramework.Northwind.Entities.Concrete;

namespace SFramework.Northwind.Business.Tests
{

    [TestClass]
    public class ProductManagerTests
    {

        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
            Mock<IProductDal> productDalMock = new Mock<IProductDal>();
            Mock<IMapper> mapperMock = new Mock<IMapper>();
            ProductManager productManager = new ProductManager(productDalMock.Object, mapperMock.Object);
            productManager.Add(new Product());
        }
    }
}
