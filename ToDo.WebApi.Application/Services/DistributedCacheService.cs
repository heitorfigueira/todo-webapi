using LazyCache;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Framework.Caching;

namespace ToDo.WebApi.Application.Services
{
    public class DistributedCacheService : AbstractedRedisCaching
    {
        public DistributedCacheService(IConnectionMultiplexer connection, IConfiguration configuration) :
            base(connection, Int32.TryParse(configuration["RedisSettings:DatabaseId"], out int databaseId) ? databaseId : -1)
        {
        }
    }
}
