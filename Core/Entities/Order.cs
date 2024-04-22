using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Order: BaseEntity
    {
        public string ?Description { get; set; } 
        public virtual ICollection<UserOrder>? UserOrder { get; set; }
        public virtual ICollection<OrderProduct>? OrderProduct { get; set; }
    }
}
