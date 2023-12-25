using Microsoft.EntityFrameworkCore;
using PhoneShopeLibrary.Models;
using PhoneShopeLibrary.Responses;
using PhoneShopeServer.Data;

namespace PhoneShopeServer.Repositories
{
    public class CategoryRepository(AppDbContext appDb) : ICategory
    {
        private readonly AppDbContext _AppDb = appDb;

        public async Task<ServiceResponse> AddCategory(Category model)
        {
            if (model is null) return new ServiceResponse(false, "Model is null");
            var (flag, message) = await CheckName(model.Name!);
            if (flag)
            {
                _AppDb.Categories.Add(model);
                await Commit();
                return new ServiceResponse(true, "Category Saved");
            }
            return new ServiceResponse(flag, message);
        }
        public async Task<List<Category>> GetAllCategories() => await _AppDb.Categories.ToListAsync();

        private async Task<ServiceResponse> CheckName(string name)
        {
            var category = await _AppDb.Categories.FirstOrDefaultAsync(p => p.Name!.ToLower().Equals(name.ToLower()));
            return category is null ? new ServiceResponse(true, null!) : new ServiceResponse(false, "Category already exist.");
        }

        private async Task Commit() => await _AppDb.SaveChangesAsync();
    }
}
