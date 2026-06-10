using DFS_Commerce.Models;

namespace DFS_Commerce.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts(string fileName);
    }
}
