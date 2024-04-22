using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Login
    {
        public string? userName { get; set; }
        public string? bearerToken { get; set; }
        public string? lastName { get; set; }
        public int idUser { get; set; }
    }
}
