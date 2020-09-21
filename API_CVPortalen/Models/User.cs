using System.ComponentModel.DataAnnotations;
using API_CVPortalen.Helpers.Programmes;
using API_CVPortalen.Models.Auth;

namespace API_CVPortalen.Models
{
    public class User
    {
        public int Id { get; set; }
        public int ProgrammeId { get; set; } = ProgrammeBuilder.Empty.Id;
        public virtual Programme.Programme Programme { get; set; }
        [Required ]
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        
        public string LastName { get; set; }
        public string FirstName { get; set; }


        public string Role { get; set; } = Auth.Role.User;
        public string Token { get; set; }
    }
}