using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserOrder : BaseEntity
    {
        public int IdUser { get; set; }
        public int IdOrder { get; set; }
        public DateTime DateOrder { get; set; }
        public virtual User? IdUserNavigation { get; set; }
        public virtual Order? IdOrderNavigation { get; set; }
    }
}
