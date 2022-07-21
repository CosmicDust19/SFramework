using SFramework.Core.Entities;

namespace SFramework.Northwind.Entities.Concrete
{
    public class Category:IEntity
    {
        public virtual int CategoryId { get; set; }
        public virtual string CategoryName { get; set; }
        
    }
}
