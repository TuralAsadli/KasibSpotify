using SymphoSphereApp.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymphoSphereApp.Entities
{
    public class User : BaseItem
    {
        public byte[] HashPassword { get; set; }
        public byte[] SaltPassword { get; set; }

        public string Email { get; set; }
        public DateTime BirhDay { get; set; }

        public IEnumerable<Song> Songs { get; set; }
    }
}
