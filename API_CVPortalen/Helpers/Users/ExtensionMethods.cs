using System.Collections.Generic;
using System.Linq;

namespace API_CVPortalen.Helpers.Users
{
    public static class ExtensionMethods
    {
        public static IEnumerable<Models.User> WithoutPasswords(this IEnumerable<Models.User> users) 
        {
            if (users == null) return null;

            return Enumerable.Select(users, x => WithoutPassword(x));
        }

        public static Models.User WithoutPassword(this Models.User user) 
        {
            if (user == null) return null;

            user.PasswordHash = null;
            user.PasswordSalt = null;
            return user;
        }
    }
}