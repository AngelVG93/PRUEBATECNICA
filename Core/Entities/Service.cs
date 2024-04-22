namespace Core.Entities
{
    public class Service : BaseEntity
    {
        public string? NameService { get; set; }
        public virtual ICollection<RolesServices>? RolesServices { get; set; }
    }
}
