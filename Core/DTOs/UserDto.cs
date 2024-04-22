using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class UserDto : BaseDto
    {
        public string ?Name { get; set; }
        public string ?LastName { get; set; }
        public string ?IdentityNumber { get; set; }
        public string ?Password { get; set; }
        public virtual ICollection<RoleUserDto>? RoleUser { get; set; }
        public virtual ICollection<UserOrderDto>? UserOrder { get; set; }
    }
}
