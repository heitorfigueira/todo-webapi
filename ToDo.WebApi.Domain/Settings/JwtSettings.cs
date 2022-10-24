using WebApi.Framework.Settings;

namespace ToDo.WebApi.Domain.Settings
{
    public class JwtSettings : Setting<JwtSettings>
    {
        public string Secret { get; set; }
        public int ExpiryMinutes { get; set; }
        public string Issuer { get; set; }
    }
}
