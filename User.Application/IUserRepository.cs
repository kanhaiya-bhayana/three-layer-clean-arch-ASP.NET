using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain;

namespace User.Application
{
    public interface IUserRepository
    {
        List<Userd> GetAllUsers();
        Userd AddUser(Userd user);
        Userd? UpdateUser(Userd user,int id);
        List<Userd>? DeleteUser(int id);
    }
}
