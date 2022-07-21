using System.Collections.Generic;
using System.ServiceModel;
using SFramework.Northwind.Entities.Concrete;

namespace SFramework.Northwind.Business.Abstract
{
    [ServiceContract]
    public interface IProductService
    {

        [OperationContract]
        List<Product> GetAll();

        [OperationContract]
        Product GetById(int id);

        [OperationContract]
        Product Add(Product product);

        [OperationContract]
        Product Update(Product product);

        [OperationContract]
        void TransactionalOperation(Product product1, Product product2);
    }
}
