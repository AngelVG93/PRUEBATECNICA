namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string ?Name { get; set; }
        public string ?Descriptionapp { get; set; }
        public Double Price { get; set; }
        public int numberunits { get; set; }
        public virtual ICollection<OrderProduct>? OrderProduct { get; set; }

    }
}
