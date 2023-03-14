using LoginRoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginRoleApp.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserService _userService;
        public AuthenticationService(UserService userService)
        {
            _userService = userService;
        }

        public User AuthenticateUser(string username, string password)
        {
            var _users = _userService.GetUsers();
            var userData = _users.FirstOrDefault(u => u.Login.Equals(username)
                && u.Password.Equals(password));
            if (userData == null)
                throw new UnauthorizedAccessException("Access denied. Please provide some valid credentials.");

            return userData;
        }
        private string CalculateHash(string clearTextPassword, string salt)
        {
            // Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password
            return Convert.ToBase64String(hash);
        }
    }
}
