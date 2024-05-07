using SymphoSphereApp.Abstraction;
using SymphoSphereApp.DAL;
using SymphoSphereApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymphoSphereApp.Repository
{
    internal class SongRepository : BaseRepository<Song>, ISongRepository
    {
        public SongRepository(AppDbContext context) : base(context)
        {
        }
    }
}
