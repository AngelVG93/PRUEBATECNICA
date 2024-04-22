using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class LogException : BaseEntity
    {
        public string ?Name { get; set; }
        public string ?Message { get; set; }
        public DateTime DateTimeException { get; set; }
    }
}
