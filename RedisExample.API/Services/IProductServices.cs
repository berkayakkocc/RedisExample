using RedisExample.API.Models;

namespace RedisExample.API.Services
{
    public interface IProductServices
    {
        Task<List<Product>> GetAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
    }
}
