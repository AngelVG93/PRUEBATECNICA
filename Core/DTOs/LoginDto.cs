using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class LoginDto
    {
        public string? userName { get; set; }
        public string? bearerToken { get; set; }
        public string? lastName { get; set; }
        public int idUser { get; set; }
    }
}
