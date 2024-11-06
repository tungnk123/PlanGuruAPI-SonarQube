using Application.Common.Interface.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PlanGuruDBContext _context;

        public UserRepository(PlanGuruDBContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteAsync(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if(user == null)
            {
                throw new Exception("Can't find this user");
            }
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            var user = _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }

        public async Task<User?> GetByIdAsync(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            return user;
        }

        public async Task<User?> Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(p => p.Email == email && p.Password == password);
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
