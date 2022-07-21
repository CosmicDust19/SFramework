using System.Collections.Generic;
using AutoMapper;
using SFramework.Core.Aspects.Postsharp.AuthorizationAspects;
using SFramework.Core.Aspects.Postsharp.CacheAspects;
using SFramework.Core.Aspects.Postsharp.TransactionAspects;
using SFramework.Northwind.Business.Abstract;
using SFramework.Northwind.Business.ValidationRules.FluentValidation;
using SFramework.Northwind.DataAccess.Abstract;
using SFramework.Northwind.Entities.Concrete;
using SFramework.Core.Aspects.Postsharp.ValidationAspects;
using SFramework.Core.CrossCuttingConcerns.Caching.Microsoft;

namespace SFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [CacheAspect(typeof(MemoryCacheManager), 20)]
        public List<Product> GetAll()
        {
            return _mapper.Map<List<Product>>(_productDal.GetList());
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidator), AspectPriority = 2)]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            // Business Code
            _productDal.Update(product2);
        }
    }
}