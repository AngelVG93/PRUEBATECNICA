namespace Core.Entities
{
    public class Role : BaseEntity
    {
        public string ?Name { get; set; }
        public virtual ICollection<RoleUser>? RoleUser { get; set; }
        public virtual ICollection<RolesServices>? RolesServices { get; set; }
    }
}
