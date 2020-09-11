using System.Collections.Generic;
using System.Linq;
using API_CVPortalen.Models;

namespace API_CVPortalen.Helpers.Users
{
    public static class UserResponse
    {
        public static IEnumerable<object> ToSafeResponse(this IEnumerable<User> users)
        {
            return users?.Select(x => x.ToSafeResponse());
        }
        public static object ToSafeResponse(this User user)
        {
            return new { user.Id, user.FirstName, user.LastName, user.Email, user.Role, user.ProgrammeId};
        }
        public static object ToAuthResponse(this User user)
        {
            return new { user.Id, user.FirstName, user.LastName, user.Email, user.Role, user.ProgrammeId, user.Token};
        }
    }
}