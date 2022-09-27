using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Infrastructure.Contexts;
using WebApi.Framework.Caching;
using WebApi.Framework.DataAccess.Repositories.Cached;

namespace ToDo.WebApi.Infrastructure.Repositories
{
    public class AccountRepository : CachedEntityFrameworkRepositoryBase<Account, Guid>, IAccountRepository
    {
        private readonly ApplicationContext _context;

        public AccountRepository(ApplicationContext context, ICachingService cachingService) : base(context, cachingService)
        {
            _context = context;
        }

        public IEnumerable<Account> ListAll()
        {
            return _context.Accounts.ToList();
        }
    }
}
