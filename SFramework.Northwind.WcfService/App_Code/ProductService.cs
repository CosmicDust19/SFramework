
using System.Collections.Generic;
using SFramework.Northwind.Business.Abstract;
using SFramework.Northwind.Business.DependencyResolvers.Ninject;
using SFramework.Northwind.Entities.Concrete;

public class ProductService:IProductService
{

    private IProductService _productService = InstanceFactory.GetInstance<IProductService>();

    public ProductService()
    {

    }

    public List<Product> GetAll()
    {
        return _productService.GetAll();
    }

    public Product GetById(int id)
    {
        return _productService.GetById(id);
    }

    public Product Add(Product product)
    {
        return _productService.Add(product);
    }

    public Product Update(Product product)
    {
        return _productService.Update(product);
    }

    public void TransactionalOperation(Product product1, Product product2)
    {
        _productService.TransactionalOperation(product1, product2);
    }
}