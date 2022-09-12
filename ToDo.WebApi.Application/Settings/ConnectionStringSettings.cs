using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Framework.Settings;

namespace ToDo.WebApi.Application.Settings
{
    public class ConnectionStringSettings : Setting<ConnectionStringSettings>
    {
        public string DefaultDatabaseConnection { get; set; }
    }
}
