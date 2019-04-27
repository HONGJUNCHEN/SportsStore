using StevenChen.SportStore.Domain.Concrete;
using StevenChen.SportStore.WebApp.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace StevenChen.SportStore.WebApp.Infrastructure.Concrete
{
    public class DbAuthProvider : IAuthProvider
    {
        private EFDbContext _dbContext;
        public DbAuthProvider(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Authenticate(string username, string password)
        {
            var loginUser = _dbContext.LoginUsers.FirstOrDefault(i => i.Username == username);
            if(loginUser==null)
            {
                return false;
            }

            if(loginUser.Password.Equals(password,StringComparison.Ordinal))
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return true;
            }
            return false;
        }
    }
}