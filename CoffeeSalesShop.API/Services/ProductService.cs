using CoffeeSalesShop.API.Data;
using CoffeeSalesShop.API.Data.Models;
using CoffeeSalesShop.API.Interfaces;
using CoffeeSalesShop.API.Resources;
using Dapper;
using Microsoft.Extensions.Localization;
using System.Data;

namespace CoffeeSalesShop.API.Services
{
    public class ProductService : IProductService
    {
        private readonly CoffeeSalesShopContext _context;
        private readonly IStringLocalizer<ErrorMessages> _localizer;

        public ProductService(CoffeeSalesShopContext context, IStringLocalizer<ErrorMessages> localizer)
        {
            _context = context;
            _localizer = localizer;
        }

        public async Task<Product> GetProduct(int id)
        {
            var sqlQuery = "SELECT [Id], [Code], [Name], [Description], [QuantityLeft], [Price] " +
                    "FROM [dbo].[Product] " +
                    "WHERE [Id] = @id";

            using var connection = _context.CreateConnection();
            var product = await connection.QueryFirstOrDefaultAsync<Product>(sqlQuery, new { Id = id });

            return product ?? throw new Exception(_localizer["ProductNotFound"]);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var sqlQuery = "SELECT [Id], [Code], [Name], [Description], [QuantityLeft], [Price] FROM [dbo].[Product]";

            using var connection = _context.CreateConnection();
            var products = await connection.QueryAsync<Product>(sqlQuery);

            return products;
        }

        public async Task<Product> AddProduct(Product product)
        {
            await ValidateProduct(product);

            string sqlQuery = "INSERT INTO [dbo].[Product] ([Code], [Name], [Description], [QuantityLeft], [Price])" +
                          "VALUES (@code, @name, @description, @quantityLeft, @price);" +
                          "SELECT SCOPE_IDENTITY();";

            using var connection = _context.CreateConnection();
            int productId = await connection.ExecuteScalarAsync<int>(sqlQuery, product);

            return await GetProduct(productId);
        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        private async Task ValidateProduct(Product product)
        {
            product.Code = product.Code.Trim();
            product.Name = product.Name.Trim();

            var sqlQuery = "SELECT [Id], [Code], [Name], [Description], [QuantityLeft], [Price] " +
                    "FROM [dbo].[Product] WHERE UPPER([Code]) = UPPER(@code)";

            using var connection = _context.CreateConnection();
            var existingProduct = await connection.QueryFirstOrDefaultAsync<Product>(sqlQuery, new { code = product.Code });

            if (existingProduct != null)
            {
                throw new Exception(_localizer["ProductCodeExists"]);
            }

            sqlQuery = "SELECT [Id], [Code], [Name], [Description], [QuantityLeft], [Price] " +
                "FROM [dbo].[Product] WHERE UPPER([Name]) = UPPER(@name)";

            existingProduct = await connection.QueryFirstOrDefaultAsync<Product>(sqlQuery, new { name = product.Name });

            if (existingProduct != null)
            {
                throw new Exception(_localizer["ProductNameExists"]);
            }
        }
    }
}
