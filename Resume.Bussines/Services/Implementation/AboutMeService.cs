using Resume.Bussines.Generators;
using Resume.Bussines.Services.Interface;
using Resume.Bussines.Tools;
using Resume.DAL.Models.AboutMe;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.AboutMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Implementation
{
    public class AboutMeService : IAboutMeService
    {
        #region Constructor

        private readonly IAboutMeRepository _aboutMeRepository;

        public AboutMeService(IAboutMeRepository aboutMeRepository)
        {
            _aboutMeRepository = aboutMeRepository;
        }

        #endregion

        #region Methods

        public async Task<CreateOrEditAboutMeViewModel> FillCreateOrEditAboutMe()
        {
            var aboutMe = await _aboutMeRepository.GetAboutMe();

            if (aboutMe == null)
            {
                return new CreateOrEditAboutMeViewModel()
                {
                    Id = 0,
                };
            }

            return new CreateOrEditAboutMeViewModel()
            {
                Id = aboutMe.Id,
                BirthDate = aboutMe.BirthDate,
                FirstName = aboutMe.FirstName,
                LastName = aboutMe.LastName,
                Email = aboutMe.Email,
                Location = aboutMe.Location,
                Bio = aboutMe.Bio,
                Mobile = aboutMe.Mobile,
                Position = aboutMe.Position,
                ImageName = aboutMe.ImageName
            };
        }

        public async Task<bool> CreateOrEditAboutMe(CreateOrEditAboutMeViewModel createOrEditAboutMe)
        {
            if (createOrEditAboutMe.Id == 0)
            {
                if (createOrEditAboutMe.Avatar != null)
                {
                    var imageNameAvatar = Guid.NewGuid().ToString("N") + Path.GetExtension(createOrEditAboutMe.Avatar.FileName);

                    createOrEditAboutMe.Avatar.AddImageToServer(imageNameAvatar, SiteTools.AboutMeAvatar);

                    var aboutMeAvatar = new AboutMe()
                    {
                        FirstName = createOrEditAboutMe.FirstName,
                        LastName = createOrEditAboutMe.LastName,
                        Email = createOrEditAboutMe.Email,
                        Location = createOrEditAboutMe.Location,
                        Bio = createOrEditAboutMe.Bio,
                        Mobile = createOrEditAboutMe.Mobile,
                        Position = createOrEditAboutMe.Position,
                        BirthDate = createOrEditAboutMe.BirthDate,
                        ImageName = imageNameAvatar
                    };

                    await _aboutMeRepository.CreateAboutMe(aboutMeAvatar);
                    await _aboutMeRepository.SaveChanges();

                    return true;
                }


                var aboutMe = new AboutMe()
                {
                    FirstName = createOrEditAboutMe.FirstName,
                    LastName= createOrEditAboutMe.LastName,
                    Email = createOrEditAboutMe.Email,
                    Location = createOrEditAboutMe.Location,
                    Bio= createOrEditAboutMe.Bio,
                    Mobile = createOrEditAboutMe.Mobile,
                    Position = createOrEditAboutMe.Position,
                    BirthDate= createOrEditAboutMe.BirthDate,
                };

                await _aboutMeRepository.CreateAboutMe(aboutMe);
                await _aboutMeRepository.SaveChanges();

                return true;
            }

            var currentAboutMe = await _aboutMeRepository.GetAboutMe();

            currentAboutMe!.FirstName = createOrEditAboutMe.FirstName;
            currentAboutMe.LastName = createOrEditAboutMe.LastName;
            currentAboutMe.Email = createOrEditAboutMe.Email;
            currentAboutMe.Mobile = createOrEditAboutMe.Mobile;
            currentAboutMe.Position = createOrEditAboutMe.Position;
            currentAboutMe.BirthDate = createOrEditAboutMe.BirthDate;
            currentAboutMe.Location = createOrEditAboutMe.Location;
            currentAboutMe.Bio = createOrEditAboutMe.Bio;

            if (createOrEditAboutMe.Avatar != null)
            {
                string imageName = Guid.NewGuid() + Path.GetExtension(createOrEditAboutMe.Avatar.FileName);
                createOrEditAboutMe.Avatar.AddImageToServer(imageName, SiteTools.AboutMeAvatar);

                currentAboutMe.ImageName = imageName;
            }

            _aboutMeRepository.UpdateAboutMe(currentAboutMe);
            await _aboutMeRepository.SaveChanges();

            return true;
        }

        public async Task<ClientSideEditAboutMeViewModel> GetAboutMeForShowing()
        {
            var aboutMe = await _aboutMeRepository.GetAboutMe();

            if (aboutMe == null) 
            {
                return null;
            }

            return new ClientSideEditAboutMeViewModel()
            {
                Id = aboutMe.Id,
                BirthDate = aboutMe.BirthDate,
                FirstName = aboutMe.FirstName,
                LastName = aboutMe.LastName,
                Email = aboutMe.Email,
                Location = aboutMe.Location,
                Bio = aboutMe.Bio,
                Mobile = aboutMe.Mobile,
                Position = aboutMe.Position,
                ImageName = aboutMe.ImageName!
            };
        }

        #endregion
    }
}
