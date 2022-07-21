using SFramework.Core.Entities;

namespace SFramework.Northwind.Entities.Concrete
{
    public class UserRole:IEntity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }
}
