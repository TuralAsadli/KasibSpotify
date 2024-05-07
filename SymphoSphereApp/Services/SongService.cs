using AutoMapper;
using SymphoSphereApp.Abstraction;
using SymphoSphereApp.DAL;
using SymphoSphereApp.DTOs;
using SymphoSphereApp.Entities;
using SymphoSphereApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymphoSphereApp.Services
{
    public class SongService : ISongService
    {
        ISongRepository _songs;

        public SongService()
        {
            AppDbContext appDbContext = new AppDbContext();
            _songs = new SongRepository(appDbContext);
        }
        public async Task<Song> GetSongById(int id)
        {
            return await _songs.FindAsyncById(id);
        }

        public async Task CreateSong(Song user)
        {
            await _songs.Create(user);
        }

        public async Task<IEnumerable<GetSongDto>> GetAll()
        {
            MapperConfiguration configMToDto = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Song, GetSongDto>()
                );

            Mapper mapper = new Mapper(configMToDto);

            IEnumerable<Song> songList = new List<Song>();
            songList = await _songs.GetAll();
            List<GetSongDto> song = new List<GetSongDto>();
            foreach (var item in songList)
            {
                var dto = mapper.Map<GetSongDto>(item);
                song.Add(dto);
            }
            return song;
        }
    }
}
