using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Infrastructure.Contexts;
using WebApi.Framework.Data.Repositories.EntityFramework;

namespace ToDo.WebApi.Infrastructure.Repositories
{
    public class AccountRepository : EntityFrameworkRepositoryBase<Account, Guid>, IAccountRepository
    {
        private readonly ApplicationContext _context;

        public AccountRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Account> ListAll()
        {
            return _context.Accounts.ToList();
        }
    }
}
