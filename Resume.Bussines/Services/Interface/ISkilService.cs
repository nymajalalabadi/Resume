using Resume.DAL.ViewModels.Skil;

namespace Resume.Bussines.Services.Interface
{
	public interface ISkilService
	{
		#region Methods

		Task<FilterSkilViewModel> FilterSkil(FilterSkilViewModel filter);

		Task<CreateSkilResult> CreateSkil(CreateSkilViewModel create);

		Task<EditSkilViewModel?> GetEditSkilById(int id);

		Task<EditSkilResult> EditSkil(EditSkilViewModel edit);

		Task<List<SkilViewModel>> GetAllSkilViewModel();

		#endregion
	}
}
