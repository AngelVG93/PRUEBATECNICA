
namespace Core.DTOs
{
    public class PermissRolesServicesDto : BaseDto
    {
        public int IdPermissions { get; set; }
        public int IdRolesService { get; set; }
        public virtual PermissionsDto? IdPermissionsNavigation { get; set; }
    }
}
