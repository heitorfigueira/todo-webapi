using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain.Enums;
using ToDo.WebApi.Interface.Controllers;
using ToDo.WebApi.Tests.Unit.Mocks;
using ToDo.WebApi.Tests.Unit.Mocks.Services;
using ToDo.WebApi.Tests.Unit.Setups.Services;


namespace ToDo.WebApi.Tests.Unit.Setups.Controllers
{
    public static class AccountControllerSetups
    {
        #region Create
        public static (AccountController controller, Account account) CreateOnSuccessReturnsAccount()
        {
            var account = AccountFakers.GenerateAccountType(AccountTypes.Common);

            return (CreateOnSuccessReturnsAccount(account), account);
        }

        public static AccountController CreateOnSuccessReturnsAccount(Account account)
        {
            var mockAccountService = AccountServiceMocks.Mock().SetupCreateReturnsAccount(account);

            return new(mockAccountService.Object);
        }

        public static AccountController CreateOnFailureReturnsCreationFailedError()
        {
            var mockAccountService = AccountServiceMocks.Mock().SetupCreateReturnsCreationFailedError();

            return new(mockAccountService.Object);
        }
        #endregion

        #region Delete
        public static AccountController DeleteOnSuccessReturnsAccount(Account account)
        {

            var mockAccountService = AccountServiceMocks.Mock().SetupDeleteReturnsAccount(account);

            return new(mockAccountService.Object);
        }

        public static (AccountController controller, Account account) DeleteOnSuccessReturnsAccount()
        {
            var account = AccountFakers.GenerateAccountType(AccountTypes.Common);

            return (DeleteOnSuccessReturnsAccount(account), account);
        }

        public static AccountController DeleteOnFailureReturnsDeletionFailedError()
        {
            var mockAccountService = AccountServiceMocks.Mock().SetupDeleteReturnsDeletionFailedError();

            return new(mockAccountService.Object);
        }
        #endregion

        #region Update
        public static AccountController UpdateOnSuccessReturnsAccount(Account account)
        {

            var mockAccountService = AccountServiceMocks.Mock().SetupUpdateReturnsAccount(account);

            return new(mockAccountService.Object);
        }

        public static (AccountController controller, Account account) UpdateOnSuccessReturnsAccount()
        {
            var account = AccountFakers.GenerateAccountType(AccountTypes.Common);

            return (UpdateOnSuccessReturnsAccount(account), account);
        }

        public static AccountController UpdateOnFailureReturnsUpdateFailedError()
        {
            var mockAccountService = AccountServiceMocks.Mock().SetupUpdateReturnsUpdateFailedError();

            return new(mockAccountService.Object);
        }
        #endregion

        #region Get
        public static AccountController GetOnSuccessReturnsAccount(Account account)
        {

            var mockAccountService = AccountServiceMocks.Mock().SetupGetValidIdReturnsAccount(account);

            return new(mockAccountService.Object);
        }

        public static (AccountController controller, Account account) GetOnSuccessReturnsAccount()
        {
            var account = AccountFakers.GenerateAccountType(AccountTypes.Common);

            return (GetOnSuccessReturnsAccount(account), account);
        }

        public static AccountController GetOnFailureReturnsNull()
        {
            var mockAccountService = AccountServiceMocks.Mock().SetupGetInvalidIdReturnsNull();

            return new(mockAccountService.Object);
        }
        #endregion
    }
}
