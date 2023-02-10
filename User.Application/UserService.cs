using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain;

namespace User.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<Userd> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return users;
        }
        public Userd AddUser(Userd userd)
        {
            _userRepository.AddUser(userd);
            return userd;
        }

        public Userd? UpdateUser(Userd userd,int id)
        {
            var u = _userRepository.UpdateUser(userd,id);
            if (u is null)
                return null;
            return u;
        }

        public List<Userd>? DeleteUser(int id)
        {
           var result =  _userRepository.DeleteUser(id);
            return result;
        }
    }
}
