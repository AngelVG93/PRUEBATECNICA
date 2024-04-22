
namespace Core.Entities
{
    public class OrderProduct : BaseEntity
    {
        public DateTime DateOrder {  get; set; }    
        public int IdOrder {  get; set; }    
        public int IdProduct {  get; set; }
        public virtual Order? IdOrderNavigation { get; set; }
        public virtual Product? IdProductNavigation { get; set; }
    }
}
