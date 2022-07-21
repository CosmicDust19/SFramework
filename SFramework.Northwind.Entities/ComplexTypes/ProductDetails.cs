using SFramework.Core.Entities;

namespace SFramework.Northwind.Entities.ComplexTypes
{
    public class ProductDetails:IEntity
    {
        public virtual int ProductId { get; set; }

        public virtual string ProductName { get; set; }

        public virtual string CategoryName { get; set; }
    }
}
