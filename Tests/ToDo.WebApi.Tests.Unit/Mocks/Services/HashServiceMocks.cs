using AutoFixture;
using ToDo.WebApi.Application.Contracts.Services;

namespace ToDo.WebApi.Tests.Unit.Mocks.Services
{
    public static class HashServiceMocks
    {
        public static Mock<IHashService> Mock()
        {
            return new Mock<IHashService>();
        }

        #region Verify
        public static Mock<IHashService> SetupVerifyLoginAuthCorrectPasswordReturnsTrue(this Mock<IHashService> mock, string authPassword, string userPassword)
        {
            mock.Setup(service =>
                    service.VerifyAgainstHashedPassword(It.IsAny<Guid>(), authPassword, userPassword))
                    .Returns(true);

            return mock;
        }
        public static Mock<IHashService> SetupVerifyLoginAuthIncorrectPasswordReturnsFalse(this Mock<IHashService> mock, string authPassword, string userPassword)
        {
            mock.Setup(service =>
                    service.VerifyAgainstHashedPassword(It.IsAny<Guid>(), authPassword, userPassword))
                    .Returns(false);

            return mock;
        }
        #endregion

        #region Hash Password
        public static Mock<IHashService> SetupHashPasswordReturnsHashedPassword(this Mock<IHashService> mock, string hashedPassword)
        {
            mock.Setup(service =>
                    service.HashPassword(It.IsAny<Guid>(), It.IsAny<string>()))
                    .Returns(hashedPassword);

            return mock;
        }
        #endregion
    }
}
