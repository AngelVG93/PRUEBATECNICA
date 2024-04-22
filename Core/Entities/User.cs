
namespace Core.Entities
{
    public class User : BaseEntity
    {
        public string ?Name { get; set; }
        public string ?LastName { get; set; }
        public string ?IdentityNumber { get; set; }
        public string ?Password { get; set; }
        public virtual ICollection<RoleUser>? RoleUser { get; set; }
        public virtual ICollection<UserOrder>? UserOrder { get; set; }
    }
}
