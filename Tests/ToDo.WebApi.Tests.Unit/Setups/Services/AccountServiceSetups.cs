
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Services;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain;
using ToDo.WebApi.Domain.Enums;
using ToDo.WebApi.Tests.Unit.Mocks;
using ToDo.WebApi.Tests.Unit.Mocks.Repositories;

namespace ToDo.WebApi.Tests.Unit.Setups.Services
{
    public static class AccountServiceSetups
    {

        #region Get
        public static (AccountService service, Account account) GetValidIdReturnsAccount()
        {

            var user = AccountFakers.GenerateAccountType(AccountTypes.Common);

            return (GetValidIdReturnsAccount(user), user);
        }
        public static AccountService GetValidIdReturnsAccount(Account account)
        {
            var mockRepository = AccountRepositoryMocks.Mock().SetupGetValidIdReturnsAccount(account);

            return new AccountService(mockRepository.Object, MapperMocks.Mock().Object);
        }
        public static AccountService GetInvalidIdReturnsNull()
        {
            var mockRepository = AccountRepositoryMocks.Mock().SetupGetInvalidIdReturnsNull();

            return new AccountService(mockRepository.Object, MapperMocks.Mock().Object);
        }
        #endregion

        #region Create
        public static AccountService CreateReturnsAccount(Account account)
        {
            var mockAccountRepository = AccountRepositoryMocks.Mock()
                                        .SetupCreateReturnsAccount(account);

            return new AccountService(mockAccountRepository.Object, MapperMocks.Mock().Object);
        }
        public static (AccountService service, Account account) CreateReturnsAccount()
        {
            var user = AccountFakers.GenerateAccountType(AccountTypes.Common);

            return (CreateReturnsAccount(user), user);
        }
        public static AccountService CreateReturnsCreationFailedError()
        {
            var mockAccountRepository = AccountRepositoryMocks.Mock()
                                        .SetupCreateReturnsNull();

            return new AccountService(mockAccountRepository.Object, MapperMocks.Mock().Object);
        }
        #endregion

        #region Delete
        public static AccountService DeleteReturnsDeletionFailedError()
        {

            var mockAccountRepository = AccountRepositoryMocks.Mock()
                                        .SetupDeleteReturnsNull();

            return new AccountService(mockAccountRepository.Object, MapperMocks.Mock().Object);
        }
        public static AccountService DeleteReturnsAccount(Account account)
        {
            var mockAccountRepository = AccountRepositoryMocks.Mock()
                                        .SetupDeleteReturnsAccount(account);

            return new AccountService(mockAccountRepository.Object, MapperMocks.Mock().Object);
        }
        public static (AccountService service, Account account) DeleteReturnsAccount()
        {
            var user = AccountFakers.GenerateAccountType(AccountTypes.Common);

            return (DeleteReturnsAccount(user), user);
        }
        #endregion

        #region Update
        public static AccountService UpdateReturnsAccount(Account account)
        {
            var mockAccountRepository = AccountRepositoryMocks.Mock()
                                        .SetupGetValidIdReturnsAccount(account)
                                        .SetupUpdateReturnsTrue(account);

            return new AccountService(mockAccountRepository.Object, MapperMocks.Mock().Object);
        }
        public static (AccountService service, Account account) UpdateReturnsAccount()
        {
            var user = AccountFakers.GenerateAccountType(AccountTypes.Common);

            return (UpdateReturnsAccount(user), user);
        }
        public static AccountService UpdateReturnsUpdateFailedError(Account account)
        {
            var mockAccountRepository = AccountRepositoryMocks.Mock()
                                        .SetupGetValidIdReturnsAccount(account)
                                        .SetupUpdateReturnsFalse();

            return new AccountService(mockAccountRepository.Object, MapperMocks.Mock().Object);
        }

        public static (AccountService service, Account account) UpdateReturnsUpdateFailedError()
        {
            var account = AccountFakers.GenerateAccountType(AccountTypes.Common);

            return (UpdateReturnsUpdateFailedError(account), account);
        }
        #endregion
    }
}
