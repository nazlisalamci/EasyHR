using Core.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<List<GetUserDto>> GetAll();
        Task AddUser(CreateUserDto user);
    }
}
