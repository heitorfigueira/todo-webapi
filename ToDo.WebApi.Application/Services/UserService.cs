using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Domain.Entities;
using WebApi.Framework.DependencyInjection;

namespace ToDo.WebApi.Application.Services
{
    public class UserService : ScopedService, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? Create(User request)
        {
            var id = _userRepository.Create(request);

            return _userRepository.Get(id);
        }

        public User? Delete(Guid id)
        {
            return _userRepository.Delete(id);
        }

        public User? Get(string username)
        {
            return _userRepository.GetByEmail(username);
        }
    }
}
