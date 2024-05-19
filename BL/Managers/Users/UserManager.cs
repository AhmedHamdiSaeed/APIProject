using BL.DTOs;
using BL.DTOs.Users;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Users
{
    public class UserManager : IUserManager
    {
        private IUnitOfWork _unitOfWork;
        public UserManager(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> getAll()
        {
            return _unitOfWork.UserRepo.getAll().Select(u => new UserDto(u.UserName,u.ImageUrl,u.Email));
        }
    }
}
