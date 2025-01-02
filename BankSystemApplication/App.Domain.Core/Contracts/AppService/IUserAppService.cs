using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IUserAppService
    {
        AuthenticationResult Login(string userName, string password);
        Card GetUserCard(int id);
        User GetCurrentUser();

	}
}
