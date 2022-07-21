using SFramework.Core.Entities;

namespace SFramework.Northwind.Entities.Concrete
{
    public class Role:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
