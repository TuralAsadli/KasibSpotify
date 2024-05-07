using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymphoSphereApp.DTOs
{
    public class GetSongDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string? Path { get; set; }

        public bool Explicit { get; set; }
    }
}
