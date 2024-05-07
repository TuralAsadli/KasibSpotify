using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymphoSphereApp.DTOs
{
    public class RegistrateDto
    {
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public DateTime BirhDay { get; set; }
    }
}
