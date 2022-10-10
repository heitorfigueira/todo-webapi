using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Framework.Settings;

namespace ToDo.WebApi.Domain.Settings
{
    public class AuthSettings : Setting<AuthSettings>
    {
        public string Secret { get; set; }
        public string Salt { get; set; }
        public int DegreeOfParallelism { get; set; }
        public int Iterations { get; set; }
        public int MemorySize { get; set; }
    }
}
