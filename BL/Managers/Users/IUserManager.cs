using BL.DTOs;
using BL.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Users
{
    public interface IUserManager
    {
       IEnumerable<UserDto> getAll();
        void delete(int id);
    }
}
