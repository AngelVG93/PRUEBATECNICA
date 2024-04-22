namespace Core.Entities
{
    public class RolesServices : BaseEntity
    {
        public int IdServices { get; set; }
        public int IdRoles { get; set; }
        public virtual Service? IdServiceNavigation { get; set; }
        public virtual Role? IdRoleNavigation { get; set; }
        public virtual ICollection<PermissRolesServices>? PermissRolesServices { get; set; }
    }
}
