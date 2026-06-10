using DFS_Commerce.Models;
using Newtonsoft.Json;

namespace DFS_Commerce.Services
{
    public class ProductService : IProductService
    {
        public async Task<List<Product>> GetProducts(string fileName)
        {
            var productsJson = await File.ReadAllTextAsync(fileName);
            return JsonConvert.DeserializeObject<List<Product>>(productsJson);
        }
    }
}
