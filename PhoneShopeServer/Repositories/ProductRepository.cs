using Microsoft.EntityFrameworkCore;
using PhoneShopeLibrary.Models;
using PhoneShopeLibrary.Responses;
using PhoneShopeServer.Data;

namespace PhoneShopeServer.Repositories
{
    public class ProductRepository(AppDbContext appDb) : IProduct
    {
        private readonly AppDbContext _AppDb = appDb;

        public async Task<ServiceResponse> AddProduct(Product model)
        {
            if (model is null) return new ServiceResponse(false, "Model is null");
            var (flag, message) = await CheckName(model.Name!);
            if (flag)
            {
                _AppDb.Products.Add(model);
                await Commit();
                return new ServiceResponse(true, "Product Saved");
            }
            return new ServiceResponse(flag, message);
        }

        public async Task<List<Product>> GetProducts(bool featuredProducts)
        {
            if (featuredProducts)
                return await _AppDb.Products.Where(p => p.Featured).ToListAsync();
            else
                return await _AppDb.Products.ToListAsync();
        }

        private async Task<ServiceResponse> CheckName(string name)
        {
            var product = await _AppDb.Products.FirstOrDefaultAsync(p => p.Name!.ToLower().Equals(name.ToLower()));
            return product is null ? new ServiceResponse(true, null!) : new ServiceResponse(false, "Product already exist.");
        }

        private async Task Commit() => await _AppDb.SaveChangesAsync();
    }
}
