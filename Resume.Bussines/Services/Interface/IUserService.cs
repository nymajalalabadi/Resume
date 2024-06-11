using Resume.DAL.Models.User;
using Resume.DAL.ViewModels.Account;
using Resume.DAL.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Interface
{
    public interface IUserService
    {
        #region Methods

        Task<FilterUserViewModel> FilterAsync(FilterUserViewModel model);

        Task<CreateUserResult> CreateUser(CreateUserViewModel model);

        Task<EditUserViewModel> GetForEditById(int id);

        Task<EditUserResult> EditUser(EditUserViewModel model);

        Task<LoginResult> Login(LoginViewModel model);

        Task<User?> GetUserByEmail(string email);

        #endregion
    }
}
