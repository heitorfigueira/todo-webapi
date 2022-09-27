
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Services;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Tests.Unit.Mocks.Repositories;

namespace ToDo.WebApi.Tests.Unit.Setups.Services
{
    public static class UserServiceSetups
    {

        #region Get

        public static (UserService service, User user) GetValidEmailReturnsUser()
        {

            var user = UserFakers.GenerateSingleUser();

            return (GetValidEmailReturnsUser(user), user);
        }

        public static UserService GetValidEmailReturnsUser(User user)
        {
            var mockRepository = UserRepositoryMocks.Mock().SetupGetValidEmailReturnsUser(user);

            return new UserService(mockRepository.Object);
        }

        public static UserService GetInvalidEmailReturnsNull()
        {
            var mockRepository = UserRepositoryMocks.Mock().SetupGetInvalidEmailReturnsNull();

            return new UserService(mockRepository.Object);
        }
        #endregion

        #region Create

        public static UserService CreateReturnsUser(User user)
        {
            var mockUserRepository = UserRepositoryMocks.Mock()
                                        .SetupCreateReturnsUser(user);

            return new UserService(mockUserRepository.Object);
        }

        public static (UserService service, User user) CreateReturnsUser()
        {
            var user = UserFakers.GenerateSingleUser();

            return (CreateReturnsUser(user), user);
        }


        public static UserService CreateReturnsCreationFailedError()
        {
            var mockUserRepository = UserRepositoryMocks.Mock()
                                        .SetupCreateReturnsNull();

            return new UserService(mockUserRepository.Object);
        }
        #endregion

        #region Delete
        public static UserService DeleteReturnsDeletionFailedError()
        {

            var mockUserRepository = UserRepositoryMocks.Mock()
                                        .SetupDeleteReturnsNull();

            return new UserService(mockUserRepository.Object);
        }

        public static UserService DeleteReturnsUser(User user)
        {
            var mockUserRepository = UserRepositoryMocks.Mock()
                                        .SetupDeleteReturnsUser(user);

            return new UserService(mockUserRepository.Object);
        }

        public static (UserService service, User user) DeleteReturnsUser()
        {
            var user = UserFakers.GenerateSingleUser();

            return (DeleteReturnsUser(user), user);
        }
        #endregion
    }
}
