using SymphoSphereApp.Abstraction;
using SymphoSphereApp.DAL;
using SymphoSphereApp.DTOs;
using SymphoSphereApp.Entities;
using SymphoSphereApp.Repository;
using SymphoSphereApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymphoSphereApp.Services
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;

        public UserService()
        {
            AppDbContext appDbContext = new AppDbContext();
            userRepository = new UserRepository(appDbContext);
        }

        public async Task AddSongToUser(int Id,Song song)
        {
            var user = await GetUserWithSongs(Id);
            if (user.Songs != null)
            {
                List<Song> list = user.Songs.ToList();
                list.Add(song);
                user.Songs = list;
            }
            else
            {
                user.Songs = new List<Song>();
                user.Songs.ToList().Add(song);
            }
            
            await userRepository.Update(user);
        }

        public async Task<User> GetUserById(int id)
        {
            return await userRepository.FindAsyncById(id);
        }

        public async Task<User> GetUserByName(string Name)
        {
            return userRepository.GetByUsername(Name);
        }

        public async Task<User> GetUserWithSongs(int Id)
        {
            return await userRepository.FindAsyncById(Id, x => x.Songs);
        }

        public async Task Registrate(RegistrateDto user)
        {
            PasswordManager.HashPassword(user.Pass, out byte[] newPass, out byte[] saltPass);
            User newUser = new User();
            newUser.Name = user.Username;
            newUser.HashPassword = newPass;
            newUser.SaltPassword = saltPass;
            newUser.Email = user.Email;
            newUser.BirhDay = user.BirhDay;

            await userRepository.Create(newUser);
            
        }
    }
}
