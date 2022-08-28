using dotnet_rpg.Data.Interfaces;
using dotnet_rpg.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace dotnet_rpg.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<int> Register(User user, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            try
            {
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                new Exception("caca maca");
                
            }

           

            return user.Id;
        }

        public Task<string> Login(string username, string password)
        {
            return null;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(e => e.Username.ToLower() == username.ToLower())){
                return true;
            }
            return false;
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
