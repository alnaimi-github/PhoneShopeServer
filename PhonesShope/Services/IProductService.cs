using PhoneShopeLibrary.Models;
using PhoneShopeLibrary.Responses;

namespace PhonesShope.Services
{
    public interface IProductService
    {
        Task<ServiceResponse>AddProduct(Product model);
        Task GetProducts(bool featuredProducts);
        List<Product> AllProducts { get; set;}
        Action? ProductAction { get; set; }
        List<Product>FeaturedProducts { get; set; }
    }
}
