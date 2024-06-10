using Microsoft.EntityFrameworkCore;
using Resume.Bussines.Security;
using Resume.Bussines.Services.Interface;
using Resume.DAL.Models.User;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Implementation
{
    public class UserService : IUserService
    {
        #region Constructor

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region Methods

        public async Task<FilterUserViewModel> FilterAsync(FilterUserViewModel model)
        {
            var query = await _userRepository.GetAllUserDetails();

            #region filter

            if (!string.IsNullOrEmpty(model.Email))
            {
                query = query.Where(u => u.Email == model.Email);
            }

            if (!string.IsNullOrEmpty(model.Mobile))
            {
                query = query.Where(u => u.Mobile == model.Mobile);
            }

            #endregion

            #region Paging

           await model.Paging(query.Select(user => new UserDetailsViewModel()
            {
                CreateDate = user.CreateDate,
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                IsActive = user.IsActive,
                LastName = user.LastName,
                Mobile = user.Mobile
            }));

            #endregion

            return model;
        }

        public async Task<CreateUserResult> CreateUser(CreateUserViewModel model)
        {
            if (await _userRepository.IsExistUserByEmail(model.Email.ToLower().Trim()))
            {
                return CreateUserResult.EmailExists;
            }

            var newUser = new User()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.Mobile,
                Password = PasswordHelper.EncodePasswordMd5(model.Password),
            };

            await _userRepository.AddUser(newUser);
            await _userRepository.SaveChanges();

            return CreateUserResult.Success;
        }

        public async Task<EditUserViewModel> GetForEditById(int id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null) 
            {
                return null;
            }

            return new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Mobile = user.Mobile,
                IsActive = user.IsActive,
            };
        }

        public async Task<EditUserResult> EditUser(EditUserViewModel model)
        {
            var user = await _userRepository.GetUserById(model.Id);

            if (user == null)
            {
                return EditUserResult.UserNotFound;
            }

            if (await _userRepository.DuplicatedEmail(model.Id, model.Email.ToLower().Trim())) 
            { 
                return EditUserResult.EmailDuplicated;
            }

            if (await _userRepository.DuplicatedEmail(model.Id, model.Mobile.ToLower().Trim()))
            {
                return EditUserResult.MobileDuplicated;
            }

            user.Email = model.Email;
            user.Mobile = model.Mobile;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.IsActive = model.IsActive;

            _userRepository.UpdateUser(user);
            await _userRepository.SaveChanges();

            return EditUserResult.Success;
        }

        #endregion
    }
}
