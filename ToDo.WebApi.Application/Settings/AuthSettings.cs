using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Framework.Settings;

namespace ToDo.WebApi.Application.Settings
{
    public class AuthSettings : Setting<AuthSettings>
    {
        public string Secret { get; set; }
    }
}
