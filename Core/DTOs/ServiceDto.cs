using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ServiceDto : BaseDto
    {
        public string? NameService { get; set; }
        public virtual RoleDto? IdRoleNavigation { get; set; }
        public virtual UserDto? IdUserNavigation { get; set; }
    }
}
