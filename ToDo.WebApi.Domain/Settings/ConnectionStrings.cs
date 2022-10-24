using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Framework.Settings;

namespace ToDo.WebApi.Domain.Settings
{
    public class ConnectionStrings : Setting<ConnectionStrings>
    {
        public string DefaultDatabaseConnection { get; set; }
    }
}
