using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class RoleUserDto : BaseDto
    {
        public int IdRole { get; set; }
        public int IdUser { get; set; }
        public virtual RoleDto? IdRoleNavigation { get; set; }
    }
}
