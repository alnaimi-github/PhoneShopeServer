using PhoneShopeLibrary.Models;
using PhoneShopeLibrary.Responses;

namespace PhoneShopeServer.Repositories
{
    public interface ICategory
    {
        Task<List<Category>> GetAllCategories();
        Task<ServiceResponse> AddCategory(Category model);
    }
}
