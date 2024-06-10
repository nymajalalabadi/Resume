using Resume.DAL.Models.User;
using Resume.DAL.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface IUserRepository
    {
        #region Methods

        Task<User?> GetUserById(int id);

        Task<User?> GetUserByEmail(string email);

        Task<bool> IsExistUserByEmail(string email);

        Task<bool> DuplicatedEmail(int id, string email);

        Task<bool> DuplicatedMobile(int id, string mobile);

        Task<IQueryable<User>> GetAllUserDetails();

        Task AddUser(User user);

        void UpdateUser(User user);

        Task SaveChanges();

        #endregion
    }
}
