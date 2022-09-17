﻿using ErrorOr;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Infrastructure.Contexts;
using WebApi.Framework.Data.Repositories.EntityFramework;
using WebApi.Framework.DataAccess.Caching;

namespace ToDo.WebApi.Infrastructure.Repositories
{
    public class UserRepository : CachedEntityFrameworkRepositoryBase<User, Guid>, IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context, ICachingService cachingService) : base(context, cachingService)
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
