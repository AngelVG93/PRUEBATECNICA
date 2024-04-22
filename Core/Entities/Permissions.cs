
namespace Core.Entities
{
    public class Permissions : BaseEntity
    {
        public string ?Name { get; set; }
        public virtual ICollection<PermissRolesServices>? PermissRolesServices { get; set; }
    }
}
