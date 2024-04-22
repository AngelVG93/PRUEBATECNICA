namespace Core.DTOs
{
    public class RoleDto : BaseDto
    {
        public string? Name { get; set; }
        public virtual ICollection<RolesServicesDto>? RolesServices { get; set; }
    }
}
