using SymphoSphereApp.DTOs;
using SymphoSphereApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymphoSphereApp.Abstraction
{
    internal interface ISongService
    {
        public Task<Song> GetSongById(int id);


        public Task CreateSong(Song user);

        public Task<IEnumerable<GetSongDto>> GetAll();
    }
}
