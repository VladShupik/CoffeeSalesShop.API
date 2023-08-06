using CoffeeSalesShop.API.Data.Models;

namespace CoffeeSalesShop.API.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProduct(int id);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}
