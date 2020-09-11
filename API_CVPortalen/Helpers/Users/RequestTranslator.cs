using API_CVPortalen.Models;
using API_CVPortalen.Models.Auth;

namespace API_CVPortalen.Helpers.Users
{
    public static class RequestTranslator
    {
        public static User ToUser(this Models.Auth.RegisterRequest request)
        {
            return new User {FirstName = request.FirstName, LastName = request.LastName, Email = request.Email};
        }
        public static User ToUser(this Models.Auth.UpdateRequest request)
        {
            return new User {FirstName = request.FirstName, LastName = request.LastName, Email = request.Email, ProgrammeId = request.ProgrammeId};
        }
    }
}