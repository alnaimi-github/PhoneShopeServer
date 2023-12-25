using PhonesShope.Services.StaticGlobal;
using PhoneShopeLibrary.Models;
using PhoneShopeLibrary.Responses;

namespace PhonesShope.Services
{
    public class ClientServices(HttpClient _http) : IProductService, ICategoryService
    {
        private const string ProductBaseUrl = "api/Product";
        private const string CategoryBaseUrl = "api/Category";

        public Action? CategoryAction { get; set; }
        public List<Category> AllCategories { get; set; }
        public List<Product> AllProducts { get; set; }
        public Action? ProductAction { get; set; }
        public List<Product> FeaturedProducts { get; set; }


        //Global Method  for All Read Response 

        private static ServiceResponse Check(HttpResponseMessage response) => response.IsSuccessStatusCode ?
                                                                  new ServiceResponse(true, null!) :
                                                                  new ServiceResponse(false, "Error occured. Try again later...");
        private static async Task<string> ReadContent(HttpResponseMessage response) => await response.Content.ReadAsStringAsync();

        //Products
        public async Task<ServiceResponse> AddProduct(Product model)
        {
            var response = await _http.PostAsync(ProductBaseUrl, General.GenerateStringContent(General.SerializeObj(model)));
            var result = Check(response);
            if (!result.Flag) return result;
            var ApiResponse = await ReadContent(response);
            var data = General.DesterilizeJsonString<ServiceResponse>(ApiResponse);
            if (!data.Flag) return data;
            await CleanedAndGetGetAllProducts();
            return data;

        }
        private async Task CleanedAndGetGetAllProducts()
        {
            bool featuredProduct = true;
            bool AlProducts = false;
            AllProducts = null!;
            FeaturedProducts = null!;
            await GetProducts(featuredProduct);
            await GetProducts(AlProducts);
        }

        public async Task GetProducts(bool featuredProducts)
        {
            if (featuredProducts && FeaturedProducts is null)
            {
                FeaturedProducts = await GetAllProducts(featuredProducts);
                ProductAction!.Invoke();
                return;
            }
            else
            {
                if (!featuredProducts && AllProducts is null)
                {
                    AllProducts = await GetAllProducts(featuredProducts);
                    ProductAction!.Invoke();
                    return;
                }
            }

        }

        private async Task<List<Product>> GetAllProducts(bool featuredProducts)
        {
            var response = await _http.GetAsync($"{ProductBaseUrl}?featured={featuredProducts}");
            var (flag, message) = Check(response);
            if (!flag) return null!;
            var result = await ReadContent(response);
            return General.DesterilizeJsonStringList<Product>(result).ToList();
        }

        //Categories
        public async Task<ServiceResponse> AddCategory(Category model)
        {
            var response = await _http.PostAsync(CategoryBaseUrl, General.GenerateStringContent(General.SerializeObj(model)));
            var result = Check(response);
            if (!result.Flag) return result;

            var ApiResponse = await ReadContent(response);
            var data = General.DesterilizeJsonString<ServiceResponse>(ApiResponse);

            if (!data.Flag)
            {
                return data;
            }
            else
            {
                await CleanedAndGetGetAllCategories();
                return data;
            }
        }


        public async Task GetAllCategories()
        {
            if (AllCategories is null)
            {
                var response = await _http.GetAsync(CategoryBaseUrl);
                var (flag, message) = Check(response);
                if (!flag) return;
                var result = await ReadContent(response);
                await CleanedAndGetGetAllCategories();
                AllCategories = General.DesterilizeJsonStringList<Category>(result).ToList();
                CategoryAction!.Invoke();
            }
        }
        private async Task CleanedAndGetGetAllCategories()
        {
            AllCategories = null!;
            await GetAllCategories();
        }
    }
}
