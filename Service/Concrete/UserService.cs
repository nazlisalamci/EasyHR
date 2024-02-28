using AutoMapper;
using Business.Abstract;
using Core.Dto.User;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddUser(CreateUserDto dto)
        {
            try {
                var user = _mapper.Map<User>(dto);
                _repository.Add(user);
                await _repository.SaveChanges();
            }catch(Exception ex)
            {
                await _repository.Dispose();
                throw;
            }
          
        }

        public async Task<List<GetUserDto>> GetAll()
        {
            try {
                var users = _repository.GetAllAsync().GetAwaiter().GetResult().ToList();
                var getUserDto = _mapper.Map<List<GetUserDto>>(users);
                return getUserDto;
            }catch(Exception ex)
            {
                throw;
            }
     
        }
    }
}
