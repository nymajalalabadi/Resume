using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.User;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        #region Constructor

        private ResumeContext _context;

        public UserRepository(ResumeContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(id));
        }

        public async Task<bool> IsExistUserByEmail(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email.Equals(email));
        }

        public async Task<bool> DuplicatedEmail(int id, string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email && u.Id != id);
        }

        public async Task<bool> DuplicatedMobile(int id, string mobile)
        {
            return await _context.Users.AnyAsync(u => u.Mobile == mobile && u.Id != id);
        }

        public async Task<IQueryable<User>> GetAllUserDetails()
        {
            return _context.Users.AsQueryable();
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
