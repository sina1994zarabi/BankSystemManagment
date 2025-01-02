using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Entities;
using App.Domain.Services.Service;
using App.Infra.Db;
using App.Infra.EfCore.Repositories;

namespace App.Domain.Services.AppService
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;

        public UserAppService()
        {
            _userService = new UserService();
        }

        public Card GetUserCard(int id)
        {
            return _userService.GetById(id).Cards.SingleOrDefault();
        }

        public User GetCurrentUser()
        {
            return _userService.GetById(InMemoryDb.CurrentUser.Id);
        }

        public AuthenticationResult Login(string username, string password)
        {
            var user = _userService.GetByUsername(username);
            if (user != null)
            {
                if (user.Password == password)
                {
                    if (user.IsLocked)
                    {
                        if (user.LockTime.Value.AddMinutes(15) < DateTime.Now)
                        {
                            user.LockTime = DateTime.MinValue;
                            user.FailedLoginAttempts = 0;
                            _userService.Save();
                            return new AuthenticationResult(true, "Successfully logged In", currentuser: user);
                        }
                        return new AuthenticationResult(false, $"You Are Temporarilly Locked." +
                            $"Try Logging In Again After {15 - DateTime.Now.Subtract(user.LockTime.Value).TotalMinutes} minutes ");
                    }
                    else return new AuthenticationResult(true, "Successfully logged In", currentuser: user);
                }
                else
                {
                    user.FailedLoginAttempts++;
                    _userService.Save();
                    if (user.FailedLoginAttempts == 3)
                    {
                        user.IsLocked = true;
                        user.LockTime = DateTime.Now;
                        _userService.Save();
                        return new AuthenticationResult(false, "Try Logging In Again After 15 minutes");
                    }
                    return new AuthenticationResult(false, "Incorrect Password");
                }
            }
            else return new AuthenticationResult(false, "User Not Found");
        }
    }
}


// Seperate App Service For Each Entity