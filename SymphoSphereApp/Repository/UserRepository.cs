using SymphoSphereApp.Abstraction;
using SymphoSphereApp.DAL;
using SymphoSphereApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SymphoSphereApp.Repository
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        AppDbContext _appContext;
        public UserRepository(AppDbContext context) : base(context)
        {
            this._appContext = context;
        }

        public User GetByUsername(string Name)
        {
            return _appContext.Users.FirstOrDefault(x => x.Name == Name);
        }
    }
}
