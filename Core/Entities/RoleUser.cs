
namespace Core.Entities
{
    public class RoleUser : BaseEntity
    {
        public int IdRole { get; set; }
        public int IdUser { get; set; }
        public virtual Role? IdRoleNavigation { get; set; }
        public virtual User? IdUserNavigation { get; set; }
    }
}
