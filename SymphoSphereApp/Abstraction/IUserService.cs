using SymphoSphereApp.DTOs;
using SymphoSphereApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymphoSphereApp.Abstraction
{
    internal interface IUserService 
    {
        public Task<User> GetUserById(int id);

        public Task<User> GetUserByName(string Name);
        public Task Registrate(RegistrateDto user);

        public Task<User> GetUserWithSongs(int Id);

        public Task AddSongToUser(int Id,Song song);
        
    }
}
