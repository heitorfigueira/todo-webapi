using LazyCache;
using WebApi.Framework.DataAccess.Caching;

namespace ToDo.WebApi.Application.Services
{
    public class MemoryCacheService : AbstractedLazyCaching
    {
        public MemoryCacheService(IAppCache cache) : base(cache)
        {
        }
    }
}
