using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Infrastructure.Contexts;
using WebApi.Framework.Data.Repositories.EntityFramework;

namespace ToDo.WebApi.Infrastructure.Repositories
{
    public class UserRepository : EntityFrameworkRepositoryBase<User, Guid>, IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public ErrorOr<User?> GetByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(user => user.Email == email);

            return user;
        }
    }
}
