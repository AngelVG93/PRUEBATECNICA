using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class UserOrderDto : BaseDto 
    {
        public int IdUser { get; set; }
        public int IdOrder { get; set; }
        public DateTime DateOrder { get; set; }
        public virtual OrderDto? IdOrderNavigation { get; set; }
    }
}
