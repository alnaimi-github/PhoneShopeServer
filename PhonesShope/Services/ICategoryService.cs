using PhoneShopeLibrary.Models;
using PhoneShopeLibrary.Responses;

namespace PhonesShope.Services
{
    public interface ICategoryService
    {
        Task<ServiceResponse> AddCategory(Category model);
        Action? CategoryAction { get; set; }
        Task GetAllCategories();
        List<Category> AllCategories { get; set;}
    }
}
