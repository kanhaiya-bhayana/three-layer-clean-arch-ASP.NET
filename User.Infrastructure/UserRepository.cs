using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application;
using User.Domain;

namespace User.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userDbContext;

        public UserRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        

        public Userd AddUser(Userd userd)
        {
            _userDbContext.Userds.Add(userd);
            _userDbContext.SaveChanges();
            return userd;
        }

        public Userd? UpdateUser(Userd userd,int id)
        {
            var hero =  _userDbContext.Userds.Find(id);
            if (hero is null)
                return null;
            hero.Name = userd.Name;
            hero.Email = userd.Email;

            _userDbContext.SaveChanges();
            return hero;
        }

        public List<Userd>? DeleteUser(int id)
        {
            var hero = _userDbContext.Userds.Find(id);
            if (hero is null)
                return null;
            _userDbContext.Userds.Remove(hero);
            _userDbContext.SaveChanges();
            return _userDbContext.Userds.ToList();
        }
        public List<Userd> GetAllUsers()
        {
            return _userDbContext.Userds.ToList();
        }
    }
}
