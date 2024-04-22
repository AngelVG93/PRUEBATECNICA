
namespace Core.Entities
{
    public class PermissRolesServices : BaseEntity
    {
        public int IdPermissions { get; set; }
        public int IdRolesService { get; set; }
        public virtual Permissions? IdPermissionsNavigation { get; set; }
        public virtual RolesServices? IdRolesServicesNavigation { get; set; }
    }
}
