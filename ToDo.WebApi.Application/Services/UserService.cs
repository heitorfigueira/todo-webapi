using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain;
using WebApi.Framework.DependencyInjection;

namespace ToDo.WebApi.Application.Services
{
    public class UserService : TransientService, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ErrorOr<User> Create(User request)
        {
            var user = _userRepository.Create(request);

            if (user is null)
                return Errors.Repository.CreationFailed;

            return user;
        }

        public ErrorOr<User> Delete(Guid id)
        {
            var user = _userRepository.Delete(id);

            if (user is null)
                return Errors.Repository.DeletionFailed;

            return user;
        }

        public ErrorOr<User?> Get(string email)
        {
            var user = _userRepository.GetByEmail(email);

            return user;
        }

        public ErrorOr<User?> Get(Guid id)
        {
            var user = _userRepository.Get(id);

            return user;
        }
    }
}
