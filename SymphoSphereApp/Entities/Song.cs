using SymphoSphereApp.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymphoSphereApp.Entities
{
    public class Song : BaseItem
    {
        public TimeSpan Duration { get; set; }
        public string? Path { get; set; }
        public string? FilePath { get; set; }

        public bool Explicit { get; set; }

        public IEnumerable<User> Users { get; set; }

    }
}
