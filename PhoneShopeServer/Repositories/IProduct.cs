using PhoneShopeLibrary.Models;
using PhoneShopeLibrary.Responses;

namespace PhoneShopeServer.Repositories
{
    public interface IProduct
    {
        Task<ServiceResponse>AddProduct(Product model);
        Task<List<Product>> GetProducts(bool featuredProducts);
    }
}
