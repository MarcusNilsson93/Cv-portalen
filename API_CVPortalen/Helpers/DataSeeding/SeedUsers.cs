using System;
using System.Collections.Generic;
using API_CVPortalen.Models;
using API_CVPortalen.Models.Auth;

namespace API_CVPortalen.Helpers.DataSeeding
{
    public class SeedUsers
    {
        private static string defaultPassword = "password123";
        public static IEnumerable<User> DefaultUsers(Programme[] programmes)
        {
            var users = new List<User>();
            
            for (int i = 1; i < 51; i++)
            {
                users.Add(generateUser(i));
            }
            var admin = generateAdmin(99999);
            users.Add(admin);
            foreach (var user in users)
            {
                var random  = new Random();
                user.ProgrammeId = programmes[random.Next(1, programmes.Length)].Id;
            }
            return users;
        }

        private static User generateUser(int id)
        {
            CreatePasswordHash(defaultPassword, out var hash, out var salt);
            return new User
            {
                Id = id, FirstName = $"name{id}", LastName = $"Lname{id}", Email = $"user{id}@iths.se",
                Role = Role.User, PasswordHash = hash, PasswordSalt = salt
            };

        }
        private static User generateAdmin(int id)
        {
            CreatePasswordHash(defaultPassword, out var hash, out var salt);
            return new User
            {
                Id = id, FirstName = $"admin", LastName = $"Lname{id}", Email = $"admin@iths.se",
                Role = Role.Admin, PasswordHash = hash, PasswordSalt = salt
            };

        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}