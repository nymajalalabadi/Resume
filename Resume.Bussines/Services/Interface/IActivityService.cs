﻿using Resume.DAL.Models.Activity;
using Resume.DAL.ViewModels.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Interface
{
    public interface IActivityService
    {
        #region Methods

        Task<FilterActivityViewModel> filterActivityViewModel(FilterActivityViewModel filter);

        Task<EditActivityViewModel?> GetActivityById(int id);

        Task<CreateActivityResult> CreateActivity(CreateActivityViewModel create);

        Task<EditActivityResult> EditActivity(EditActivityViewModel edit);

        Task<List<ActivityDetailsViewModel>> GetAllActivities();

        #endregion
    }
}
