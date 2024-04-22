using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class OrderProductDto : BaseDto
    {
        public DateTime DateOrder { get; set; }
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public virtual ProductDto? IdProductNavigation { get; set; }
    }
}
