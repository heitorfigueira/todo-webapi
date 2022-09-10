using ToDo.WebApi.Application.Contracts.Services;

namespace ToDo.WebApi.Tests.Unit.Setups.Services
{
    public static class HashServiceSetups
    {
        public static Mock<IHashService> MockVerifyLoginAuthCorrectPasswordReturnsTrue(string authPassword, string userPassword)
        {
            var mock = new Mock<IHashService>();
            mock.Setup(service =>
                    service.VerifyAgainstHashedPassword(authPassword, userPassword))
                    .Returns(true);

            return mock;
        }
    }
}
