using GKU_App.DataBaseContext;
using GKU_App.Models;
using GKU_App.Models.Requests;
using GKU_App.Models.Responses;
using GKU_App.Services.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace GKU_App.Services
{
    public class AdminService:IAdminService
    {
        private AppDbContext context;
        public AdminService(AppDbContext context) 
        {
            this.context = context;
        }

        public AdminAuthResponse Auth(AdminAuthRequest request)
        {
            AddFirstAdmin();
            var response = new AdminAuthResponse() {Errors=new List<string>() };
            var admin = context.Admins.FirstOrDefault(a=>a.Login==request.Login);
            if (admin != null)
            {
                var passwordHash = Convert.ToBase64String(Pbkdf2(request.Password, Convert.FromBase64String(admin.Salt)));
                if (passwordHash != admin.PasswordHash)
                {
                    response.Errors.Add("Неверный пароль");
                }
                else 
                {
                    response.Key = passwordHash;
                    response.Login = request.Login;
                }
            }
            else 
            {
                response.Errors.Add("Неверный логин");
            }
            return response;
        }

        private void AddFirstAdmin() 
        {
            if (context.Admins.Count() == 0)
            {
                var salt = GetRandomBytes();
                context.Admins.Add(new Administrator
                {
                    Login = "Admin12345",
                    PasswordHash = Convert.ToBase64String(Pbkdf2("11111", salt)),
                    Salt = Convert.ToBase64String(salt)
                });
                context.SaveChanges();
            }
        }

        private byte[] GetRandomBytes(int size = 32)
        {
            var salt = new byte[size];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }
            return salt;
        }

        private byte[] Pbkdf2(string password, byte[] salt, int numBytes = 32)
        {
            return KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: numBytes
                );
        }
    }
}
