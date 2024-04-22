using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class RolesServicesDto
    {
        public int IdServices { get; set; }
        public int IdRoles { get; set; }
        public virtual ServiceDto? IdServiceNavigation { get; set; }
        public virtual ICollection<PermissRolesServicesDto>? PermissRolesServices { get; set; }
    }
}
