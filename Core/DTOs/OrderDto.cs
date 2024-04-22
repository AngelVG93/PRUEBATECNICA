using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class OrderDto : BaseDto
    {
        public string ?Description { get; set; }
        public virtual ICollection<OrderProductDto>? OrderProduct { get; set; }
    }
}
